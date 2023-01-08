using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;

namespace StockPurchaseService
{
    //return values: 
    //0 -> order success
    //-1 -> invalid cardNo
    //-2 -> invalid account info
    //Processes a stock order given a stock symbol, number of shares, credit cardNo, and account information. It uses my Stock Service to get the real time market price of the given stock symbol.
    //It then verifies the account information using my Login Service and ensures the credit card number is valid. If all of these are verified, the order is processed and stored in the user's file on the server.
    public class Service1 : IService1
    {
       public int purchaseStock(string stockSymbol, string quantity, string cardNo, string user)
        {
            string comma = ",";
            string regularMarketPrice = "";
            string URL = "http://webstrar70.fulton.asu.edu/page0/Service1.svc/verifyCard?cardNo=";  //incomplete link to my RESTful credit card number verifier service. Need to append parameter value
            string completeURL = URL + cardNo;  //appending cardNo parameter to end of url
            WebClient channel = new WebClient();  //create channel
            StockService.Service1Client stockService = new StockService.Service1Client();  //stockService proxy. StockService is used to get a price summary of a given stock symbol
            LoginService.Service1Client loginService = new LoginService.Service1Client();  //loginService proxy. It will be used to verify credentials for purchase
            Uri uri = new Uri(completeURL);  //converting to uri
            byte[] buffer = channel.DownloadData(uri);  //downloading output from verifyCard
            string isValid = System.Text.Encoding.UTF8.GetString(buffer);  //converting to string. 

            if (isValid.Length != 72)  //invalid card number return -1
            {
                return -1;
            }

            string s = stockService.getSummary(stockSymbol);  //getting price summary of symbol: stockSymbol using my Stock Service

            for (int i = s.IndexOf("regularMarketPrice") + "regularMarketPrice".Length + 2; i < s.Length; i++)  //extracting regularMarketPrice from string
            {
                if (s[i].ToString() == comma)
                {
                    break;
                }
                regularMarketPrice += s[i].ToString();
            }

            //now that we know account info and cardNo are valid, need to process/save order to users' account file

            float marketPrice = float.Parse(regularMarketPrice);  //parsing regularMarketPrice
            string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data"); //App_Data folder location on server
            fileLocation += "\\Orders.xml";  //MemberCredentials is the name of the xml file containing username and passwords for members
            XmlDocument xd = new XmlDocument();
            xd.Load(fileLocation);  //loading xml file into document object
            XmlElement newOrder = xd.CreateElement("Order");  //creating xml elements
            XmlElement symbol = xd.CreateElement("Symbol");
            XmlElement quantityElement = xd.CreateElement("Quantity");
            XmlElement price = xd.CreateElement("Price");
            XmlElement userName = xd.CreateElement("User");
            symbol.InnerText = stockSymbol;  //setting innner text contents
            quantityElement.InnerText = quantity;
            price.InnerText = regularMarketPrice.ToString();
            userName.InnerText = user;
            newOrder.AppendChild(symbol);  //appending child elements to newOrder element
            newOrder.AppendChild(quantityElement);
            newOrder.AppendChild(price);
            newOrder.AppendChild(userName);
            xd.DocumentElement.AppendChild(newOrder);  //appending newOrder
            xd.Save(fileLocation);


            return 0;
        }
    }
}
