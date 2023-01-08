using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginTryIt
{
    public partial class MemberPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkoutButton_Click(object sender, EventArgs e)
        {
            StockPurchaseService.Service1Client brokerClient = new StockPurchaseService.Service1Client();  //synthetic stock purchase proxy 

            int x = brokerClient.purchaseStock(stockSymbolTextBox.Text, quantityTextBox.Text, cardNoTextBox.Text, usernameTextBox.Text);

            if (x == -1)  //invalid card num
            {
                statusLabel.Text = "Order unsuccessful, invalid card number";
            }

            if (x == -2)  //invalid account info
            {
                statusLabel.Text = "Order unsuccessful, invalid account information";
            }

            if (x == 0)  //successful order
            {
                statusLabel.Text = "Order successful";
                usernameTextBox.Text = "";
                cardNoTextBox.Text = "";
                stockSymbolTextBox.Text = "";
                quantityTextBox.Text = "";
            }
        }
    }
}