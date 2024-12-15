<%@ Page Title="Modificare Impozit" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ModificareImpozit.aspx.cs" Inherits="ModificareImpozit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="main-div">
         <div style="text-align: center;">
                <h1>Modificare impozit</h1>
         </div>
         <br />
        <asp:GridView ID="gvSalarizare" runat="server" AutoGenerateColumns="False" CssClass="gridview" 
              AutoGenerateEditButton="True" OnRowEditing="gvSalarizare_RowEditing" 
              OnRowUpdating="gvSalarizare_RowUpdating" OnRowCancelingEdit="gvSalarizare_RowCancelingEdit">
    <Columns>
        <asp:TemplateField HeaderText="CAS">
            <ItemTemplate>
                <%# Eval("cas") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCAS" runat="server" Text='<%# Bind("cas") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="CASS">
            <ItemTemplate>
                <%# Eval("cass") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCASS" runat="server" Text='<%# Bind("cass") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="IMPOZIT">
            <ItemTemplate>
                <%# Eval("impozit") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtIMPOZIT" runat="server" Text='<%# Bind("impozit") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


     </div>
</asp:Content>

