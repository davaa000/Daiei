<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Daiei.Pages.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container">
            <h1>Хэрэглэгчийн нууц үг солих
                <asp:Label runat="server" ID="lblUserID">#00000001</asp:Label></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column fivecol">
        <div class="element-title indented">
            <h1>Нууц үг өөрчлөх</h1>
        </div>
        <div class="site-form">
            <table class="profile-fields">
                <tbody>
                    <tr>
                        <th>Шинэ нууц үг</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtPass22" Width="100%" placeholder="Шинэ нууц үг" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass22"
                                    ErrorMessage="Шинэ нууц үг" CssClass="Validator" ValidationGroup="ChangePass">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>Нууц үг давтах</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtPass33" Width="100%" placeholder="Нууц үг давтах" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPass33"
                                    ErrorMessage="Шинэ нууц үг дахин оруулах" CssClass="Validator" ValidationGroup="ChangePass">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Button ID="btnSave" CssClass="element-button primary" Text="Хадгалах" runat="server" ValidationGroup="ChangePass" OnClick="btnSave_Click"/>
        </div>
    </div>
    
</asp:Content>

