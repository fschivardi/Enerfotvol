<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperoClave.aspx.cs" Inherits="Enerfotvol.RecuperoClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/css/bootstrap.min.css" rel="stylesheet"/>
    <meta name="theme-color" content="#7952b3"/>
    <script src="/js/funciones.js"></script>
</head>
<body>
       <form id="form2" runat="server">
            <asp:Label ID="lblRecuperoClave" runat="server" CssClass="h3 mb-3 fw-normal" Text="Recuperar Contraseña"></asp:Label>         
            <div>
                <asp:Label ID="lblMail" runat="server" Text="Ingrese su mail"></asp:Label>
                <asp:TextBox ID="txtMail" PlaceHolder="Email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>    
            </div>            
           <br/>
           <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
           <br/>
            <asp:Button ID="btnRecuperarClave" runat="server" Text="Recuperar Contraseña" OnClientClick="return validarFormulario();" OnClick="Button1_Click" CssClass="w-20 btn btn-lg btn-primary"/>
        </form>
</body>
</html>
