using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CreditCardRESTfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : CreditCard
    {
        public int verifyCard(string cardNo)  //implements Luhn Algorithm to verify credit card no: cardNo(string) output: 0 if cardNo is valid, -1 if invalid
        {
            int sum = 0;
            bool isEven = false;  //bool to keep track of even indices

            if(cardNo.Length < 13 || cardNo.Length > 16)  //checking length of cardNo
            {
                return -1;
            }

            //loop counting down from the length of the cardNo - 1 to 0. Traverses cardNo from right to left
            for (int i = cardNo.Length - 1; i >= 0; i--) 
            {
                int n = int.Parse(cardNo[i].ToString());  //n contains cardNo[i]

                if (isEven)  //multiply even indices by 2
                {
                    n = n * 2;
                }

                sum += n / 10;  //if n*2 >= 10 and n is of even rank, we add the two digits of the product and add that to the sum. Else we add n. i.e. n = 8, n * 2 = 16, so n = 7 = 1 + 6 
                sum += n % 10;  

                isEven = !isEven;  //keeps track of even indices
            }

            if(sum % 10 != 0)  //invalid cardNo
            {
                return -1;
            }

            return 0;
        }
    }
}
