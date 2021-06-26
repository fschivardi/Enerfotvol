<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NoAutorizado.aspx.cs" Inherits="Enerfotvol.pages.NoAutorizado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
          <div class="row">
               <div class="col-md-2 text-center">
                    <p><i class="fa fa-exclamation-triangle fa-5x"></i><br/>Acceso Denegado</p>
               </div>
               <div class="col-md-10">
                    <h3>No Autorizado</h3>
                    <p>Su usuario no cuenta con los privilegios necesarios para acceder a esta página.<br/>Por favor, vuelva a la página anterior para seguir navegando.</p>
                    <a class="btn btn-danger" href="javascript:history.back()">Go Back</a>
               </div>
          </div>
     </div>
     <div id="footer" class="text-center">
          EnerFotVol
     </div>
</asp:Content>
