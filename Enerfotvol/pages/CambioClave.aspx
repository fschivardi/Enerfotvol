<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CambioClave.aspx.cs" Inherits="Enerfotvol.pages.CambioClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal-body">
        <div class="form-group">
        <asp:Label ID="lblClaveActual" runat="server" Text="Clave Actual"></asp:Label>
        <asp:TextBox ID="txtClaveActual" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtClaveActual" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtClave" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblConfirmacion" runat="server" Text="Confirmación Clave"></asp:Label>
        <asp:TextBox ID="txtClave2" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtClave2" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator 
                ID="comparaClaveConfirmacion" Operator="Equal" runat="server"
                ValidationGroup="Nuevo" ControlToValidate="txtClave"  
                ControlToCompare="txtClave2" ErrorMessage="Las contraseñas no coinciden" SetFocusOnError="true" >
        </asp:CompareValidator>
        </div>
    </div>
    <div class="modal-footer">
        <asp:Label ID="lblMensajes" runat="server" Text="" CssClass="alert alert-info" Visible="false" ></asp:Label>
        <asp:Button ID="btnGuardar" runat="server" Text="Cambiar Clave" OnClick="btnGuardar_Click" CssClass="btn btn-success"  ValidationGroup="Nuevo" />
        
    </div>
</asp:Content>
