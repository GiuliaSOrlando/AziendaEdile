<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterEmployee.aspx.cs" Inherits="AziendaEdile.RegisterEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Aggiungi Dipendente</h2>
    <hr />
    <div class="alert alert-danger" role="alert" runat="server" id="alertInserimento" visible="false">
        <asp:Label ID="lblMessaggio" runat="server" EnableViewState="false"></asp:Label>
    </div>
    <br />
    <div class="form-group">
        <asp:TextBox ID="Nome_Input" runat="server" placeholder="Nome" CssClass="form-control" />
        <br />
        <asp:TextBox ID="Cognome_Input" runat="server" placeholder="Cognome" CssClass="form-control" />

        <br />
        <asp:TextBox ID="Indirizzo_Input" runat="server" placeholder="Indirizzo" CssClass="form-control" />
        <br />
        <asp:TextBox ID="CF_Input" runat="server" placeholder="Codice fiscale" CssClass="form-control" />
        <br />
        <asp:CheckBox ID="Coniugato_Chk" runat="server" Text="Coniugato" />
        <br />
        <asp:TextBox ID="NumeroFigli_Input" runat="server" placeholder="Numero di figli" CssClass="form-control" />
        <br />
        <asp:TextBox ID="Mansione_Input" runat="server" placeholder="Mansione" CssClass="form-control" />
        <br />

        <asp:Button ID="RegisterEmployee_Button" runat="server" Text="Aggiungi dipendente" OnClick="RegisterEmployee_Button_Click" CssClass="btn btn-danger" />
    </div>
</asp:Content>
