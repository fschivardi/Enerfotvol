<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="TipoProducto.aspx.cs" Inherits="Enerfotvol.pages.TipoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            
        
        <div style="margin-left: 40px">
        <asp:Label ID="lblTipoProd" runat="server" Text="Tipo de Productos"></asp:Label>
        <br />
        <br />        
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>            
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>

        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Crear" OnClick="btnCrear_Click" CssClass="w-30 btn btn-lg btn-primary" />
        <br />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="w-30 btn btn-lg btn-primary"/>
        <br />
        <asp:GridView ID="dgvTipoProd" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="dgvBitacora_PageIndexChanging" CssClass="table table-condensed table-hover" OnRowEditing="dgvTipoProd_RowEditing" OnRowCancelingEdit="dgvTipoProd_RowCancelingEdit" OnRowDeleting="dgvTipoProd_RowDeleting" OnRowUpdating="dgvTipoProd_RowUpdating" DataKeyNames="Id,Descripcion" >
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <Columns>
                <asp:BoundField DataField="Id" ReadOnly="true" />
                <asp:BoundField DataField="Descripcion" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>        
    </div>
        </div>
</asp:Content>
