<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="Daiei.assets.control.footer" %>

<footer class="site-footer container">
    <div class="site-copyright left">
        <%=Resources.Resource.Copyright %> &copy 2016
        <asp:Label runat="server" ID="lblYear"></asp:Label>
    </div>
    <nav class="footer-menu right">
        <div class="menu-footer-menu-container">
            <ul id="menu-footer-menu" class="menu">
                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="Policy.aspx"><%=Resources.Resource.TermsOfService%>/a></li>
                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="Instruction.aspx"><%=Resources.Resource.Guideline %></a></li>
            </ul>
        </div>
    </nav>
</footer>
<!-- /footer -->
