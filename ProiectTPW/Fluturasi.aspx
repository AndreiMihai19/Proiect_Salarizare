<%@ Page Title="Fluturasi" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Fluturasi.aspx.cs" Inherits="Fluturasi" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="page_style.css" rel="stylesheet" type="text/css" />
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="main-div">
           <asp:Button ID="btnGenerateForAll" CssClass="generate-button" runat="server" OnClick="btnGenerateForAll_Click" Text="Genereaza pentru toti" />
           <h3>Introduceti numele si prenumele angajatului</h3>
             <asp:Label ID="lblGenerate" runat="server" Text="Nume si Prenume:" />
             <asp:TextBox ID="txtNumePrenume" runat="server"></asp:TextBox>
             <br />
         <br />
             <asp:Button ID="btnGenerateForOne" runat="server" CssClass="generate-button" OnClick="btnGenerateForOne_Click" Text="Genereaza pentru un angajat"/>
             <br />
            <asp:Label ID="statusMessage" runat="server" CssClass="lbl-message" Height="16px" />
           <br />
           <br />
           <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
     </div>
</asp:Content>

