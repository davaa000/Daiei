<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="Daiei.assets.control.header" %>

<header class="site-header container">
    <div class="header-logo left">
        <a href="Home.aspx" rel="home">
            <img src="../assets/img/logo.png" alt="ТаБи.мн: Япон-Монгол Илгээмж үйлчилгээний төв" />
        </a>
    </div>
    <!-- /logo -->
    <div class='header-options right clearfix'>
        <asp:Label runat="server" ID="lblPanel"></asp:Label>
       
        <div class='site-popups hidden'>
            <div id='login_form'>
                <div class='site-popup small'>
                    <div class='site-form element-form'>
                        <div class='field-wrap'>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Имэйл хаяг" CssClass="Validator" ValidationGroup="Login">*Утга оруул</asp:RequiredFieldValidator>
                            <telerik:RadTextBox runat="server" ID="txtEmail" placeholder='Имэйл' Width="240px"></telerik:RadTextBox>
                        </div>
                        <div class='field-wrap'>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="Нууц үг" CssClass="Validator" ValidationGroup="Login">*Утга оруул</asp:RequiredFieldValidator>
                            <telerik:RadTextBox runat="server" ID="txtPassword" placeholder='Нууц үг' Width="240px" TextMode="Password"></telerik:RadTextBox>
                        </div>
                        <asp:Button ID='btnLogin' CssClass='element-button primary' Text='Нэвтрэх' runat='server' Style="margin-top:10px" OnClick="btnLogin_Click" ValidationGroup="Login" />
                        <a style='padding: 8px 20px 8px 15px; margin-top: 10px;' href='#password_form' class='element-button element-colorbox square cboxElement' title='Нууц үг мартсан'><span class='fa fa-life-ring'></span></a>
                    </div>
                </div>
            </div>
            <div id='password_form'>
                <div class='site-popup small'>
                    <div class='site-form element-form'>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtResetEmail"
                                ErrorMessage="Имэйл хаяг" CssClass="Validator" ValidationGroup="ResetPass">*Утга оруул</asp:RequiredFieldValidator>
                        <div class='field-wrap'>
                            <telerik:RadTextBox runat="server" ID="txtResetEmail" placeholder='Имэйл' Width="240px"></telerik:RadTextBox>
                        </div>
                        <asp:Button ID='btnResetPassword' CssClass='element-button primary' Text='Нууц үг шинэчлэх' runat='server' Style="margin-top:10px" OnClick="btnResetPassword_Click" ValidationGroup="ResetPass"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Дараах мэдээллүүдийн утгыг оруулна уу."
        ShowMessageBox="True" ShowSummary="False" />
    <!-- /options -->
</header>
<!-- /header -->
<div class="site-toolbar container">
    <asp:Label runat="server" ID="lblMenu"></asp:Label>
</div>
<!-- /toolbar -->
