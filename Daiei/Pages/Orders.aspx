<%@ Page Title=".:ТаБи.мн:. Илгээмжүүд" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Daiei.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container">
            <h1>Бүртгэгдсэн илгээмж</h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column twelvecol">
        <div class="element-title indented">
            <h1>Бүртгэгдсэн илгээмжүүд</h1>
        </div>
        <telerik:RadGrid ID="grdPackages" runat="server" PageSize="20" AllowSorting="True"
            AllowPaging="true" ShowGroupPanel="false" AutoGenerateColumns="False" CellSpacing="0" GridLines="None"
            ShowFooter="True" AllowFilteringByColumn="true" Skin="MetroTouch"
            OnItemCommand="grdPackages_ItemCommand">
            <PagerStyle FirstPageToolTip="Эхний хуудас руу үсрэх" LastPageToolTip="Сүүлийн хуудас руу үсрэх"
                NextPagesToolTip="Дараагийн хуудас руу үсрэх" NextPageToolTip="Дараагийн хуудас руу үсрэх"
                PagerTextFormat="Change page: {4} &nbsp; <strong>Нийт: {5}</strong> хуудас: <strong>{0}</strong>/<strong>{1}</strong>, <strong>{2}</strong> ээс <strong>{3}</strong>. "
                PageSizeLabelText="Хуудсанд:" Mode="NextPrev" />
            <MasterTableView ClientDataKeyNames="ID" NoMasterRecordsText="Жагсаалт хоосон."
                CommandItemDisplay="None" Height="100%" HierarchyDefaultExpanded="true" ShowHeadersWhenNoRecords="true" TableLayout="Auto" AutoGenerateColumns="false">
                <Columns>
                    <telerik:GridBoundColumn DataField="MBno" HeaderText="Илгээмжийн #" ShowFilterIcon="false"
                        CurrentFilterFunction="Contains" FilterControlWidth="95%" AutoPostBackOnFilter="true" Aggregate="Count" FooterText="Нийт: ">
                        <FooterStyle HorizontalAlign="Left" Width="120px" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CreatedDate" HeaderText="Огноо" ShowFilterIcon="false"
                        CurrentFilterFunction="Contains" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StatusName" HeaderText="Төлөв" ShowFilterIcon="false"
                        CurrentFilterFunction="Contains" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="MFee" HeaderText="Төлбөр" ShowFilterIcon="false"
                        CurrentFilterFunction="StartsWith" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rOrderNumber" HeaderText="Order #" ShowFilterIcon="false"
                        CurrentFilterFunction="StartsWith" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rOrderTrackingNumber" HeaderText="Tracking #" ShowFilterIcon="false"
                        CurrentFilterFunction="StartsWith" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rItemsCount" HeaderText="Нийт бараа" ShowFilterIcon="false"
                        CurrentFilterFunction="StartsWith" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="70px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="..." DataField="ID" ShowFilterIcon="false"
                        SortExpression="ID" CurrentFilterFunction="NoFilter" AutoPostBackOnFilter="false" AllowFiltering="false">
                        <HeaderStyle HorizontalAlign="Center" Width="105px" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" Height="30px" />
                        <ItemTemplate>
                            <a href="Check.aspx?v=<%# Eval("MBno")%>" class="btn btn-primary btn-sm" type="button" target="_blank" style="color: white;">Дэлгэрэнгүй</a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                <Scrolling AllowScroll="true" UseStaticHeaders="false" ScrollHeight="" />
            </ClientSettings>
        </telerik:RadGrid>
    </div>
</asp:Content>
