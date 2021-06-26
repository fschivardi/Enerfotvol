<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Enerfotvol.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>EnertFotVol</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet"/>
    <meta name="theme-color" content="#7952b3"/>
    <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style>
    <link href="/css/signin.css" rel="stylesheet"/>
    <script src="/js/funciones.js"></script>
</head>
<body class="text-center">
    <main class="form-signin">
        <form id="form1" runat="server" >
            <img class="mb-4" src="/img/signin.png" alt="" width="100" height="100"/>
            <br />
            <asp:Label ID="lblLogin" runat="server" CssClass="h3 mb-3 fw-normal" Text="Iniciar Sesión"></asp:Label>            
            <div class="form-floating">                
                <asp:TextBox ID="txtUsuario" PlaceHolder="Usuario" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" AssociatedControlID="txtUsuario"></asp:Label>
                </div>
            <div class="form-floating">
                <asp:TextBox ID="txtClave" PlaceHolder="Clave" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblClave" runat="server" Text="Clave" AssociatedControlID="txtClave"></asp:Label>                            
            </div>
            <div class="form-floating">
                <asp:Label ID="lblIdioma" runat="server" Text="Idioma"></asp:Label>
                <asp:DropDownList ID="cmbIdioma" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbIdioma_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                <br/>
                <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
                <br/>
            </div>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClientClick="return validarFormulario();" OnClick="Button1_Click" CssClass="w-100 btn btn-lg btn-primary"/>
            <div class="panel-heading">  
                <div class="panel-title" style="text-align: left">                    
                    <asp:HyperLink ID="lnkRecuperaClave" runat="server" CssClass="link-primary" Text="¿Olvidó su contraseña?" href="RecuperoClave.aspx"></asp:HyperLink>                    
                    <br />
                    <asp:HyperLink ID="lnkRegistrarse" runat="server" CssClass="link-primary" Text="Registrarse" href="Registro.aspx"></asp:HyperLink>                    
                </div>  
            </div>
        </form>
    </main>
</body>
</html>
