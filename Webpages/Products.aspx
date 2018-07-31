<%@ Page Title="Products" Language="C#" EnableEventValidation="false" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Webpages_Admin_Products" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-left:20px">
    <br /><br />
    <h1>Products</h1>
        <div class="text-center" style="float:right;margin-right:150px" >
        <h2 id="chng" runat="server">Change Products</h2>
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name :"></asp:Label><br />
        <asp:TextBox ID="txtName" CssClass="input-sm" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblPrice" runat="server" Text="Price :"></asp:Label><br />
        <asp:TextBox ID="txtMoney" CssClass="input-sm" runat="server"></asp:TextBox><br /><br />
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtMoney" FilterType="Numbers ,Custom" ValidChars=".1234567890" FilterMode="ValidChars" runat="server" />
            <asp:Label ID="lblMoney" runat="server" Text="Image :"></asp:Label><br />
        <asp:FileUpload ID="fuImage" CssClass="center-block" runat="server" /><br /><br />
            <asp:Button ID="btnUpload" OnClick="btnUpload_Click" CssClass="btn btn-warning btn-block" runat="server" Text="Upload" /><br /><br />
        <asp:TextBox ID="txtPath" CssClass="input-sm" Enabled="false" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblDesc" runat="server" Text="Description :"></asp:Label><br />
        <textarea id="taDescription" style="height:100px;width:150px;" runat="server"></textarea><br /><br />
        <asp:Image ID="imgProduct" CssClass=" img-rounded" Height="50" Width="50" runat="server" /><br /><br />
        <asp:Label ID="lblStatus" style="color:red;" runat="server" Text="Label"></asp:Label><br /><br />
        <asp:Button ID="btnChange" OnClick="btnChange_Click" CssClass="btn btn-block btn-primary" runat="server" Text="Change" /><br /><br />
        </div>
        <br />
    <asp:GridView ID="GridView1" AutoGenerateColumns="false" Width="600" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" EnableModelValidation="True"
                            CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowHeaderWhenEmpty="True" runat="server">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" Height="100px" Width="100px" ImageUrl='<%#Eval("Image")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Money" HeaderText="Cost" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" CssClass="btn btn-danger" OnClick="btnDelete_Click" CommandArgument='<%#Eval("Id")%>' runat="server" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit Item">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" OnClick="btnEdit_Click" CommandArgument='<%#Eval("Id") %>' CssClass="btn btn-success" runat="server" Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
        <asp:Button ID="btnDel" OnClick="btnDel_Click" runat="server" CssClass="btn btn-warning" Text="Show Deleted Products" /><asp:Button ID="btnShow" CssClass="btn btn-warning" OnClick="btnShow_Click" runat="server" Text="Hide Deleted Products" /><br /><br />
    <h2 id="noproducts" runat="server">Products Not Displayed on Cart</h2>
    <asp:GridView ID="GridView2" AutoGenerateColumns="false" Width="550" EmptyDataText="No Orders Deleted" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" EnableModelValidation="True"
                            CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowHeaderWhenEmpty="true" runat="server">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image2" Height="100px" Width="100px" ImageUrl='<%#Eval("Image")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Money" HeaderText="Cost" />
            <asp:TemplateField HeaderText="Add To Cart">
                <ItemTemplate>
                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click" CommandArgument='<%#Eval("Id")%>' runat="server" Text="Add" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit Item">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" OnClick="btnEdit_Click" CommandArgument='<%#Eval("Id") %>' CssClass="btn btn-success" runat="server" Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        
  </div>
</asp:Content>