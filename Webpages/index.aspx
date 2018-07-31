<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Webpages_Home" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server"> 
        <ContentTemplate>
    <br /><br />
            <div class="container">
  <br/>
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
    <li data-target="#myCarousel" data-slide-to="3"></li>
  </ol>
  <div class="carousel-inner"  role="listbox">
      <%--<div style="height:352px" class="item active">
     
    </div>--%>
      <div class="item active">
      <img src="../Slideshow/9.jpg" class="img-rounded" style="width:1000px;height:350px" alt="Chania"/>
    </div>
      <div class="item">
      <img src="../Slideshow/6.jpg" class="img-rounded" style="width:1000px;height:350px" alt="Flower"/>
    </div>
      <div class="item">
      <img src="../Slideshow/7.jpg" class="img-rounded" style="width:1000px;height:350px" alt="Flower"/>
    </div>
      <div class="item">
      <img src="../Slideshow/8.jpg" class="img-rounded" style="width:1000px;height:350px" alt="Flower"/>
    </div>
  </div>
</div>
  <!-- Left and right controls -->
  <a class="left carousel-control img-circle" href="#myCarousel" style="height:25px;width:25px;margin-left:145px;margin-top:300px" role="button" data-slide="prev">
      <asp:Image ID="Image2" runat="server" CssClass="img-circle" ImageUrl="~/Img/success-previous-button.png" AlternateText="<" />
  </a>
  <a class="right carousel-control img-circle" href="#myCarousel" style="height:25px;width:25px;margin-right:200px;margin-top:300px;" role="button" data-slide="next">
      <asp:Image ID="Image1" runat="server" CssClass="img-circle" ImageUrl="~/Img/success-next-button.png" AlternateText=">" /></a>
    </div>
    <br /><br />
    <div class="container">
        <div class="jumbotron" style="margin-right:95px">
            <h2>Vallabh Innovation Cloth Merchants at the Centre of Cloth Making since 1998</h2>
            <p>We Manufacture , Sell and Export Coudroy , Knitted Blended , Knitted Woven , Knitted Cotton , Woolen and Woven Fabrics and we also sell Woolen Blankets and Shawls. We are cloth merchants based in Lower Parel (Maharashtra). The company offers an impressive collection of high quality cloth. All of our cloth can be purchased online or by contacting us</p>
            <center><a href="Main.aspx" class="btn btn-default">Shop Now</a>&nbsp&nbsp<a href="Contact.aspx" class="btn btn-primary">Contact Us</a></center>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
            <h3>Vallabh Innovation is a growing Company</h3>
            <p>Vallabh Innovation is a Company that was established in 1998 by Mr. Rajesh And Rakesh Jain.Vallabh Innovation is a leading Manufacturer & Supplier of Corduroy fabrics ,knitted blended fabric,knitted cotton fabric from Mumbai</p>
            <a href="#" class="btn btn-default">Read More</a>
                </div>
            <div class="col-md-3">
            <h3>Show us your support and help us grow</h3>
            <p>Vallabh Innovation is a Company that was established by keeping excellence in mind and is still developing</p>
            <a href="#" class="btn btn-default">Read More</a>
        </div>
            <div class="col-md-3">
            <h3>Reveiw us on Justdial</h3>
            <p>if you have been our customer please rate your experience on our Website or our personnel</p>
            <a href="#" class="btn btn-default">Read More</a>
        </div>
            </div>
      </div>
            </ContentTemplate>
         </asp:UpdatePanel>
    <br /><br />
</asp:Content>