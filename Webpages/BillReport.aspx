﻿<%@ Page Title="Bill Report" Language="C#" MasterPageFile="~/Webpages/AdminMaster.master" AutoEventWireup="true" CodeFile="BillReport.aspx.cs" Inherits="Webpages_BillReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
</asp:Content>