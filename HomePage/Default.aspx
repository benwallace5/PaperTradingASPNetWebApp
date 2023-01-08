<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoginTryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Stock Purchase Platform</h1>
        <h3>Create an account to purchase stocks and view stock information. List of services: <a href="http://webstrar70.fulton.asu.edu/index.html">http://webstrar70.fulton.asu.edu/index.html</a></h3>
        <p>New User? Sign up </p>
        <p>First Name:&nbsp;
            <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
        </p>
        <p>Last Name:&nbsp;
            <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
        </p>
        <p>Username:&nbsp;&nbsp;
            <asp:TextBox ID="signUpUsernameTextBox" runat="server"></asp:TextBox>
        </p>
        <p>Password:&nbsp;&nbsp;
            <asp:TextBox ID="signUpPasswordTextBox" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;<asp:Button ID="signUpButton" runat="server" OnClick="signUpButton_Click" Text="Sign Up" Width="119px" />
&nbsp;
            <asp:Label ID="signUpStatusLabel" runat="server"></asp:Label>
        </p>
        <p>Existing Account? Login</p>
        <p>Username:&nbsp;
            <asp:TextBox ID="loginUsernameTextBox" runat="server"></asp:TextBox>
        </p>
        <p>Password:&nbsp;
            <asp:TextBox ID="loginPasswordTextBox" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;<asp:Button ID="loginButton" runat="server" Text="Login" Width="93px" OnClick="loginButton_Click" />
&nbsp;
            <asp:Label ID="loginStatusLabel" runat="server"></asp:Label>
        </p>
    </div>

    </asp:Content>
