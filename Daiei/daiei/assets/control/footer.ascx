<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="Daiei.assets.control.footer" %>

<footer class="site-footer container">
    <div class="site-copyright left">
        DAIEI PROBIS MONGOL LLC &copy;
        <asp:Label runat="server" ID="lblYear"></asp:Label>
    </div>
    <nav class="footer-menu right">
        <div class="menu-footer-menu-container">
            <ul id="menu-footer-menu" class="menu">
                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="Home.aspx">Нүүр</a></li>
                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="Check.aspx">Төлөв шалгах</a></li>
                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="Calculate.aspx">Илгээмж тооцоолох</a></li>
                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="Policy.aspx">Үйлчилгээний нөхцөл</a></li>
                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="Instruction.aspx">Ашиглах заавар</a></li>
            </ul>
        </div>
    </nav>
</footer>
<!-- /footer -->
