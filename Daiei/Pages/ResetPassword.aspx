<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Daiei.Pages.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container" runat="server">
            <h1><%= Resources.Resource.UserInformation  %>
                <asp:Label runat="server" ID="lblUserID">#00000001</asp:Label></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column fivecol">
        <div class="element-title indented">
            <h1><%= Resources.Resource.ResetPassword  %></h1>
        </div>
        <div class="site-form">
            <table class="profile-fields" runat="server">
                <tbody>
                    <tr>
                        <th><%= Resources.Resource.NewPassword  %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtPass22" Width="100%" placeholder="<%$ Resources:Resource, NewPassword %>" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass22"
                                    ErrorMessage="<%$ Resources:Resource, NewPassword %>" CssClass="Validator" ValidationGroup="ChangePass">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.ConfirmationPassword  %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtPass33" Width="100%" placeholder="<%$ Resources:Resource,ConfirmationPassword %>" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPass33"
                                    ErrorMessage="<%$ Resources:Resource, ConfirmationPassword %>" CssClass="Validator" ValidationGroup="ChangePass">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Button ID="btnSave" CssClass="element-button primary" Text="<%$ Resources:Resource, Save %>" runat="server" ValidationGroup="ChangePass" OnClick="btnSave_Click"/>
        </div>
    </div>
    
</asp:Content>

