<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AziendaEdile.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <h2>Dipendenti</h2>
            <hr />
            <asp:GridView ID="GridViewDipendenti" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Cognome" HeaderText="Cognome" />
                    <asp:BoundField DataField="Indirizzo" HeaderText="Indirizzo" />
                    <asp:BoundField DataField="CodiceFiscale" HeaderText="Codice Fiscale" />
                    <asp:BoundField DataField="Coniugato" HeaderText="Coniugato" />
                    <asp:BoundField DataField="NumeroFigli" HeaderText="Numero Figli" />
                    <asp:BoundField DataField="Mansione" HeaderText="Mansione" />
                    <asp:TemplateField HeaderText="Azione">
            <ItemTemplate>
                <asp:Button ID="btnModifica" runat="server" Text="Modifica" CommandName="Modifica" CommandArgument='<%# Eval("ID") %>' OnClick="btnModifica_Click" CssClass="btn btn-danger" />
            </ItemTemplate>
        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col">
            <h2>Pagamenti</h2>
            <hr />
            <asp:GridView ID="GridViewPagamenti" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="IdPagamento" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Dipendente">
                        <ItemTemplate>
                            <%# Eval("NomeDipendente") + " " + Eval("CognomeDipendente") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PeriodoPagamento" HeaderText="Periodo Pagamento" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Ammontare" HeaderText="Ammontare" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>