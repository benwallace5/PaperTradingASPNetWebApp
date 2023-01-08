using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CreditCardRESTfulService
{
    [ServiceContract]
    public interface CreditCard
    {

        [OperationContract]
        [WebGet(UriTemplate = "verifyCard?cardNo={cardNo}")]  //for converting to REST
        int verifyCard(string cardNo);  //verify implements Luhn Algorithm to verify credit card no: cardNo(double) output: 0 if cardNo is valid, -1 if invalid

    }
}
