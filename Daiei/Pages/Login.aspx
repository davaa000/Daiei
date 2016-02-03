<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Daiei.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container" runat="server">
            <h1><%= Resources.Resource.Login %></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column threecol">
    </div>
    <div class="column sixcol">
        <div class="element-title" runat="server">
            <h1><%= Resources.Resource.LoginSection %></h1>
        </div>
        <div class="site-form element-form">
            <div class='field-wrap'>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLEmail"
                    ErrorMessage="<%$ Resources:Resource, EnterEmail %>" CssClass="Validator" ValidationGroup="Llogin">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                <telerik:RadTextBox runat="server" ID="txtLEmail" placeholder='Имэйл' Width="100%"></telerik:RadTextBox>
            </div>
            <div class='field-wrap'>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLPassword"
                    ErrorMessage="<%$ Resources:Resource, EnterValue %>" CssClass="Validator" ValidationGroup="Llogin">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                <telerik:RadTextBox runat="server" ID="txtLPassword" placeholder='Нууц үг' Width="100%" TextMode="Password"></telerik:RadTextBox>
            </div>
            <asp:Button ID='btnLLogin' CssClass='element-button primary' Text='<%$ Resources:Resource, Login %>' runat='server' Style="margin-top: 10px" OnClick="btnLLogin_Click" ValidationGroup="Llogin" />
            <a style='padding: 8px 20px 8px 15px; margin-top: 10px;' href='#password_form' class='element-button element-colorbox square cboxElement' title='<%$ Resources:Resource, ForgotPassword %>' runat="server"><span class='fa fa-life-ring'></span></a>
        </div>
    </div>
    <div class="column threecol last">
    </div>
    <div class="clear"></div>
</asp:Content>
