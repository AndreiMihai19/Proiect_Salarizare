<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="main-div" style="top:20px">
        <h3>Ghid Utilizator</h3>
        <p>Acest ghid ofera informatii despre functionalitatile disponibile in aplicatie.</p>

        <h4>1. HOME</h4>
        <p>Aceasta sectiune ofera informatii ajutatoare despre modul de operare al aplicatiei. Navigati aici pentru a intelege cum sa utilizati platforma in mod eficient.</p>

        <h4>2. Actualizare date</h4>
        <p>Permite actualizarea informatiilor pentru angajati, precum nume, salariu de baza, sporuri, bonusuri si alte retineri.</p>
        <ul>
            <li>Actualizare pentru un angajat: utilizati functia de cautare pentru a selecta angajatul dorit.</li>
            <li>Actualizare pentru mai multi angajati: aplicati modificarile simultan pentru o lista selectata de angajati.</li>
            <li>Editarea valorilor se poate face manual. </li>
        </ul>

        <h4>3. Adaugare angajati</h4>
        <p>Adaugati un angajat nou completand datele necesare. </p>

        <h4>4. Stergere angajati</h4>
        <p>Gasiti si stergeti angajatii dupa Nume sau Prenume.</p>

        <h4>5. Stat plata</h4>
        <p>Generati statul de plata si Exportati documentul in format PDF pentru printare sau pastrare.</p>

        <h4>6. Fluturasi</h4>
        <p>Genereaza si tipareste fluturasi de salariu pentru angajati pentru intreaga companie.</p>

        <h4>7. Modificare impozit</h4>
        <p>Daca doriti sa schimbati valorile de la impozit, puteti sa faceti acest lucru accesand aceasta sectiune (pentru a putea modifica valorile, este necesara parola!).</p>
    </div>
</asp:Content>

