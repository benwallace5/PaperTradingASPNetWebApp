using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;


namespace LoginService
{
    public class Service1 : IService1
    {
        public int signIn(string username, string password)  //searches MemberCredentials.xml for User with matching username and password. Input: string username, string password Ouput: 0=success, -1=not found
        {
            string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data"); //App_Data folder location on server
            bool validUserName = false;  //bool keeping track of valid username
            XmlTextReader reader = null;  //initializing xmlTextReader 
            fileLocation += "\\MemberCredentials.xml";  //MemberCredentials is the name of the xml file containing username and passwords for members
            try
            {
                reader = new XmlTextReader(fileLocation);  //opening MemberCredentials.xml with xmltextreader object

                while (reader.Read()) //looping through xml file elements until end
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:  //do nothing on element type
                            break;
                        case XmlNodeType.Text:  //need to check for valid username, then valid password

                            if (reader.Value == username)  //updating valid username to true
                            {
                                validUserName = true;
                            }

                            if (reader.Value == password && validUserName)  //valid password and username combo
                            {
                                return 0;
                            }
                            break;
                        case XmlNodeType.EndElement:

                            if(reader.Name == "User")  //reached end of User element with invalid username password combo, need to update validUserName to false
                            {
                                validUserName=false;
                            }
                            break;
                    }
                }

            }
            finally
            {
                reader.Close();  //closing reader
            }
            return -1;  //-1 = not found
        }

        public int signUp(string username, string password)
        {
            string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data"); //App_Data folder location on server
            XmlTextReader reader = null;  //initializing xmlTextReader 
            fileLocation += "\\MemberCredentials.xml";  //MemberCredentials is the name of the xml file containing username and passwords for members

            try
            {
                reader = new XmlTextReader(fileLocation);  //opening MemberCredentials.xml with xmltextreader object

                while (reader.Read()) //looping through xml file elements until end
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Text:  //need to check if username already exists

                            if (reader.Value == username)  //username already exists
                            {
                                return -1;
                            }
                            break;
                    }
                }
                reader.Close();
                //username is valid, need to update MemberCredentials.xml with new user
                XmlDocument xd = new XmlDocument();
                xd.Load(fileLocation);  //loading xml file into document object
                XmlElement newUserElement = xd.CreateElement("User");  //creating new user element
                XmlElement usernameElement = xd.CreateElement("Username");  //creating password and username child elements
                XmlElement passwordElement = xd.CreateElement("Password");
                usernameElement.InnerText = username;  //setting inner text of element
                passwordElement.InnerText = password;
                newUserElement.AppendChild(usernameElement);  //appending Username and Password child elements to newUserElement
                newUserElement.AppendChild(passwordElement);
                xd.DocumentElement.AppendChild(newUserElement);  //appending newUser to document
                xd.Save(fileLocation);  //saving file
            }
            finally
            {
                reader.Close();  //closing reader

            }
            return 0;
        }
    }
}
