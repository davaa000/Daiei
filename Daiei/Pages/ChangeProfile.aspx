<%@ Page Title=".:ТаБи.мн:. Хувийн мэдээлэл өөрчлөх" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangeProfile.aspx.cs" Inherits="Daiei.ChangeProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container" runat="server">
            <h1> <%= Resources.Resource.UserInformation %>
                <asp:Label runat="server" ID="lblUserID"></asp:Label></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column ninecol last">
        <div class="element-title indented" runat="server">
            <h1><%= Resources.Resource.ChangeUserInformation %></h1>
        </div>
        <div class="site-form">
            <table class="profile-fields" runat="server">
                <tbody>
                    <tr>
                        <th><%= Resources.Resource.UserID %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtUserCode" Width="100%" Enabled="false"></telerik:RadTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.LastName %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtRFirstName" Width="100%" placeholder="<%$ Resources:Resource, LastName %>"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRFirstName"
                                    ErrorMessage="" CssClass="Validator" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.UserName %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtRLastName" Width="100%" placeholder="<%$ Resources:Resource, UserName %>"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRLastName"
                                    ErrorMessage="<%$ Resources:Resource, EnterValue %>" CssClass="Validator" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.Email %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtREmail" Width="100%" placeholder="<%$ Resources:Resource, Email %>"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtREmail"
                                    ErrorMessage="<%$ Resources:Resource, EnterEmail %>" CssClass="Validator" ValidationGroup="Register">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="emailValidator" runat="server"
                                    ErrorMessage="<%$ Resources:Resource, EnterValue %>" CssClass="Validator" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                    ControlToValidate="txtREmail" ValidationGroup="Edit">
                                </asp:RegularExpressionValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.PhoneMongolia %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadNumericTextBox ID="txtRMNPhone" runat="server" MaxValue="99999999" MinValue="10000"
                                    EmptyMessage="" MaxLength="8" CssClass="RadTextBox" placeholder="<%$ Resources:Resource, PhoneMongolia %>"
                                    Width="100%">
                                    <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRMNPhone"
                                    ErrorMessage="Утасны дугаар (Монгол)" CssClass="Validator" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.PhoneJapan %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadNumericTextBox ID="txtRJPPhone" runat="server" MaxValue="9999999999999" MinValue="10000"
                                    EmptyMessage="" MaxLength="13" CssClass="RadTextBox" placeholder="Утас (Япон)"
                                    Width="100%">
                                    <NumberFormat DecimalDigits="0" GroupSeparator="-" GroupSizes="3" />
                                </telerik:RadNumericTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.AddressMongolia %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtRMNAddress" Width="100%" placeholder="<%$ Resources:Resource, AddressMongolia %>"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRMNAddress"
                                    ErrorMessage="<%$ Resources:Resource, EnterValue %>" CssClass="Validator" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.AddressJapan %></th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtRJPAddress" Width="100%" placeholder="<%$ Resources:Resource, AddressJapan %>"></telerik:RadTextBox>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Button ID="btnSave" CssClass="element-button primary" ValidationGroup="Edit" Text="<%$ Resources:Resource, Save %>" runat="server" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
