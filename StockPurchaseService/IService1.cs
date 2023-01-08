using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockPurchaseService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int purchaseStock(string stockSymbol, string quantity, string cardNo, string user);  
        //return values: 
        //0 -> order success
        //-1 -> invalid cardNo
        //-2 -> invalid account info
        //Processes a stock order given a stock symbol, number of shares, credit cardNo, and account information. It uses my Stock Service to get the real time market price of the given stock symbol.
        //It then verifies the account information using my Login Service and ensures the credit card number is valid. If all of these are verified, the order is processed and stored in the user's xml file on the server.
    }
}

