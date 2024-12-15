<%@ Page Title="Actualizare date" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ActualizareDate.aspx.cs" Inherits="ActualizareDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="page_style.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .auto-style9 {
             width:100px;
         }
         .auto-style10 {
             width: 100px;
         }
     </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="main-div">
         <div style="text-align: center;">
                <h1>Actualizare date</h1>
         </div>
         <br />
       
         
            <div style="display: flex; justify-content: space-between; width: 100%;">

                <div class="search-form" >
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
            </div>

        <br />
        

            <div>
               <asp:GridView ID="gvAngajat" runat="server" CssClass="gridview" AutoGenerateColumns="False" Visible="false" DataKeyNames="NrCrt"  AutoGenerateEditButton="True" OnRowEditing="gvActualizare_RowEditing" 
              OnRowUpdating="gvActualizare_RowUpdating" OnRowCancelingEdit="gvActualizare_RowCancelingEdit" >
                   
                    <Columns>
                       <asp:BoundField DataField="NrCrt" HeaderText="ID" ReadOnly="True"/>

                        <asp:TemplateField HeaderText="Nume" >
                            <ItemTemplate>
                                <%# Eval("Nume") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="50px" ID="txtNume" runat="server" Text='<%# Bind("Nume") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prenume">
                            <ItemTemplate>
                                <%# Eval("Prenume") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="50px" ID="txtPrenume" runat="server" Text='<%# Bind("Prenume") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Functie">
                            <ItemTemplate>
                                <%# Eval("Functie") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="50px" ID="txtFunctie" runat="server" Text='<%# Bind("Functie") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Salar Baza">
                            <ItemTemplate>
                                <%# Eval("SalarBaza") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="50px" ID="txtSalarBaza" runat="server" Text='<%# Bind("SalarBaza") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Spor">
                            <ItemTemplate>
                                <%# Eval("Spor") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="30px" ID="txtSpor" runat="server" Text='<%# Bind("Spor") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Premii Brute">
                            <ItemTemplate>
                                <%# Eval("PremiiBrute") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="30px" ID="txtPremiiBrute" runat="server" Text='<%# Bind("PremiiBrute") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Retineri">
                            <ItemTemplate>
                                <%# Eval("Retineri") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="30px"  ID="txtRetineri" runat="server" Text='<%# Bind("Retineri") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="total_brut" HeaderText="Total Brut" ReadOnly="True"/>
                        <asp:BoundField DataField="cas" HeaderText="CAS" ReadOnly="True"/>
                        <asp:BoundField DataField="cass" HeaderText="CASS" ReadOnly="True"/>
                        <asp:BoundField DataField="impozit" HeaderText="Impozit" ReadOnly="True"/>
                        <asp:BoundField DataField="brut_impozabil" HeaderText="Brut Impozabil" ReadOnly="True"/>
                        <asp:BoundField DataField="virat_card" HeaderText="Virat Card" ReadOnly="True"/>

                     

                    </Columns>
                </asp:GridView>

            </div>


       
         

        <br />
        <br />
        
        

         <div style="text-align: center;">
                <h1>Angajatii companiei</h1>
         </div>
         <br />

        <div>
               <asp:GridView ID="gvAngajati" runat="server" CssClass="gridview" AutoGenerateColumns="False" Visible="true" DataKeyNames="NrCrt"  AutoGenerateEditButton="True" OnRowEditing="gvActualizareAngajati_RowEditing" 
              OnRowUpdating="gvActualizareAngajati_RowUpdating" OnRowCancelingEdit="gvActualizareAngajati_RowCancelingEdit" >
                   
                    <Columns>
                       <asp:BoundField DataField="NrCrt" HeaderText="ID" ReadOnly="True"/>

                        <asp:TemplateField HeaderText="Nume" >
                            <ItemTemplate>
                                <%# Eval("Nume") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="50px" ID="txtNumeAng" runat="server" Text='<%# Bind("Nume") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prenume">
                            <ItemTemplate>
                                <%# Eval("Prenume") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="50px" ID="txtPrenumeAng" runat="server" Text='<%# Bind("Prenume") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Functie">
                            <ItemTemplate>
                                <%# Eval("Functie") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="50px" ID="txtFunctieAng" runat="server" Text='<%# Bind("Functie") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Salar Baza">
                            <ItemTemplate>
                                <%# Eval("SalarBaza") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="50px" ID="txtSalarBazaAng" runat="server" Text='<%# Bind("SalarBaza") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Spor">
                            <ItemTemplate>
                                <%# Eval("Spor") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="30px" ID="txtSporAng" runat="server" Text='<%# Bind("Spor") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Premii Brute">
                            <ItemTemplate>
                                <%# Eval("PremiiBrute") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="30px" ID="txtPremiiBruteAng" runat="server" Text='<%# Bind("PremiiBrute") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Retineri">
                            <ItemTemplate>
                                <%# Eval("Retineri") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="30px"  ID="txtRetineriAng" runat="server" Text='<%# Bind("Retineri") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="total_brut" HeaderText="Total Brut" ReadOnly="True"/>
                        <asp:BoundField DataField="cas" HeaderText="CAS" ReadOnly="True"/>
                        <asp:BoundField DataField="cass" HeaderText="CASS" ReadOnly="True"/>
                        <asp:BoundField DataField="impozit" HeaderText="Impozit" ReadOnly="True"/>
                        <asp:BoundField DataField="brut_impozabil" HeaderText="Brut Impozabil" ReadOnly="True"/>
                        <asp:BoundField DataField="virat_card" HeaderText="Virat Card" ReadOnly="True"/>
                        <asp:TemplateField HeaderText="Poza">
                            <ItemTemplate>
                                <asp:Image ID="imgPoza" runat="server" CssClass = "img-tumbnail" 
                                    ImageUrl='<%# Eval("Poza")%>' AlternateText= "Angajatul nu are imagine" />
                            </ItemTemplate>
                        </asp:TemplateField>
                

           
                    </Columns>
                </asp:GridView>

            </div>



        </div>

</asp:Content>

