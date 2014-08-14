<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Training.Workshop.ASP.Client.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="accountInfo">
        <fieldset class="login">
           <legend>Add new user panel</legend>
           
           <asp:Label ID="UserNameLabel" runat="server">Username:</asp:Label>
            <br />
           <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
           <asp:Label ID="UserPasswordLabel" runat="server">Password:</asp:Label>
            <br />
           <asp:TextBox ID="UserPasswordTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
           <asp:Label ID="UserPermissionsLabel" runat="server">Permissions:</asp:Label>
           <br />
           <asp:TextBox ID="UserPermissionsTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           <asp:Label ID="UserRoleLabel" runat="server">User Role:</asp:Label>
           <asp:TextBox ID="UserRoleTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
            
            <br />
            
           <p class="submitButton">
             <asp:Button ID="AddUserButton" runat="server" Text="Add User" 
                   OnClick="AddNewUser" Height="30px" Width="321px" />
             <asp:Button ID="DeleteUserButton" runat="server" Text="Delete User" 
                   OnClick="DeleteUser" Height="30px" Width="321px" />
             <asp:Button ID="UpdateUser" runat="server" Text="Delete User" 
                   OnClick="UpdateUser" Height="30px" Width="321px" />
           </p>
        </fieldset>
    </div>


      <div class="accountInfo">
        <fieldset class="login">
           <legend>Add new bike panel</legend>
           
           <asp:Label ID="BikeManufacturer" runat="server">Manufacturer:</asp:Label>
           <asp:TextBox ID="_BikeManufacturer" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           <asp:Label ID="BikeMark" runat="server">Mark:</asp:Label>
           <asp:TextBox ID="_BikeMark" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           <asp:Label ID="BikeYear" runat="server">BikeYear:</asp:Label>
           <asp:TextBox ID="_BikeTear" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           
           <asp:Label ID="BikeOwner" runat="server">Owner:</asp:Label>
           <asp:TextBox ID="_BikeOwner" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           
           <asp:Label ID="BikeCondition" runat="server">Condition:</asp:Label>
           <asp:TextBox ID="_BikeCondition" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
            
           <p class="submitButton">
             <asp:Button ID="AddBike" runat="server" Text="Add User" 
                   OnClick="AddNewBike" Height="30px" Width="321px" />
             <asp:Button ID="UpdateBike" runat="server" Text="Delete User" 
                   OnClick="UpdateExistingBike" Height="30px" Width="321px" />
           </p>
        </fieldset>
    </div>

</asp:Content>
