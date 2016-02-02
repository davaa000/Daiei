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
                <li class="current clearfix">
                    <a href="Home.aspx">Хувийн мэдээлэл</a>
                </li>
                <li class="clearfix">
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
            <h1>Хувийн мэдээлэл</h1>
        </div>
        <div class="site-form">
            <div class="message">
            </div>
            <table class="profile-fields">
                <tbody>
                    <tr>
                        <th>Хэрэглэгчийн код</th>
                        <td>
                            <asp:Label runat="server" ID="lblUserID2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>Нэр</th>
                        <td>
                            <asp:Label runat="server" ID="lblFirstName">Энхээ</asp:Label>
                            <asp:Label runat="server" ID="lblLastName">Отгонбат</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>Имэйл</th>
                        <td>
                            <asp:Label runat="server" ID="lblEmail">e.oogii@yahoo.com</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>Утас (Монгол)</th>
                        <td>
                            <asp:Label runat="server" ID="lblMNPhone">99654564</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>Утас (Япон)</th>
                        <td>
                            <asp:Label runat="server" ID="lblJPPhone">-</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>Хаяг (Монгол)</th>
                        <td>
                            <asp:Label runat="server" ID="lblMNAddress">БЗД 15-р хороо 4-151</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>Хаяг (Япон)</th>
                        <td>
                            <asp:Label runat="server" ID="lblJPAddress">-</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>Нийт илгээмж</th>
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
                <asp:Repeater ID="listPackages" runat="server">
                    <ItemTemplate>
                        <li><a class="link" href="Check.aspx?v=<%# DataBinder.Eval(Container.DataItem, "MBno")%>">#<%# DataBinder.Eval(Container.DataItem, "MBno")%></a> - <i><%# DataBinder.Eval(Container.DataItem, "CreatedDate")%></i></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </aside>
</asp:Content>
