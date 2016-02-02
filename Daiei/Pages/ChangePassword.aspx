<%@ Page Title=".:ТаБи.мн:. Нууц үг солих" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Daiei.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container">
            <h1>Хэрэглэгч
                <asp:Label runat="server" ID="lblUserID">#00000001</asp:Label></h1>
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
                <li class="current clearfix">
                    <a href="ChangePassword.aspx">Нууц үг өөрчлөх</a>
                </li>
                <li class="clearfix">
                    <a href="ChangeProfile.aspx">Хувийн мэдээлэл өөрчлөх</a>
                </li>
            </ul>
        </div>
    </aside>
    <div class="column fivecol">
        <div class="element-title indented">
            <h1>Нууц үг өөрчлөх</h1>
        </div>
        <div class="site-form">
            <table class="profile-fields">
                <tbody>
                    <tr>
                        <th>Хуучин нууц үг</th>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadTextBox runat="server" ID="txtPass11" Width="100%" placeholder="Хуучин нууц үг" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPass11"
                                    ErrorMessage="Хуучин нууц үг" CssClass="Validator" ValidationGroup="ChangePass">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
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
    <aside class="column fourcol last">
        <div class="widget widget-slider sidebar-widget">
            <div class="widget-title">
                <h4>Сүүлийн нэвтрэлт</h4>
            </div>
            <ul>
                <li>
                    <asp:Label runat="server" ID="lblLastSign">2015-10-09 17:33:45</asp:Label></li>
            </ul>
        </div>
        <div class="widget widget-slider sidebar-widget">
            <div class="widget-title">
                <h4>Сүүлийн 5 илгээмж</h4>
            </div>
            <ul>
                <li>
                    <asp:HyperLink ID="linkOrder" NavigateUrl="Check.aspx" ToolTip="Харах" CssClass="link" runat="server">
                        <asp:Label runat="server" ID="lblOrderID">#201509021015001</asp:Label>
                    </asp:HyperLink>
                    - <i>
                        <asp:Label runat="server" ID="lblOrderDate">2015-10-09 17:33:45</asp:Label></i></li>
                <li>
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="Check.aspx" ToolTip="Харах" CssClass="link" runat="server">
                        <asp:Label runat="server" ID="Label1">#201509021015001</asp:Label>
                    </asp:HyperLink>
                    - <i>
                        <asp:Label runat="server" ID="Label2">2015-10-09 17:33:45</asp:Label></i></li>
                <li>
                    <asp:HyperLink ID="HyperLink2" NavigateUrl="Check.aspx" ToolTip="Харах" CssClass="link" runat="server">
                        <asp:Label runat="server" ID="Label3">#201509021015001</asp:Label>
                    </asp:HyperLink>
                    - <i>
                        <asp:Label runat="server" ID="Label4">2015-10-09 17:33:45</asp:Label></i></li>
                <li>
                    <asp:HyperLink ID="HyperLink3" NavigateUrl="Check.aspx" ToolTip="Харах" CssClass="link" runat="server">
                        <asp:Label runat="server" ID="Label5">#201509021015001</asp:Label>
                    </asp:HyperLink>
                    - <i>
                        <asp:Label runat="server" ID="Label6">2015-10-09 17:33:45</asp:Label></i></li>
                <li>
                    <asp:HyperLink ID="HyperLink4" NavigateUrl="Check.aspx" ToolTip="Харах" CssClass="link" runat="server">
                        <asp:Label runat="server" ID="Label7">#201509021015001</asp:Label>
                    </asp:HyperLink>
                    - <i>
                        <asp:Label runat="server" ID="Label8">2015-10-09 17:33:45</asp:Label></i></li>
                <li>
                    <asp:HyperLink ID="HyperLink5" NavigateUrl="Check.aspx" ToolTip="Харах" CssClass="link" runat="server">
                        <asp:Label runat="server" ID="Label9">#201509021015001</asp:Label>
                    </asp:HyperLink>
                    - <i>
                        <asp:Label runat="server" ID="Label10">2015-10-09 17:33:45</asp:Label></i></li>
            </ul>
        </div>
    </aside>
</asp:Content>
