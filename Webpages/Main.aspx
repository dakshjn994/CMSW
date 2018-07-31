<%@ Page Title="Shop" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Webpages_Main" EnableEventValidation="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <%--<script type="text/javascript"> 
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server"> 
        <ContentTemplate>
        <h1 style="margin:50px;align-items:center;align-content:center;color:ButtonShadow">Fabrics Available</h1>
      <asp:DataList ID="ItemList" runat="Server" CssClass="item" CaptionAlign="Right" style="margin-left:15%;" RepeatColumns="3" RepeatDirection="Horizontal">
       <ItemTemplate>
                       &nbsp&nbsp<asp:Image ID="Image1" Height="37.5%" Width="50%" CssClass="img-circle" ImageUrl='<%#Bind("Image")%>' runat="server" />
                       &nbsp&nbsp<div class="caption">
                           &nbsp&nbsp<h4>
                               <asp:Label ID="ufname" runat="server" Text='<%#Bind("Name") %>'></asp:Label></h4>
                           &nbsp&nbsp<p class="text-success">Rs:<asp:Label ID="ufprice" runat="server" Text='<%#Bind("Money") %>'></asp:Label></p>
                           &nbsp&nbsp<p>
                               <asp:Button ID="btnCart" CssClass="btn btn-primary" runat="Server" Text="Buy Now"  CommandArgument='<%# Eval("Id") %>' OnClick="btnCart_Click"/>
                               <asp:Button ID="btnVeiw" runat="server" CssClass="btn btn-danger" Text="Details" CommandArgument='<%# Eval("Id") %>' OnClick="btnView_Click"  />
                           </p><br />
           </div><br />
       </ItemTemplate>
           
   </asp:DataList><br />
            <asp:Label runat="server" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Content>