<%@ Page Title=".:ТаБи.мн:. Төлөв шалгах" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Check.aspx.cs" Inherits="Daiei.Check" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container">
            <h1>Төлөв шалгах</h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">

    <div class="column twelvecol">
        <div class="element-title indented">
            <h1>Төлөв шалгах</h1>
        </div>
        <div class="site-form">
            <asp:Panel ID="pnlCheckForm" runat="server">
                <table class="item-form" style="margin-bottom: 40px;">
                    <tbody>
                        <tr>
                            <th>Захиалгын дугаар</th>
                            <th>Тракин дугаар</th>
                            <th>Илгээмжийн дугаар</th>
                            <th></th>
                        </tr>
                        <tr>
                            <td>
                                <div class="field-wrap">
                                    <telerik:RadTextBox runat="server" ID="txtOrderNumber" Width="100%" placeholder="#order number"></telerik:RadTextBox>
                                </div>
                            </td>
                            <td>
                                <div class="field-wrap">
                                    <telerik:RadTextBox runat="server" ID="txtTrackingNumber" Width="100%" placeholder="#tracking number"></telerik:RadTextBox>
                                </div>
                            </td>
                            <td>
                                <div class="field-wrap">
                                    <telerik:RadTextBox runat="server" ID="txtPackageNumber" Width="100%" placeholder="Таби.мн илгээмжийн дугаар"></telerik:RadTextBox>
                                </div>
                            </td>
                            <td>
                                <asp:Button ID="btnCheckStatus" runat="server" Text="Төлөв шалгах" OnClick="btnCheckStatus_Click" CausesValidation="false" type="button" class="element-button" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </div>

        <asp:Panel ID="pnlPackageStatus" runat="server" Visible="false">
            <div class="widget widget-slider sidebar-widget"  style="margin-bottom: 40px;">
                <div class="widget-title">
                    <h4>Илгээмжийн төлөв</h4>
                </div>
                <table class="profile-table">
                    <thead>
                        <tr>
                            <th>Огноо</th>
                            <th>Төлөв</th>
                            <th>Тайлбар</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="lstPackageStatus" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# DataBinder.Eval(Container.DataItem, "StatusDateF")%></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Description")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlPackageInfo" runat="server" Visible="false">
            <div class="widget widget-slider sidebar-widget">
                <div class="widget-title">
                    <h4>Илгээмжийн мэдээлэл</h4>
                </div>
                <div class="column sixcol">
                    <table class="package-info">
                        <tbody>
                            <tr>
                                <th>Бүртгэсэн хэрэглэгч</th>
                                <td>
                                    <asp:Label runat="server" ID="lblCreatedUser"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>ТаБи.мн илгээмжийн дугаар</th>
                                <td>
                                    <asp:Label runat="server" ID="lblTabuOrderNumber"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>Хүлээн авагчийн нэр</th>
                                <td>
                                    <asp:Label runat="server" ID="lblReciveHuman"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>Хүлээн авагчийн хаяг</th>
                                <td>
                                    <asp:Label runat="server" ID="lblReviceAddress"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>Хүлээн авагчийн утас</th>
                                <td>
                                    <asp:Label runat="server" ID="lblRevicePhone"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="column sixcol last">
                    <table class="package-info">
                        <tbody>
                            <tr>
                                <th>Захиалга ирэх нэр</th>
                                <td>
                                    <asp:Label runat="server" ID="lblOrderName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>Захиалгын дугаар</th>
                                <td>
                                    <asp:Label runat="server" ID="lblOrderNumber"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>Тракин дугаар</th>
                                <td>
                                    <asp:Label runat="server" ID="lblTrackingNumber"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>Сайтын хаяг (URL)</th>
                                <td>
                                    <asp:Label runat="server" ID="lblSiteName"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <telerik:RadGrid ID="grdListItems" AutoGenerateColumns="False" AllowPaging="false" runat="server" GridLines="None" Skin="MetroTouch" ShowFooter="True">
                    <MasterTableView CommandItemDisplay="None" Height="100%" NoMasterRecordsText="Жагсаалт хоосон." ShowHeadersWhenNoRecords="true" HierarchyDefaultExpanded="true" TableLayout="Auto" AutoGenerateColumns="false">
                        <Columns>
                            <telerik:GridBoundColumn ReadOnly="true" HeaderText="Барааны нэр" DataField="NAME" UniqueName="NAME" Aggregate="Count" FooterText="Нийт бараа: ">
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" />
                                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="30px" />
                                <FooterStyle HorizontalAlign="Left" Font-Size="11px" ForeColor="Black" Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn ReadOnly="true" HeaderText="Бренд нэр" DataField="BRAND"
                                UniqueName="BRAND">
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" />
                                <ItemStyle Font-Names="Tahoma" Font-Size="12px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn ReadOnly="true" HeaderText="Тоо ширхэг" DataField="ITEMCOUNT"
                                UniqueName="ITEMCOUNT">
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="90px" Font-Bold="true" />
                                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn ReadOnly="true" HeaderText="Нэгж үнэ ¥" DataField="ITEMRATE"
                                UniqueName="ITEMRATE">
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="100px" Font-Bold="true" />
                                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn ReadOnly="true" HeaderText="Нийт үнэ ¥" DataField="ITEMRATESUM"
                                UniqueName="ITEMRATESUM">
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="100px" Font-Bold="true" />
                                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true">
                        <Scrolling AllowScroll="true" UseStaticHeaders="false" ScrollHeight="" />
                    </ClientSettings>
                </telerik:RadGrid>
                <div style="margin-top: 20px">
                    <div class="column sixcol">
                        <table class="package-info">
                            <tbody>
                                <tr>
                                    <th>Илгээмжийн жин</th>
                                    <td>
                                        <asp:Label runat="server" ID="lblJin"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Илгээмжийн эзэлхүүн</th>
                                    <td>
                                        <asp:Label runat="server" ID="lblEzelhuun"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Илгээмжийн төлбөр</th>
                                    <td>
                                        <asp:Label runat="server" ID="lblFee"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="column sixcol last">
                        <table class="package-info">
                            <tbody>
                                <tr>
                                    <th>Sales tax</th>
                                    <td>
                                        <asp:Label runat="server" ID="lblSale">0.00</asp:Label>¥
                                    </td>
                                </tr>
                                <tr>
                                    <th>Shipping</th>
                                    <td>
                                        <asp:Label runat="server" ID="lblShiping">0.00</asp:Label>¥
                                    </td>
                                </tr>
                                <tr>
                                    <th>Discount</th>
                                    <td>
                                        <asp:Label runat="server" ID="lblDiscount">0.00</asp:Label>¥
                                    </td>
                                </tr>
                                <tr>
                                    <th>Захиалгын нийт үнэ</th>
                                    <td>
                                        <asp:Label runat="server" ID="lblSumRate">400</asp:Label>¥
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <asp:Button ID="btnEditPackage" runat="server" Text="Илгээмжийн мэдээлэл засварлах" OnClick="btnEditPackage_Click" type="button" class="element-button" Enabled="false" CausesValidation="false" />
            </div>
        </asp:Panel>

    </div>
</asp:Content>
