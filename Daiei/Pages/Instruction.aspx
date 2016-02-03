<%@ Page Title=".:ТаБи.мн:. Ашиглах заавар" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Instruction.aspx.cs" Inherits="Daiei.Instruction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="site-title">
        <div class="container" runat="server">
            <h1><%= Resources.Resource.Guideline %></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="element-title" runat="server">
        <h1>Манай системийг хэрхэн ашиглах вэ?</h1>
    </div>
    <div class="column twelvecol">
        <img src="../assets/img/screenshot.gif">
    </div>
    <div class="clear"></div>
</asp:Content>
