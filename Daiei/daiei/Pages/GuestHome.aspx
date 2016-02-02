<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GuestHome.aspx.cs" Inherits="Daiei.GuestHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <div class="slider-wrap">
        <div class="element-slider header-slider" data-effect="slide" data-pause="0" data-speed="1000">
            <ul>
                <li>
                    <div class="container">
                        <p>
                            &nbsp;<br />
                            &nbsp;
                        </p>
                        <h1 class="aligncenter">Япон улсаас илгээмж хүргүүлэх
									<br />
                            хялбар боллоо.
                        </h1>
                        <p>&nbsp;</p>

                        <!-- /search -->
                        <p class="aligncenter">
                            <asp:TextBox ID="txtTrackingNumber" type="text" CssClass="check" placeholder="#tracking number" runat="server"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btnLogin" CssClass="element-button" Text="Төлөв шалгах" runat="server" OnClick="btnLogin_Click" />
                            <p>
                                &nbsp;<br />
                                &nbsp;<br />
                                &nbsp;<br />
                                &nbsp;<br />
                                <img class="aligncenter" src="../assets/img/slide-1.png" alt="" />
                            </p>
                        </p>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="fourcol column">
        <img class="aligncenter" src="../assets/img/icon-2.png" alt="" /><br />
        <h2 class="aligncenter alignvertical">Найдвартай үйлчилгээ</h2>
        <p class="aligncenter alignvertical">
            Японы цахим дэлгүүрүүдээс худалдан авсан таны бараа нэг бүрийг найдвартай хариуцлагатайгаар таны гар дээр хүргэх болно.
        </p>
    </div>
    <div class="fourcol column">
        <img class="aligncenter" src="../assets/img/icon-1.png" alt="" /><br />
        <h2 class="aligncenter alignvertical">Бусдад бэлэг барих</h2>
        <p class="aligncenter alignvertical">
            Та манай системийг ашиглан бусдад гэнэтийн бэлэг барих боломжтой.
        </p>
    </div>
    <div class="fourcol column last">
        <img class="aligncenter" src="../assets/img/icon-3.png" alt="" /><br />
        <h2 class="aligncenter alignvertical">Илгээмж хаана явааг хянах</h2>
        <p class="aligncenter alignvertical">
            Манай системийг ашигласнаар та өөрийн илгээмжээ хаана явж байгааг хянах бөгөөд гаалийн татвар хүргэлтийн зардал зэрэг төлбөрийн дэлгэрэнгүй мэдээллийг харах боломжтой.
        </p>
    </div>
    <div class="clear"></div>
    <br />
    &nbsp;<br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PreFooter" runat="server">
    <div class="section-wrap" style="padding-bottom: 100px;">
        <section class="site-content container">
            <div class="testimonials-slider element-slider" data-pause="0" data-speed="900">
                <ul>
                    <li>
                        <div class="testimonial">
                            <div class="testimonial-content">
                                <h1>Монголын дэлгүүрээс олддоггүй нарийн амтлагч хүнсний бүтээгдэхүүнийг<br />
                                    цаг алдалгүй шуурхай найдвартай хүргэж өгдөгт та бүхэнд талархал илэрхийлье.
                                </h1>
                            </div>
                            <div class="testimonial-details clearfix">
                                <div class="testimonial-image">
                                    <img width="150" height="150" src="../assets/css/images/avatar.png" class="fullwidth wp-post-image" alt="image-110" />
                                </div>
                                <div class="testimonial-author">А.Төгөлдөр, Сакура рестораны ахлах тогооч</div>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="testimonial">
                            <div class="testimonial-content">
                                <h1>Та бүхний ажилд өндрөөс өндөр амжилт хүсье.
                                </h1>
                            </div>
                            <div class="testimonial-details clearfix">
                                <div class="testimonial-image">
                                    <img width="150" height="150" src="../assets/css/images/avatar.png" class="fullwidth wp-post-image" alt="image-112" />
                                </div>
                                <div class="testimonial-author">Б.Долгор, Оюутан</div>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </section>
    </div>
</asp:Content>
