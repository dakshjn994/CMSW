<%@ Page Title="Insert Product" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Webpages_Admin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <div class="text-center">
    <h1 style="margin-left:20px">Insert New Product</h1>
    <br /><br />
    <div style="margin-left:20px">Name<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtName" ToolTip="Enter Name" Text="*" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator> : <br />
        <asp:TextBox ID="txtName" runat="server" CssClass="input-sm" placeholder="Enter Fabric Name"/></div><br />
    <div style="margin-left:20px">Description<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtareaDES" ToolTip="Enter Description" Text="*" runat="server" ErrorMessage="Enter Description"></asp:RequiredFieldValidator> : <br /> 
        <textarea id="txtareaDES" runat="server" style="height:125px;width:200px;" class="input-sm" placeholder="Enter Description of the Fabric" ></textarea></div><br />
    <div style="margin-left:20px">Price<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtPrice" ToolTip="Enter Price" Text="*" runat="server" ErrorMessage="Enter Price"></asp:RequiredFieldValidator> : <br />
        <asp:TextBox ID="txtPrice" placeholder="Enter Fabric Price" CssClass="input-sm" runat="server" /></div><br />
    <div style="margin-left:20px">Image : 
        <asp:FileUpload ID="FileImage" runat="server" CssClass="center-block" /></div><br />
    <asp:CheckBox ID="CheckBox1" runat="server" style="margin-left:20px"/>&nbsp;&nbsp;Do you want to Display this product on cart ?<br />
    <div><asp:Label ID="lblStatus" style="margin-left:20px;color:blue;" runat="server" Text="" /></div><br />
       <asp:Button ID="btnNext" style="margin-left:20px;" OnClick="btnNext_Click" runat="server" Text="Add" CausesValidation="true" CssClass="btn btn-primary" />
        <div><asp:Image ID="imgProduct" style="margin-left:20px" Height="250" Width="250" runat="server" /></div><br />
        </div>
    <ajaxToolkit:FilteredTextBoxExtender FilterType="Numbers, Custom" ValidChars=".1234567890" FilterMode="ValidChars" TargetControlID="txtPrice" ID="FilteredTextBoxExtender1" runat="server" />
</asp:Content>