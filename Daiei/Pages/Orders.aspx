<%@ Page Title=".:ТаБи.мн:. Илгээмжүүд" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Daiei.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container" runat="server">
            <h1><%= Resources.Resource.PackageList %></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column twelvecol">
        <div class="element-title indented">
            <h1><%= Resources.Resource.PackageList %></h1>
        </div>
        <telerik:RadGrid ID="grdPackages" runat="server" PageSize="20" AllowSorting="True"
            AllowPaging="true" ShowGroupPanel="false" AutoGenerateColumns="False" CellSpacing="0" GridLines="None"
            ShowFooter="True" AllowFilteringByColumn="true" Skin="MetroTouch"
            OnItemCommand="grdPackages_ItemCommand">
            <PagerStyle FirstPageToolTip="<%$ Resources:Resource, FirstPage %>" LastPageToolTip="<%$ Resources:Resource, LastPage %>"
                NextPagesToolTip="<%$ Resources:Resource, NextPage %>" NextPageToolTip="<%$ Resources:Resource, NextPage %>"
                PagerTextFormat="<%$ Resources:Resource, ChangePage %>: {4} &nbsp; <strong><%$ Resources:Resource, Page %>: {5}</strong> <%$ Resources:Resource, Page %>: <strong>{0}</strong>/<strong>{1}</strong>, <strong>{2}</strong> - <strong>{3}</strong>. "
                PageSizeLabelText="Хуудсанд:" Mode="NextPrev" />
            <MasterTableView ClientDataKeyNames="ID" NoMasterRecordsText="<%$ Resources:Resource, EmptyList %>"
                CommandItemDisplay="None" Height="100%" HierarchyDefaultExpanded="true" ShowHeadersWhenNoRecords="true" TableLayout="Auto" AutoGenerateColumns="false">
                <Columns>
                    <telerik:GridBoundColumn DataField="MBno" HeaderText="<%$ Resources:Resource, PackageTabiNo %>" ShowFilterIcon="false"
                        CurrentFilterFunction="Contains" FilterControlWidth="95%" AutoPostBackOnFilter="true" Aggregate="Count" FooterText="<%$ Resources:Resource, Total %>">
                        <FooterStyle HorizontalAlign="Left" Width="120px" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CreatedDate" HeaderText="<%$ Resources:Resource, Date %>" ShowFilterIcon="false"
                        CurrentFilterFunction="Contains" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StatusName" HeaderText="<%$ Resources:Resource, PackageStatus %>" ShowFilterIcon="false"
                        CurrentFilterFunction="Contains" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="MFee" HeaderText="<%$ Resources:Resource, Payment %>" ShowFilterIcon="false"
                        CurrentFilterFunction="StartsWith" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rOrderNumber" HeaderText="<%$ Resources:Resource, OrderNo %>" ShowFilterIcon="false"
                        CurrentFilterFunction="StartsWith" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rOrderTrackingNumber" HeaderText="<%$ Resources:Resource, OrderTrackingNo %>" ShowFilterIcon="false"
                        CurrentFilterFunction="StartsWith" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rItemsCount" HeaderText="<%$ Resources:Resource, TotalItem %>" ShowFilterIcon="false"
                        CurrentFilterFunction="StartsWith" FilterControlWidth="95%" AutoPostBackOnFilter="true">
                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="70px" Font-Bold="true" ForeColor="Black" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="..." DataField="ID" ShowFilterIcon="false"
                        SortExpression="ID" CurrentFilterFunction="NoFilter" AutoPostBackOnFilter="false" AllowFiltering="false">
                        <HeaderStyle HorizontalAlign="Center" Width="105px" />
                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" Height="30px" />
                        <ItemTemplate>
                            <a href="Check.aspx?v=<%# Eval("MBno")%>" class="btn btn-primary btn-sm" type="button" target="_blank" style="color: white;" > <%= Resources.Resource.Description %> </a>
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
