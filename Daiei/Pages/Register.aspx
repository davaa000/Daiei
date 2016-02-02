<%@ Page Title=".:ТаБи.мн:. Бүртгүүлэх" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Daiei.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container">
            <h1>Бүртгүүлэх</h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column eightcol">
        <div class="element-title">
            <h1>Бүртгүүлэх</h1>
        </div>
        <div class="site-form element-form">
            <div class="column twelvecol">
                <div class="field-wrap">
                    <textarea rows="7" cols="50" readonly>Үйлчилгээний нөхцөл

1. Хууль хяналтын байгууллагын албан ёсны шаардлага баримт дээр үндэслэн хамтран ажиллаж байгаа нөхцөлөөс бусад ямар ч нөхцөлд мэдээллийн нууцыг бусдад дамжуулахгүй чандлан хадгална.

2. Хууль хяналтын байгууллагын албан ёсны шаардлага баримт дээр үндэслэн хамтран ажиллаж байгаа нөхцөлөөс бусад ямар ч нөхцөлд мэдээллийн нууцыг бусдад дамжуулахгүй чандлан хадгална.

3. Хууль хяналтын байгууллагын албан ёсны шаардлага баримт дээр үндэслэн хамтран ажиллаж байгаа нөхцөлөөс бусад ямар ч нөхцөлд мэдээллийн нууцыг бусдад дамжуулахгүй чандлан хадгална.

4. Хууль хяналтын байгууллагын албан ёсны шаардлага баримт дээр үндэслэн хамтран ажиллаж байгаа нөхцөлөөс бусад ямар ч нөхцөлд мэдээллийн нууцыг бусдад дамжуулахгүй чандлан хадгална.
					    </textarea>
                </div>
            </div>
            <div class="column twelvecol">
                <div class="field-wrap">
                    <telerik:RadTextBox runat="server" ID="txtRUserCode" Width="100%" placeholder="Хэрэглэгчийн код (Бүртгэлийн дараа олгоно)" Enabled="false"></telerik:RadTextBox>
                </div>
            </div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRFirstName"
                        ErrorMessage="Эцэг/эх/-ийн нэр" CssClass="Validator" ValidationGroup="Register">*Утга оруул</asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRFirstName" Width="100%" placeholder="Эцэг/эх/-ийн нэр"></telerik:RadTextBox>
                </div>
            </div>
            <div class="column sixcol last">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRLastName"
                        ErrorMessage="Нэр" CssClass="Validator" ValidationGroup="Register">*Утга оруул</asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRLastName" Width="100%" placeholder="Нэр"></telerik:RadTextBox>
                </div>
            </div>
            <div class="clear"></div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtREmail"
                        ErrorMessage="Имэйл" CssClass="Validator" ValidationGroup="Register">*Утга оруул</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailValidator" runat="server"
                        ErrorMessage="Имэйл хаягаа зөв оруулна уу" CssClass="Validator"  ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                        ControlToValidate="txtREmail" ValidationGroup="Register">
                    </asp:RegularExpressionValidator>
                    <telerik:RadTextBox runat="server" ID="txtREmail" Width="100%" placeholder="Имэйл хаяг"></telerik:RadTextBox>
                </div>
            </div>
            <div class="clear"></div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="valPass1" runat="server" ControlToValidate="txtRPassword"
                        ErrorMessage="Нууц үг" CssClass="Validator" ValidationGroup="Register">*Утга оруул</asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRPassword" Width="100%" placeholder="Нууц үг" TextMode="Password"></telerik:RadTextBox>
                </div>
            </div>
            <div class="column sixcol last">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="valPass2" runat="server" ControlToValidate="txtRPasswordValid"
                        ErrorMessage="Нууц үг баталгаажуулах" CssClass="Validator" ValidationGroup="Register">*Утга оруул</asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRPasswordValid" Width="100%" placeholder="Нууц үг баталгаажуулах" TextMode="Password"></telerik:RadTextBox>
                </div>
            </div>
            <div class="clear"></div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRMNPhone"
                        ErrorMessage="Утасны дугаар (Монгол)" CssClass="Validator" ValidationGroup="Register">*Утга оруул</asp:RequiredFieldValidator>
                    <telerik:RadNumericTextBox ID="txtRMNPhone" runat="server" MaxValue="99999999" MinValue="10000"
                        EmptyMessage="" MaxLength="8" CssClass="RadTextBox" placeholder="Утас (Монгол)"
                        Width="100%">
                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                    </telerik:RadNumericTextBox>
                </div>
            </div>
            <div class="column sixcol last">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRMNAddress"
                        ErrorMessage="Хаяг (Монгол)" CssClass="Validator" ValidationGroup="Register">*Утга оруул</asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRMNAddress" Width="100%" placeholder="Хаяг (Монгол)"></telerik:RadTextBox>
                </div>
            </div>
            <div class="clear"></div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <telerik:RadNumericTextBox ID="txtRJPPhone" runat="server" MaxValue="9999999999999" MinValue="10000"
                        EmptyMessage="" MaxLength="13" CssClass="RadTextBox" placeholder="Утас (Япон)"
                        Width="100%">
                        <NumberFormat DecimalDigits="0" GroupSeparator="-" GroupSizes="3" />
                    </telerik:RadNumericTextBox>
                </div>
            </div>
            <div class="column sixcol last">
                <div class="field-wrap">
                    <telerik:RadTextBox runat="server" ID="txtRJPAddress" Width="100%" placeholder="Хаяг (Япон)"></telerik:RadTextBox>
                </div>
            </div>
            <asp:Button ID="btnRegister" CssClass="element-button primary" ValidationGroup="Register" Text="Бүртгүүлэх" runat="server" OnClick="btnRegister_Click" />
        </div>
    </div>
    <div class="column fourcol last">
        <div class="element-title">
            <h1>Нэвтрэх</h1>
        </div>
        <div class="site-form element-form">
            <div class='field-wrap'>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLEmail"
                    ErrorMessage="Имэйл хаяг" CssClass="Validator" ValidationGroup="Llogin">*Утга оруул</asp:RequiredFieldValidator>
                <telerik:RadTextBox runat="server" ID="txtLEmail" placeholder='Имэйл' Width="100%"></telerik:RadTextBox>
            </div>
            <div class='field-wrap'>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLPassword"
                    ErrorMessage="Нууц үг" CssClass="Validator" ValidationGroup="Llogin">*Утга оруул</asp:RequiredFieldValidator>
                <telerik:RadTextBox runat="server" ID="txtLPassword" placeholder='Нууц үг' Width="100%" TextMode="Password"></telerik:RadTextBox>
            </div>
            <asp:Button ID='btnLLogin' CssClass='element-button' Text='Нэвтрэх' runat='server' Style="margin-top: 10px" OnClick="btnLLogin_Click" ValidationGroup="Llogin" />
            <a style='padding: 8px 20px 8px 15px; margin-top: 10px;' href='#password_form' class='element-button element-colorbox square cboxElement' title='Нууц үг мартсан'><span class='fa fa-life-ring'></span></a>

        </div>
    </div>
    <div class="clear"></div>
</asp:Content>
