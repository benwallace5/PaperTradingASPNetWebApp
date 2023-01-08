<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="LoginTryIt.MemberPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

h1 {
  font-size: 36px;
}
h1 {
  margin-top: 20px;
  margin-bottom: 10px;
}
h1 {
  font-family: inherit;
  font-weight: 500;
  line-height: 1.1;
  color: inherit;
}
h1 {
  font-size: 2em;
  margin: 0.67em 0;
}
* {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
  * {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    -webkit-box-shadow: none !important;
    box-shadow: none !important;
  }
  .lead {
    font-size: 21px;
  }
.lead {
  margin-bottom: 20px;
  font-size: 16px;
  font-weight: 300;
  line-height: 1.4;
}
p {
  margin: 0 0 10px;
}
  p {
    orphans: 3;
    widows: 3;
  }
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member Page</h1>
            <p class="lead">
                Processes a stock order given a stock symbol, number of shares, credit cardNo, and account information. It uses my Stock Service to get the real time market price of the given stock symbol. It then verifies the account information using my Login Service and ensures the credit card number is valid. If all of these are verified, the order is processed and stored in the Orders.xml file on the server.</p>
            <p class="lead">
                Fake, valid visa card number: 4263982640269299</p>
            <h1>Checkout</h1>
            <p>
                Username:
                <asp:TextBox ID="usernameTextBox" runat="server" Width="231px">User</asp:TextBox>
            </p>
            <p>
                Stock Symbol:&nbsp;
                <asp:TextBox ID="stockSymbolTextBox" runat="server">i.e. AMD</asp:TextBox>
            </p>
            <p>
                Quantity:&nbsp;
                <asp:TextBox ID="quantityTextBox" runat="server">0</asp:TextBox>
            </p>
            <p>
                Credit Card Number:&nbsp;&nbsp;
                <asp:TextBox ID="cardNoTextBox" runat="server" Width="287px">4263982640269299</asp:TextBox>
            </p>
            <p>
                <asp:Button ID="checkoutButton" runat="server" OnClick="checkoutButton_Click" Text="Purchase" />
&nbsp;
                <asp:Label ID="statusLabel" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
