﻿<%@ Page Title=".:ТаБи.мн:. Захиалга хийх" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="Daiei.AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container" runat="server">
            <h1 class="aligncenter"><%=Resources.Resource.Package %>					
            </h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="RAM_RContentPage" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnSave" LoadingPanelID="loadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnCancel" LoadingPanelID="loadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdListItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdListItems" LoadingPanelID="loadingPanel" />
                    <telerik:AjaxUpdatedControl ControlID="txtPackageSumRate" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAddItem" LoadingPanelID="loadingPanel" />
                    <telerik:AjaxUpdatedControl ControlID="txtItemBrand" />
                    <telerik:AjaxUpdatedControl ControlID="txtItemCount" />
                    <telerik:AjaxUpdatedControl ControlID="txtItemName" />
                    <telerik:AjaxUpdatedControl ControlID="txtItemRate" />
                    <telerik:AjaxUpdatedControl ControlID="txtPackageSumRate" />
                    <telerik:AjaxUpdatedControl ControlID="grdListItems" LoadingPanelID="loadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lbCheckUser">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lstUserList" LoadingPanelID="loadingPanel" />
                    <telerik:AjaxUpdatedControl ControlID="txtReciveName" LoadingPanelID="loadingPanel" />
                    <telerik:AjaxUpdatedControl ControlID="txtRecivePhone" LoadingPanelID="loadingPanel" />
                    <telerik:AjaxUpdatedControl ControlID="txtReciveAddress" LoadingPanelID="loadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="column twelvecol">
        <div class="element-title indented">
            <h1>
                <asp:Label runat="server" ID="lblPageHeader" Text="<%$ Resources:Resource, PackageRegister %>"></asp:Label></h1>
        </div>
        <div class="column twelvecol">
            <div class="widget widget-slider sidebar-widget">
                <div class="widget-title" runat="server">
                    <h4><%=Resources.Resource.Package %> (<%= Resources.Resource.PackageStatus %>:
                        <asp:Label runat="server" ID="lblPackageStatus"></asp:Label>)</h4>
                </div>
                <div class="site-form">
                    <div class="message">
                    </div>
                    <table class="profile-fields order-form-table" runat="server">
                        <tbody>
                            <tr>
                                <th><%= Resources.Resource.CreatedUser %></th>
                                <th><%= Resources.Resource.OrderCustomer %></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lbCheckUser" runat="server" OnClick="lbCheckUser_Click" Style="display: none;"
                                        CausesValidation="false"></asp:LinkButton>
                                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                        <script type="text/javascript">
                                            function onChangeTextRad(sender, eventArgs) {
                                                if (sender.get_value() == "") {
                                                    //alert('Жагсаалтанд байхгүй утга байна');
                                                    sender.set_text('');
                                                }
                                                else {
                                                    __doPostBack('ctl00$ContentPlaceHolder1$lbCheckUser', '');
                                                }
                                            }
                                        </script>
                                    </telerik:RadCodeBlock>
                                    <telerik:RadComboBox ID="lstUserList" runat="server" Width="100%" Height="250px" EmptyMessage="<%$ Resources:Resource, EnterValue %>" AllowCustomText="true"
                                        Filter="Contains" MarkFirstMatch="true" EnableLoadOnDemand="True" ShowMoreResultsBox="True"
                                        EnableVirtualScrolling="True" OnClientTextChange="onChangeTextRad" OnClientDropDownClosed="onChangeTextRad" OnClientSelectedIndexChanged="onChangeTextRad"
                                        OnItemsRequested="lstUserList_ItemsRequested" class="form-control" Skin="MetroTouch">
                                        <CollapseAnimation Type="None" />
                                        <ExpandAnimation Type="None" />
                                        <Items>
                                            <telerik:RadComboBoxItem />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="val_lstAddress" runat="server" ErrorMessage="<%$ Resources:Resource,  PackageUser%>"
                                        ControlToValidate="lstUserList">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="txtReciveOrderName" Width="100%" EmptyMessage="<%$ Resources:Resource, OrderName %>"></telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReciveOrderName"
                                        ErrorMessage="<%$ Resources:Resource, OrderCustomer %>" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th><%= Resources.Resource.PackageReciever %></th>

                                <th><%= Resources.Resource.OrderNo %></th>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="txtReciveName" Width="100%" EmptyMessage="<%$ Resources:Resource, FillFullName %>"></telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReciveName"
                                        ErrorMessage="<%$ Resources:Resource, LastName %>" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtReciveOrderNumber" runat="server" MaxValue="99999999" MinValue="10000"
                                        EmptyMessage="<%$ Resources:Resource, EnterValue %>" MaxLength="20" CssClass="RadTextBox"
                                        Width="100%">
                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtReciveOrderNumber"
                                        ErrorMessage="<%$ Resources:Resource, OrderNo %>" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th><%= Resources.Resource.AddressMongolia %></th>
                                <th><%= Resources.Resource.OrderTrackingNo %></th>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="txtReciveAddress" Width="100%" EmptyMessage="<%$ Resources:Resource, SampleMongolianAddress %>"></telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReciveAddress"
                                        ErrorMessage="" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="txtReciveOrderTrack" Width="100%" EmptyMessage="<%$ Resources:Resource, PostalTrackingNumber %>"></telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtReciveOrderTrack"
                                        ErrorMessage="" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th><%= Resources.Resource.PhoneMongolia %></th>
                                <th><%= Resources.Resource.WebSite %> (URL)</th>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtRecivePhone" runat="server" MaxValue="99999999" MinValue="10000"
                                        EmptyMessage="" MaxLength="8" CssClass="RadTextBox"
                                        Width="100%">
                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRecivePhone"
                                        ErrorMessage="" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="txtReciveOrderSite" Width="100%" EmptyMessage="<%$ Resources:Resource, SampleOrderWebSite %>"></telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReciveOrderSite"
                                        ErrorMessage="" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th colspan="2"><%= Resources.Resource.PackageDescription %></th>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadTextBox runat="server" ID="txtDescription" Width="100%" EmptyMessage="<%$ Resources:Resource, PackageDescriptionWorker %>"></telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="val_description" runat="server" ControlToValidate="txtDescription"
                                        ErrorMessage="" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="column twelvecol">
            <div class="widget widget-slider sidebar-widget">
                <div class="widget-title" runat="server">
                    <h4><%= Resources.Resource.EnterItems %></h4>
                </div>
                <div class="site-form">
                    <table class="item-form" runat="server">
                        <tbody>
                            <tr>
                                <th><%= Resources.Resource.ItemName %></th>
                                <th><%= Resources.Resource.ItemBrand %></th>
                                <th><%= Resources.Resource.ItemCount %></th>
                                <th><%= Resources.Resource.ItemUnitPrice %></th>
                                <th></th>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="txtItemName" Width="100%" placeholder="iphone5, .... "></telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtItemName"
                                        ErrorMessage="" CssClass="Validator" ValidationGroup="listItems">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="txtItemBrand" Width="100%" placeholder="apple, nike, sony... "></telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtItemBrand"
                                        ErrorMessage="" CssClass="Validator" ValidationGroup="listItems">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtItemCount" runat="server" MaxValue="9999" MinValue="0"
                                        placeholder="" MaxLength="4" CssClass="RadTextBox"
                                        Width="100%">
                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtItemCount"
                                        ErrorMessage="" ValidationGroup="listItems" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtItemRate" runat="server" MaxValue="99999999" MinValue="0"
                                        placeholder="" MaxLength="9" CssClass="RadTextBox"
                                        Width="100%">
                                        <NumberFormat DecimalDigits="2" GroupSeparator="" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtItemRate"
                                        ErrorMessage="" ValidationGroup="listItems" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnAddItem" runat="server" Text="<%$ Resources:Resource, Add %>" type="button" class="btn btn-primary" OnClick="btnUploadPic_Click" ValidationGroup="listItems" Style="float: left; margin-right: 10px; margin-top: -17px" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <telerik:RadGrid ID="grdListItems" AutoGenerateColumns="False" AllowPaging="false" runat="server" GridLines="None" Skin="MetroTouch" ShowFooter="True" OnItemCommand="grdList_ItemCommand" AllowAutomaticDeletes="true">
                        <MasterTableView CommandItemDisplay="None" Height="100%" NoMasterRecordsText="<%$ Resources:Resource, EmptyList %>" ShowHeadersWhenNoRecords="true" HierarchyDefaultExpanded="true" TableLayout="Auto" AutoGenerateColumns="false">
                            <Columns>
                                <telerik:GridBoundColumn ReadOnly="true" HeaderText="<%$ Resources:Resource, ItemName %>" DataField="NAME" UniqueName="NAME" Aggregate="Count" FooterText="Нийт: ">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="30px" />
                                    <FooterStyle HorizontalAlign="Left" Width="130px" Font-Size="11px" ForeColor="Black" Font-Bold="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn ReadOnly="true" HeaderText="<%$ Resources:Resource, ItemBrand %>" DataField="BRAND"
                                    UniqueName="BRAND">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Font-Bold="true" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn ReadOnly="true" HeaderText="<%$ Resources:Resource, ItemCount %>" DataField="ITEMCOUNT"
                                    UniqueName="ITEMCOUNT">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="90px" Font-Bold="true" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn ReadOnly="true" HeaderText="<%$ Resources:Resource, ItemUnitPrice %>" DataField="ITEMRATE"
                                    UniqueName="ITEMRATE">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="100px" Font-Bold="true" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn ReadOnly="true" HeaderText="<%$ Resources:Resource, ItemTotalPrice %>" DataField="ITEMRATESUM"
                                    UniqueName="ITEMRATESUM">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="100px" Font-Bold="true" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn Text="<%$ Resources:Resource, Delete %>" UniqueName="DeleteColumn" HeaderText="..." CommandName="Delete">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="80px" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" ForeColor="#d43f3a" Font-Bold="true" />
                                </telerik:GridButtonColumn>
                            </Columns>
                            <CommandItemSettings ShowExportToWordButton="false" ShowExportToExcelButton="false"
                                ShowExportToCsvButton="false" ShowExportToPdfButton="false" ShowAddNewRecordButton="false"
                                ShowRefreshButton="false" ShowCancelChangesButton="false" />
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
        <div class="column twelvecol">
            <div class="column sixcol"></div>
            <div class="column sixcol last">
                <table class="profile-fields" runat="server">
                    <tbody>
                        <tr>
                            <th><%= Resources.Resource.SalesTax %></th>
                            <td>
                                <div class="field-wrap">
                                    <telerik:RadNumericTextBox ID="txtPackageTax" runat="server" MaxValue="99999999" MinValue="0"
                                        EmptyMessage="тоогоор" MaxLength="9" CssClass="RadTextBox"
                                        Width="100%">
                                        <NumberFormat DecimalDigits="2" GroupSeparator="" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPackageTax"
                                        ErrorMessage="Sales tax ¥" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th><%= Resources.Resource.Shipping %></th>
                            <td>
                                <div class="field-wrap">
                                    <telerik:RadNumericTextBox ID="txtPackageShipping" runat="server" MaxValue="99999999" MinValue="0"
                                        EmptyMessage="тоогоор" MaxLength="9" CssClass="RadTextBox"
                                        Width="100%">
                                        <NumberFormat DecimalDigits="2" GroupSeparator="" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPackageShipping"
                                        ErrorMessage="Shipping ¥" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th><%= Resources.Resource.Discount %></th>
                            <td>
                                <div class="field-wrap">
                                    <telerik:RadNumericTextBox ID="txtPackageDiscount" runat="server" MaxValue="99999999" MinValue="0"
                                        EmptyMessage="тоогоор" MaxLength="9" CssClass="RadTextBox"
                                        Width="100%">
                                        <NumberFormat DecimalDigits="2" GroupSeparator="" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtPackageDiscount"
                                        ErrorMessage="Discount ¥" CssClass="Validator">*</asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th><%= Resources.Resource.OrderTotalAmount %></th>
                            <td>
                                <div class="field-wrap">
                                    <telerik:RadTextBox runat="server" ID="txtPackageSumRate" Width="100%" placeholder="" Enabled="false"></telerik:RadTextBox>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="column twelvecol">
            <div class="textright order-form-buttons">
                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Resource, PackageConfirmation %>" class="element-button primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:Resource, PackageCancellation %>" class="element-button" CausesValidation="false" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
