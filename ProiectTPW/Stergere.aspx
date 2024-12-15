<%@ Page Title="Stergere date" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Stergere.aspx.cs" Inherits="Stergere" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="page_style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="main-div">
         <div style="text-align: center;">
                <h1>Stergere</h1>
         </div>
        <div class="search-form">
             <h3>Cautare angajat</h3>
             <asp:Label ID="lblName" runat="server" Text="Nume si Prenume:" />
             <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
             <br />
             <div class="button-style">
                 <asp:Label ID="errorMessage" runat="server" CssClass="lbl-message" Height="16px" />
                 <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Cautare" />
             </div>
             <br />
        </div>

        <br />
        <br />

         <asp:GridView ID="GridView1" runat="server" CssClass="gridview" AutoGenerateColumns="False" Visible="false" OnRowCommand="GridView1_RowCommand"  DataKeyNames="NrCrt">
            <Columns>
                <asp:BoundField DataField="NrCrt" HeaderText="Nr Crt" />
                <asp:BoundField DataField="Nume" HeaderText="Nume" />
                <asp:BoundField DataField="Prenume" HeaderText="Prenume" />
                <asp:BoundField DataField="Functie" HeaderText="Functie" />
                <asp:BoundField DataField="SalarBaza" HeaderText="Salar Baza" />
                <asp:BoundField DataField="Spor" HeaderText="Spor" />
                <asp:BoundField DataField="PremiiBrute" HeaderText="Premii Brute" />
                <asp:BoundField DataField="Retineri" HeaderText="Retineri" />
                <asp:BoundField DataField="Total_Brut" HeaderText="Total Brut" />
                <asp:BoundField DataField="Brut_Impozabil" HeaderText="Brut Impozabil" />
                <asp:BoundField DataField="CAS" HeaderText="CAS" />
                <asp:BoundField DataField="CASS" HeaderText="CASS" />
                <asp:BoundField DataField="Impozit" HeaderText="Impozit" />
                <asp:BoundField DataField="Virat_Card" HeaderText="Virat Card" />
                <asp:TemplateField HeaderText="Poza">
                    <ItemTemplate>
                       <asp:Image ID="imgPoza" runat="server" CssClass = "img-tumbnail" 
                                  ImageUrl='<%# Eval("Poza")%>' AlternateText= "Angajatul nu are imagine" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ControlStyle-CssClass="delete-button"  ButtonType="Button" HeaderText="Actiune" ControlStyle-Font-Bold="true" Text="Sterge" CommandName="RequestDelete"/>                
            </Columns>
        </asp:GridView>

    <asp:Panel ID="OverlayPanel" runat="server" CssClass="overlay" Visible="false"/>
        <asp:Panel ID="ConfirmationPanel" runat="server" CssClass="confirmation-modal button-style" Visible="false">
            <asp:Label ID="ConfirmationMessage" runat="server" Text="Sigur doriți să ștergeți acest angajat?" />
            <br />
            <br />
            <asp:Button ID="ConfirmDeleteButton" runat="server" Text="Da" OnClick="ConfirmDelete_Click" CssClass="button-style" />
            <asp:Button ID="CancelDeleteButton" runat="server" Text="Nu" OnClick="CancelDelete_Click" CssClass="button-style" />
            <asp:HiddenField ID="HiddenNrCrtToDelete" runat="server" />
        </asp:Panel>
    
    </div>


 

</asp:Content>

