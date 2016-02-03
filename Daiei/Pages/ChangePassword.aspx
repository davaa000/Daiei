<%@ Page Title=".:ТаБи.мн:. Нууц үг солих" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Daiei.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container" runat="server">
            <h1><%= Resources.Resource.User %>
                <asp:Label runat="server" ID="lblUserID">#00000001</asp:Label></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
      <div class="column fivecol">
        <div class="element-title indented" runat="server">
            <h1><%= Resources.Resource.ChangePassword %></h1>
        </div>
        <div class="site-form">
            <table class="profile-fields" runat="server">
                <tbody>
                    <tr>
                        <th ><%= Resources.Resource.OldPassword %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtPass11" Width="100%" placeholder="<%$ Resources:Resource, OldPassword %>" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPass11"
                                    ErrorMessage="" CssClass="Validator" ValidationGroup="ChangePass">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.NewPassword %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtPass22" Width="100%" placeholder="<%$ Resources:Resource, NewPassword %>" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass22"
                                    ErrorMessage="" CssClass="Validator" ValidationGroup="ChangePass">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.ConfirmationPassword %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtPass33" Width="100%" placeholder="<%$ Resources:Resource, ConfirmationPassword %>" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPass33"
                                    ErrorMessage="" CssClass="Validator" ValidationGroup="ChangePass">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Button ID="btnSave" CssClass="element-button primary" Text="<%$ Resources:Resource, Save %>" runat="server" ValidationGroup="ChangePass" OnClick="btnSave_Click"/>
        </div>
    </div>
</asp:Content>
