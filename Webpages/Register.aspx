<%@ Page Title="Register" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Webpages_Register" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <style>
        .dang
        {
            float:right;
        }
    </style>
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>
<%--    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtMNo').keypress(function (key) {
                if (key.charCode < 48 || key.charCode > 57)
                    return false;
            });
            $('.name').keypress(function (key) {
                if ((key.charCode < 97 || key.charCode > 122) && (key.charCode < 65 || key.charCode > 90) && (key.charCode != 45)) return false;
            });
            function preventBack() { window.history.forward(); }
            setTimeout("preventBack()", 10);
            window.onunload = function () { null };
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    &nbsp;&nbsp;&nbsp;<h1 class="Contact text-center container">Register New User</h1><br />
        <div class="text-center">
   <%--<br /><br /><br /><br /><br /><br /><br />--%>
    &nbsp;&nbsp;&nbsp; First Name<asp:RegularExpressionValidator ID="revFName" ForeColor="Red" runat="server" Text="*" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtFName" ValidationGroup="validate" ValidationExpression="^[a-zA-Z]*$" ToolTip="Special Characters not allowed in Name" ErrorMessage="No Special Characters in First Name"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="rfvFName" runat="server" ErrorMessage="First Name  Required" ToolTip="Please Enter First Name" ControlToValidate="txtFName" Text="*" Display="Dynamic" SetFocusOnError="True" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator> &nbsp; :<br />
&nbsp;&nbsp;&nbsp; <asp:TextBox runat="server" ID="txtFName"  AutoCompleteType="Disabled"  placeholder="Enter First Name" CssClass=" input-sm" EnableViewState="True" ClientIDMode="Static"  ValidationGroup="validate"></asp:TextBox>&nbsp;
        <br /><br />
    &nbsp;&nbsp;&nbsp; Middle Name<asp:RegularExpressionValidator ID="revMName" runat="server" Text="*" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtMName" ValidationGroup="validate" ValidationExpression="^[a-zA-Z]*$" ToolTip="Special Characters not allowed in Name" ErrorMessage="No Special Characters in Middle Name" ForeColor="Red"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="rfvMName" runat="server" ErrorMessage="Middle Name Required" ControlToValidate="txtMName" SetFocusOnError="True" ToolTip="Please Enter Middle Name" ValidationGroup="validate" Display="Dynamic" Text="*" ForeColor="Red"></asp:RequiredFieldValidator> &nbsp; :<br />
&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtMName"  CssClass=" input-sm"  AutoCompleteType="Disabled"  placeholder="Enter Middle Name" runat="server" EnableViewState="True" ValidationGroup="validate"></asp:TextBox>
    <br /><br />
    &nbsp;&nbsp;&nbsp; Last Name<asp:RegularExpressionValidator ID="revLName" runat="server" Text="*" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtLName" ValidationGroup="validate" ValidationExpression="^[a-zA-Z]*$" ToolTip="Special Characters not allowed in Name" ErrorMessage="No Special Characters in Last Name" ForeColor="Red"></asp:RegularExpressionValidator> <asp:RequiredFieldValidator ID="rfvLName" runat="server" ErrorMessage="Last Name Required" SetFocusOnError="True" Display="Dynamic" Text="*" ControlToValidate="txtLName" ValidationGroup="validate" ToolTip="Please Enter Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
    &nbsp; :<br />
&nbsp;&nbsp; <asp:TextBox ID="txtLName" class=" input-sm"  AutoCompleteType="Disabled"  placeholder="Enter Last Name" runat="server" EnableViewState="True" ValidationGroup="validate" SetFocusOnError="True"></asp:TextBox>
    <br /><br />
    Address<asp:RequiredFieldValidator ID="rfvAddress" ValidationGroup="validate" ControlToValidate="txtAddress" runat="server" ErrorMessage="Address Required" Text="*" Display="Dynamic" SetFocusOnError="true" ToolTip="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator> &nbsp; :
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtAddress" placeholder="Enter Address" ValidationGroup="validate" AutoCompleteType="Disabled" CssClass="input-sm" runat="server"></asp:TextBox><br /><br />
    &nbsp;&nbsp;&nbsp; Street Name<asp:RequiredFieldValidator ID="rfvStreet" ValidationGroup="validate" ControlToValidate="txtStreet" runat="server" ErrorMessage="Street Required" Text="*" Display="Dynamic" SetFocusOnError="true" ToolTip="Please Enter Street" ForeColor="Red"></asp:RequiredFieldValidator> &nbsp;:
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtStreet" placeholder="Enter Street Name" ValidationGroup="validate" AutoCompleteType="Disabled" CssClass="input-sm" runat="server"></asp:TextBox><br /><br />
    &nbsp;&nbsp;&nbsp; Taluka<asp:RequiredFieldValidator ValidationGroup="validate" ControlToValidate="txtTaluka" runat="server" ErrorMessage="Taluka Required" Text="*" Display="Dynamic" SetFocusOnError="true" ToolTip="Please Enter Taluka" ForeColor="Red"></asp:RequiredFieldValidator> &nbsp;:<br />
&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTaluka" ValidationGroup="validate" placeholder="Enter Taluka" AutoCompleteType="Disabled" CssClass="input-sm" runat="server"></asp:TextBox><br /><br />
    &nbsp;&nbsp;&nbsp; <%--Country&nbsp; :<br />
&nbsp;<asp:DropDownList ID="ddlCountry" CssClass="dropdown" runat="server" AutoPostBack="true" DataTextField="Country_name" DataValueField="Country_id" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList><br /><br />
    &nbsp;&nbsp;&nbsp;&nbsp; State&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp; <asp:DropDownList ID="ddlState" CssClass=" dropdown" runat="server" AutoPostBack="true" DataTextField="State_name" DataValueField="State_id" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList><br /><br />
    &nbsp;&nbsp;&nbsp; City&nbsp; :&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:DropDownList ID="ddlCity" CssClass="dropdown" runat="server" AutoPostBack="true" DataTextField="City_name" DataValueField="City_id"></asp:DropDownList><br /><br />--%>
            &nbsp;&nbsp;&nbsp; Mobile<asp:RequiredFieldValidator ID="rfvMNo" ValidationGroup="validate" ForeColor="Red" Text="*" ToolTip="Enter Mobile No." ControlToValidate="txtMNo" Display="Dynamic" runat="server" ErrorMessage="Mobile No is Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="*" ValidationExpression="^[0-9]{12}$" ErrorMessage="Enter Correct Phone Number" ToolTip="Enter Correct Phone Number" Display="Dynamic" ValidationGroup="validate" ControlToValidate="txtMNo" ForeColor="Red"></asp:RegularExpressionValidator>&nbsp; :<br /> 
    &nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="txtMNo" CssClass="input-sm"  AutoCompleteType="Disabled"  placeholder="Enter Mobile No." runat="server" TextMode="Phone" EnableViewState="False" MaxLength="12"></asp:TextBox>
    <br /><br />
    &nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp; Pincode<asp:RequiredFieldValidator ID="rfvPIN" ValidationGroup="validate" ControlToValidate="txtPIN" runat="server" ErrorMessage="PIN Required" Text="*" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ToolTip="Please Enter PIN"></asp:RequiredFieldValidator> &nbsp;:<br />
&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPIN" CssClass="input-sm" placeholder="Enter Pin code" runat="server" AutoCompleteType="Disabled"></asp:TextBox><br /><br />
    &nbsp;&nbsp;&nbsp; Email-id<asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="validate" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email Required" Text="*" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ToolTip="Please Enter Email"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ValidationGroup="validate" ControlToValidate="txtEmail" ErrorMessage="Incorrect Email Format" Text="*" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ToolTip="Please Enter Correct Format of Email"></asp:RegularExpressionValidator> &nbsp;:<br />
&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtEmail" CssClass="input-sm"  AutoCompleteType="Disabled"  placeholder="Enter Email" runat="server" EnableViewState="False"></asp:TextBox><br /><br />
    &nbsp;&nbsp;&nbsp; Password<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="validate" ControlToValidate="txtPasswd" runat="server" ErrorMessage="Password Required" Text="*" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ToolTip="Please Enter Password"></asp:RequiredFieldValidator> &nbsp;:<br />
&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPasswd" CssClass="input-sm"  AutoCompleteType="Disabled"  runat="server" placeholder="Enter Password" TextMode="Password" EnableViewState="False" ValidationGroup="validate"></asp:TextBox><br /><br />
    &nbsp;&nbsp;&nbsp; ReWrite Password<asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ControlToCompare="txtPasswd" ControlToValidate="txtRPassword" Text="*" runat="server" ToolTip="Passwords Dont Match" Display="Dynamic" ValidationGroup="validate" ErrorMessage="Passwords Dont Match"></asp:CompareValidator> : 
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtRPassword" AutoCompleteType="Disabled"  CssClass="input-sm" placeholder="Re-Enter Password" runat="server" TextMode="Password" EnableViewState="False"></asp:TextBox><br /><br /><br />
    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnRegister" CssClass="btn btn-default" runat="server" Text="Register" OnClick="btnRegister_Click" EnableViewState="False" ValidationGroup="validate" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click"/>&nbsp&nbsp&nbsp <br />
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="White" ShowSummary="false" style="margin-left:10px;float:left;" ShowMessageBox="true" CssClass="dang" runat="server" ValidationGroup="validate" /><br />
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtFName" FilterMode="ValidChars" FilterType="LowercaseLetters ,UppercaseLetters, Custom"  runat="server" />
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtMName" FilterMode="ValidChars" FilterType="LowercaseLetters ,UppercaseLetters, Custom"  runat="server" />
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtLName" FilterMode="ValidChars" FilterType="LowercaseLetters ,UppercaseLetters, Custom"  runat="server" />
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"  FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txtMNo" runat="server" />
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"  FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txtPIN" runat="server" />
        </div>
        </div>
</asp:Content>