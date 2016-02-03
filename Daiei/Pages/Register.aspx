<%@ Page Title=".:ТаБи.мн:. Бүртгүүлэх" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Daiei.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container" runat="server">
            <h1><%= Resources.Resource.UserRegister %></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="column eightcol">
        <div class="element-title" runat="server">
            <h1><%= Resources.Resource.UserRegister %></h1>
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
                    <telerik:RadTextBox runat="server" ID="txtRUserCode" Width="100%" placeholder="<%$ Resources:Resource, NewTabiID %>" Enabled="false"></telerik:RadTextBox>
                </div>
            </div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRFirstName"
                        ErrorMessage="<%$ Resources:Resource, LastName %>" CssClass="Validator" ValidationGroup="Register">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRFirstName" Width="100%" placeholder="<%$ Resources:Resource, LastName %>"></telerik:RadTextBox>
                </div>
            </div>
            <div class="column sixcol last">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRLastName"
                        ErrorMessage="<%$ Resources:Resource, UserName %>" CssClass="Validator" ValidationGroup="Register">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRLastName" Width="100%" placeholder="<%$ Resources:Resource, UserName %>"></telerik:RadTextBox>
                </div>
            </div>
            <div class="clear"></div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtREmail"
                        ErrorMessage="<%$ Resources:Resource, EnterEmail %>" CssClass="Validator" ValidationGroup="Register">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailValidator" runat="server"
                        ErrorMessage="<%$ Resources:Resource, EnterEmail %>" CssClass="Validator"  ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                        ControlToValidate="txtREmail" ValidationGroup="Register">
                    </asp:RegularExpressionValidator>
                    <telerik:RadTextBox runat="server" ID="txtREmail" Width="100%" placeholder="<%$ Resources:Resource, Email %>"></telerik:RadTextBox>
                </div>
            </div>
            <div class="clear"></div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="valPass1" runat="server" ControlToValidate="txtRPassword"
                        ErrorMessage="<%$ Resources:Resource, Password %>" CssClass="Validator" ValidationGroup="Register">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRPassword" Width="100%" placeholder="<%$ Resources:Resource, Password %>" TextMode="Password"></telerik:RadTextBox>
                </div>
            </div>
            <div class="column sixcol last">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="valPass2" runat="server" ControlToValidate="txtRPasswordValid"
                        ErrorMessage="<%$ Resources:Resource, ConfirmationPassword %>" CssClass="Validator" ValidationGroup="Register">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRPasswordValid" Width="100%" placeholder="<%$ Resources:Resource, ConfirmationPassword %>" TextMode="Password"></telerik:RadTextBox>
                </div>
            </div>
            <div class="clear"></div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRMNPhone"
                        ErrorMessage="<%$ Resources:Resource, PhoneMongolia %>" CssClass="Validator" ValidationGroup="Register">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                    <telerik:RadNumericTextBox ID="txtRMNPhone" runat="server" MaxValue="99999999" MinValue="10000"
                        EmptyMessage="" MaxLength="8" CssClass="RadTextBox" placeholder="<%$ Resources:Resource, PhoneMongolia %>"
                        Width="100%">
                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                    </telerik:RadNumericTextBox>
                </div>
            </div>
            <div class="column sixcol last">
                <div class="field-wrap">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRMNAddress"
                        ErrorMessage="<%$ Resources:Resource, AddressMongolia %>" CssClass="Validator" ValidationGroup="Register">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                    <telerik:RadTextBox runat="server" ID="txtRMNAddress" Width="100%" placeholder="<%$ Resources:Resource, AddressMongolia %>"></telerik:RadTextBox>
                </div>
            </div>
            <div class="clear"></div>
            <div class="column sixcol">
                <div class="field-wrap">
                    <telerik:RadNumericTextBox ID="txtRJPPhone" runat="server" MaxValue="9999999999999" MinValue="10000"
                        EmptyMessage="" MaxLength="13" CssClass="RadTextBox" placeholder="<%$ Resources:Resource, PhoneJapan %>"
                        Width="100%">
                        <NumberFormat DecimalDigits="0" GroupSeparator="-" GroupSizes="3" />
                    </telerik:RadNumericTextBox>
                </div>
            </div>
            <div class="column sixcol last">
                <div class="field-wrap">
                    <telerik:RadTextBox runat="server" ID="txtRJPAddress" Width="100%" placeholder="<%$ Resources:Resource, AddressJapan %>"></telerik:RadTextBox>
                </div>
            </div>
            <asp:Button ID="btnRegister" CssClass="element-button primary" ValidationGroup="Register" Text="<%$ Resources:Resource, UserRegister %>" runat="server" OnClick="btnRegister_Click" />
        </div>
    </div>
    <div class="column fourcol last">
        <div class="element-title" runat="server">
            <h1><%= Resources.Resource.Login %></h1>
        </div>
        <div class="site-form element-form">
            <div class='field-wrap'>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLEmail"
                    ErrorMessage="<%$ Resources:Resource, EnterEmail %>" CssClass="Validator" ValidationGroup="Llogin">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                <telerik:RadTextBox runat="server" ID="txtLEmail" placeholder='Имэйл' Width="100%"></telerik:RadTextBox>
            </div>
            <div class='field-wrap'>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLPassword"
                    ErrorMessage="<%$ Resources:Resource, Password %>" CssClass="Validator" ValidationGroup="Llogin">*<%= Resources.Resource.EnterValue %></asp:RequiredFieldValidator>
                <telerik:RadTextBox runat="server" ID="txtLPassword" placeholder='<%$ Resources:Resource, Password %>' Width="100%" TextMode="Password"></telerik:RadTextBox>
            </div>
            <asp:Button ID='btnLLogin' CssClass='element-button' Text='<%$ Resources:Resource, Login %>' runat='server' Style="margin-top: 10px" OnClick="btnLLogin_Click" ValidationGroup="Llogin" />
            <a style='padding: 8px 20px 8px 15px; margin-top: 10px;' href='#password_form' class='element-button element-colorbox square cboxElement' title='<%$ Resources:Resource, ForgotPassword %>' runat="server"><span class='fa fa-life-ring'></span></a>

        </div>
    </div>
    <div class="clear"></div>
</asp:Content>
