using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int signIn(string username, string password); //searches MemberCredentials.xml for User with matching username and password. Input: string username, string password Ouput: 0=found, -1=not found

        [OperationContract]
        int signUp(string username, string password);  //searches MemberCredentials.xml for User with matching username, creates new user if one does not exist
                                                       //Input: string username, string password
                                                       //Output:
                                                       //0 = success
                                                       //-1 = username already exists


    }
}
