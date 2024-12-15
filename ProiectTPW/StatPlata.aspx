<%@ Page Title="Stat de plata" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="StatPlata.aspx.cs" Inherits="StatPlata" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="page_style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="main-div">
          <asp:Button ID="btnGenerateForAll" CssClass="generate-button" runat="server" OnClick="btnGenerate_Click" Text="Genereaza raport" />
         <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" Height="1202px" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" ToolPanelView="None" />
    </div>
 


    
</asp:Content>

