<%@ Page Language="C#" Title=".:ТаБи.мн:. Япон-Монгол Илгээмж үйлчилгээний төв" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Daiei.Home" %>

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
                    <a href="Home.aspx" runat="server"><%= Resources.Resource.UserInformation %></a>
                </li>
                <li class="current clearfix">
                    <a href="ChangePassword.aspx" runat="server"><%= Resources.Resource.ChangePassword %></a>
                </li>
                <li class="clearfix">
                    <a href="ChangeProfile.aspx" runat="server"><%= Resources.Resource.ChangeUserInformation %></a>
                </li>
            </ul>
        </div>
    </aside>
    <div class="column fivecol">
        <div class="element-title indented">
            <h1>Хувийн мэдээлэл</h1>
        </div>
        <div class="site-form">
            <div class="message">
            </div>
            <table class="profile-fields">
                <tbody>
                    <tr>
                        <th><%= Resources.Resource.UserID %>(tabiID)</th>
                        <td>
                            <asp:Label runat="server" ID="lblUserID2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"> <font color="red"> <%= Resources.Resource.TabiIDAlert %> </font>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.UserName %></th>
                        <td>
                            <asp:Label runat="server" ID="lblFirstName">""</asp:Label>
                            <asp:Label runat="server" ID="lblLastName">""</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.Email %></th>
                        <td>
                            <asp:Label runat="server" ID="lblEmail">e.oogii@yahoo.com</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.PhoneMongolia %></th>
                        <td>
                            <asp:Label runat="server" ID="lblMNPhone">99654564</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.PhoneJapan %></th>
                        <td>
                            <asp:Label runat="server" ID="lblJPPhone">-</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.AddressMongolia %></th>
                        <td>
                            <asp:Label runat="server" ID="lblMNAddress">БЗД 15-р хороо 4-151</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.AddressJapan %></th>
                        <td>
                            <asp:Label runat="server" ID="lblJPAddress">-</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th><%= Resources.Resource.PackageTotal %>/th>
                        <td>
                            <asp:Label runat="server" ID="lblOrderCount">17</asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <aside class="column fourcol last">
        <div class="widget widget-slider sidebar-widget">
            <div class="widget-title" runat="server">
                <h4><%= Resources.Resource.LastLogin %></h4>
            </div>
            <ul>
                <li>
                    <asp:Label runat="server" ID="lblLastSign">2015-10-09 17:33:45</asp:Label></li>
            </ul>
        </div>
        <div class="widget widget-slider sidebar-widget">
            <div class="widget-title" runat="server">
                <h4><%= Resources.Resource.Last5Package %>/h4>
            </div>
            <ul>
                <asp:Repeater ID="listPackages" runat="server">
                    <ItemTemplate>
                        <li><a class="link" href="Check.aspx?v=<%# DataBinder.Eval(Container.DataItem, "MBno")%>">#<%# DataBinder.Eval(Container.DataItem, "MBno")%></a> - <i><%# DataBinder.Eval(Container.DataItem, "CreatedDate")%></i></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </aside>
</asp:Content>
