<%@ Page Title=".:ТаБи.мн:. Илгээмж тооцоолох" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Calculate.aspx.cs" Inherits="Daiei.Calculate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container">
            <h1>Илгээмж тооцоолох</h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column twelvecol">
        <div class="element-title indented">
            <h1>Тооцоолуур</h1>
        </div>
        <div class="site-form">
            <table class="item-form" style="margin-bottom: 40px;">
                <tbody>
                    <tr>
                        <th>Жин (кг)</th>
                        <th>Урт (см)</th>
                        <th>Өргөн (см)</th>
                        <th>Өндөр (см)</th>
                        <th></th>
                    </tr>
                    <tr>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadNumericTextBox ID="txtJin" runat="server" MaxValue="9999"
                                    placeholder="0.00" MaxLength="10" CssClass="RadTextBox"
                                    Width="100%">
                                    <NumberFormat DecimalDigits="3" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtJin"
                                    ErrorMessage="Жин" CssClass="Validator">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadNumericTextBox ID="txtUrt" runat="server" MaxValue="999999" MinValue="1"
                                    placeholder="0.00" MaxLength="10" CssClass="RadTextBox"
                                    Width="100%">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrt"
                                    ErrorMessage="Урт" CssClass="Validator">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadNumericTextBox ID="txtUrgun" runat="server" MaxValue="999999" MinValue="1"
                                    placeholder="0.00" MaxLength="10" CssClass="RadTextBox"
                                    Width="100%">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUrgun"
                                    ErrorMessage="Өргөн" CssClass="Validator">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            <div class="field-wrap">
                                <telerik:RadNumericTextBox ID="txtUndur" runat="server" MaxValue="999999" MinValue="1"
                                    placeholder="0.00" MaxLength="10" CssClass="RadTextBox"
                                    Width="100%">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUrt"
                                    ErrorMessage="Өндөр" CssClass="Validator">*</asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            <asp:Button ID="btnCalculate" CssClass="element-button" Text="Тооцоолох" runat="server" OnClick="btnCalculate_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="column eightcol">
        </div>
        <div class="column fourcol last">
            <table class="profile-fields" style="font-size: 20px;">
                <tbody>
                    <tr>
                        <th>Зардал</th>
                        <td>
                            <asp:Label runat="server" ID="lblPayment">0</asp:Label>
                            ¥
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
