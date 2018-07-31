<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OrderRefrenceInfo.aspx.cs" Inherits="Webpages_OrderRefrenceInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container" style="margin-top: -20px;">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Your Order Details
                </h1>
                <ol class="breadcrumb">
                    <li><a href="PlaceOrder.aspx">Go back to Products</a>
                    </li>
                    <%-- <li class="active">Procedure</li>--%>
                </ol>
            </div>
        </div>
    <img runat="server" id="imgCheck" src="~/images/check.png" /> <asp:Literal runat="server"  id="ltrDone" Text="" ></asp:Literal><br />
    
    <div align="center">
        <table style="width: 100%">
            <tr>
                <td>
                    <div id="divOrderInfo" runat="server"></div>
                </td>
            </tr>

        </table>
    </div>
    <br />
    <div>
        <asp:Button ID="btnConfirm"   OnClick="btnConfirm_Click" runat="server" Text="Confirm"  class="btn btn-primary" /> 
    </div></div>
</asp:Content>

