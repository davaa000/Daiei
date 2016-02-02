<%@ Page Title=".:ТаБи.мн:. Хувийн мэдээлэл өөрчлөх" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangeProfile.aspx.cs" Inherits="Daiei.ChangeProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container">
            <h1>Хэрэглэгч
                <asp:Label runat="server" ID="lblUserID"></asp:Label></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <aside class="column threecol">
        <div class="profile-preview sidebar-widget">
            <div class="profile-image">
                <div class="image-wrap">
                    <img src="../assets/css/images/avatar.png" class="avatar" width="200" alt="" />
                </div>
            </div>
        </div>
        <div class="profile-menu sidebar-widget">
            <ul>
                <li class="clearfix">
                    <a href="Home.aspx">Хувийн мэдээлэл</a>
                </li>
                <li class="clearfix">
                    <a href="ChangePassword.aspx">Нууц үг өөрчлөх</a>
                </li>
                <li class="current clearfix">
                    <a href="ChangeProfile.aspx">Хувийн мэдээлэл өөрчлөх</a>
                </li>
            </ul>
        </div>
    </aside>
    <div class="column ninecol last">
        <div class="element-title indented">
            <h1>Хувийн мэдээлэл өөрчлөх</h1>
        </div>
        <div class="site-form">
            <table class="profile-fields">
                <tbody>
                    <tr>
                        <th>Хэрэглэгчийн код</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtUserCode" Width="100%" Enabled="false"></telerik:RadTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>Эцэг /эх/-ийн нэр</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtRFirstName" Width="100%" placeholder="Эцэг/эх/-ийн нэр"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRFirstName"
                                    ErrorMessage="Эцэг/эх/-ийн нэр" CssClass="Validator" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>Нэр</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtRLastName" Width="100%" placeholder="Нэр"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRLastName"
                                    ErrorMessage="Нэр" CssClass="Validator" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>Имэйл</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtREmail" Width="100%" placeholder="Имэйл хаяг"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtREmail"
                                    ErrorMessage="Имэйл" CssClass="Validator" ValidationGroup="Register">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="emailValidator" runat="server"
                                    ErrorMessage="Зөв утга оруул" CssClass="Validator" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                    ControlToValidate="txtREmail" ValidationGroup="Edit">
                                </asp:RegularExpressionValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>Утас (Монгол)</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadNumericTextBox ID="txtRMNPhone" runat="server" MaxValue="99999999" MinValue="10000"
                                    EmptyMessage="" MaxLength="8" CssClass="RadTextBox" placeholder="Утас (Монгол)"
                                    Width="100%">
                                    <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRMNPhone"
                                    ErrorMessage="Утасны дугаар (Монгол)" CssClass="Validator" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>Утас (Япон)</th>
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
                        <th>Хаяг (Монгол)</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtRMNAddress" Width="100%" placeholder="Хаяг (Монгол)"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRMNAddress"
                                    ErrorMessage="Хаяг (Монгол)" CssClass="Validator" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>Хаяг (Япон)</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtRJPAddress" Width="100%" placeholder="Хаяг (Япон)"></telerik:RadTextBox>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Button ID="btnSave" CssClass="element-button primary" ValidationGroup="Edit" Text="Хадгалах" runat="server" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
