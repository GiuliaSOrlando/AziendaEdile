<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterPayment.aspx.cs" Inherits="AziendaEdile.RegisterPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registra Pagamento</h2>
    <hr />
    <div class="alert alert-danger" id="alertInserimento" role="alert" runat="server" visible="false">
        <asp:Label ID="lblMessaggio" runat="server" EnableViewState="false"></asp:Label>
    </div>
    <br />
    <asp:DropDownList ID="ddlDipendenti" runat="server" DataTextField="NomeCognome" DataValueField="ID" CssClass="form-control"></asp:DropDownList><br />
    <asp:TextBox ID="periodopagamento_Input" runat="server" placeholder="Periodo di Pagamento (AAAA-MM-GG)" CssClass="form-control" /><br />
    <asp:TextBox ID="ammontare_Input" runat="server" placeholder="Ammontare" CssClass="form-control" /><br />
    <asp:DropDownList ID="ddlTipoPagamento" runat="server" CssClass="form-control">
        <asp:ListItem Text="Stipendio" Value="Stipendio" />
        <asp:ListItem Text="Acconto" Value="Acconto" />
    </asp:DropDownList><br />
    <asp:Button ID="RegisterPayment_Button" runat="server" Text="Registra Pagamento" OnClick="RegisterPayment_Button_Click" CssClass="btn btn-danger" />
</asp:Content>
