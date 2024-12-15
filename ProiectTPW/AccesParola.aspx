<%@ Page Title="Modificare Impozit" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AccesParola.aspx.cs" Inherits="AccesParola" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="page_style.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:Panel ID="passwordPanel" runat="server" Visible="true" CssClass="password-modal button-style">
        <h3>Introduceti parola pentru a modifica impozitul</h3>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Parola" CssClass="password-input" />
        <asp:Button ID="btnSubmitPassword" runat="server" Text="Trimite" CssClass="button-style" ForeColor="white" OnClick="btnSubmitPassword_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Anulează" CssClass="button-style" ForeColor="white" OnClick="btnCancel_Click" />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false" Text="Parola este incorectă."></asp:Label>
    </asp:Panel>
</asp:Content>


