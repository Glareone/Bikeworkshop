<%@ Page Title="TestPage" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="TestPage.aspx.cs" Inherits="Training.Workshop.ASP.ASPClient.Account.ChangePassword" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


<asp:Content runat="server" ID="head" ContentPlaceHolderId="MainContent">
  
    <div class="accountInfo">
        <fieldset class="login">
           <legend>Account Information</legend>
           
           <asp:Label ID="UserNameLabel" runat="server">Username:</asp:Label>
           <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
           <asp:Label ID="UserPasswordLabel" runat="server">Password:</asp:Label>
           <asp:TextBox ID="UserPassword" runat="server" CssClass="textEntry"></asp:TextBox>
            
           <p class="submitButton">
             <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
           </p>
        </fieldset>
    </div>

</asp:Content>


