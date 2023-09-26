<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateEmployeeInfo.aspx.cs" Inherits="AziendaEdile.UpdateEmployeeInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modifica Dipendente</h1>
            
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>

            <asp:HiddenField ID="ID_Hidden" runat="server" />
            
            <asp:TextBox ID="Nome_Input" runat="server" placeholder="Nome" CssClass="form-control" /><br />
            <asp:TextBox ID="Cognome_Input" runat="server" placeholder="Cognome" CssClass="form-control" /><br />
            <asp:TextBox ID="Indirizzo_Input" runat="server" placeholder="Indirizzo" CssClass="form-control" /><br />
            <asp:TextBox ID="CodiceFiscale_Input" runat="server" placeholder="Codice Fiscale" CssClass="form-control" /><br />
            <asp:CheckBox ID="Coniugato_Input" runat="server" Text="Coniugato" /><br />
            <asp:TextBox ID="NumeroFigli_Input" runat="server" placeholder="Numero Figli" CssClass="form-control" /><br />
            <asp:TextBox ID="Mansione_Input" runat="server" placeholder="Mansione" CssClass="form-control" /><br />
            
            <asp:Button ID="btnSalva" runat="server" Text="Salva Modifiche" OnClick="btnSalva_Click" CssClass="btn btn-danger" />

</asp:Content>
