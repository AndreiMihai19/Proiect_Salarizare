<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Adaugare.aspx.cs" Inherits="Adaugare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <title>Adăugare Angajat</title>
    <link href="page_style.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .auto-style9 {
             height: 413px;
         }
         .auto-style10 {
             height: 413px;
         }
         .auto-style12 {
             border-radius: 2px;
             box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
             width: 25%;
             font-size: 13px;
             font-weight: bold;
             height: 413px;
             padding: 10px;
             background: #fff;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     
    <table style="width:100%; background-color:white; height:455px">
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style12">
                    <h2>Adăugare Angajat</h2>
                    <div class="form-group">
                        <asp:Label ID="lblNume" runat="server" AssociatedControlID="txtNume">Nume:</asp:Label>
                        <asp:TextBox ID="txtNume" runat="server" CssClass="input-form" />
                        <asp:RequiredFieldValidator ID="rfvNume" runat="server" 
                            ControlToValidate="txtNume" ErrorMessage="Numele este obligatoriu!" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblPrenume" runat="server" AssociatedControlID="txtPrenume">Prenume:</asp:Label>
                        <asp:TextBox ID="txtPrenume" runat="server" CssClass="input-form" />
                        <asp:RequiredFieldValidator ID="rfvPrenume" runat="server" 
                            ControlToValidate="txtPrenume" ErrorMessage="Prenumele este obligatoriu!" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblFunctie" runat="server" AssociatedControlID="txtFunctie">Funcție:</asp:Label>
                        <asp:TextBox ID="txtFunctie" runat="server" CssClass="input-form" />
                          <asp:RequiredFieldValidator ID="rfvFunctie" runat="server" 
                            ControlToValidate="txtFunctie" ErrorMessage="Functia este obligatorie!" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblSalarBaza" runat="server" AssociatedControlID="txtSalarBaza">Salariu de Bază:</asp:Label>
                        <asp:TextBox ID="txtSalarBaza" runat="server" CssClass="input-form" />
                        <asp:RequiredFieldValidator ID="rfvSalarBaza" runat="server" 
                            ControlToValidate="txtSalarBaza" ErrorMessage="Salar baza este obligatoriu!" Display="Dynamic" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                          <asp:RegularExpressionValidator ID="revSalarBaza" runat="server" 
                            ControlToValidate="txtSalarBaza" ErrorMessage="Doar valori numerice!" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div class="form-group">
                        <asp:Label ID="lblSpor" runat="server" AssociatedControlID="txtSpor">Spor (%):</asp:Label>
                        <asp:TextBox ID="txtSpor" runat="server" Value="0" CssClass="input-form" />
                        <asp:RangeValidator ID="rvSpor" runat="server"
                            ControlToValidate="txtSpor" ErrorMessage="Valoare prea mare (0-100)" Type="Integer" MaximumValue="100" MinimumValue="0" ForeColor="Red"></asp:RangeValidator> 
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblPremiiBrute" runat="server" AssociatedControlID="txtPremiiBrute">Premii Brute:</asp:Label>
                        <asp:TextBox ID="txtPremiiBrute" Value="0" runat="server" CssClass="input-form" />
                        <br />
                          <asp:RegularExpressionValidator ID="revPremiiBrute" runat="server" 
                            ControlToValidate="txtPremiiBrute" ErrorMessage="Doar valori numerice!" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblRetineri" runat="server" AssociatedControlID="txtRetineri">Retineri:</asp:Label>
                        <asp:TextBox ID="txtRetineri" runat="server" Value="0" CssClass="input-form" />
                        <br />
                          <asp:RegularExpressionValidator ID="revRetineri" runat="server" 
                            ControlToValidate="txtRetineri" ErrorMessage="Doar valori numerice!" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblPoza" runat="server" AssociatedControlID="filePoza">Poza:</asp:Label>
                        <asp:FileUpload ID="filePoza" runat="server" CssClass="input-form" />
                    </div>
                    <div class="button-style">
                        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reseteaza" ValidationGroup="Reset" CssClass="btn-primary" />
                        <asp:Button ID="btnAdauga" runat="server" OnClick="btnAdauga_Click" Text="Adauga" CssClass="btn-primary" />
                    </div>

            </td>
            <td class="auto-style9"></td>
        </tr>
    </table>

     
</asp:Content>

