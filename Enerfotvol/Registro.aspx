<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Enerfotvol.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/css/bootstrap.min.css" rel="stylesheet"/>
    <meta name="theme-color" content="#7952b3"/>
    <script src="/js/funciones.js"></script>
    <script src="js/jquery-3.6.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#<% = txtUsuario.ClientID %>").on('blur', function () {
                var user = $("#<% = txtUsuario.ClientID %>").val();
                if (user == null || user == '' || user.length<4) {
                    $("#<% = lblValidacionUsuario.ClientID %>")
                        .html("El usuario debe contener al menos 4 caracteres de longitud")
                        .css("color", "Red");
                    $("#btnRegistrarse").attr('disabled', 'disabled');
                    return false;
                }
                else {
                    PageMethods.UsuarioDisponible(user,
                        function (resul) {
                            if (resul) {
                                $("#<% = lblValidacionUsuario.ClientID %>")
                                    .html("Nombre de Usuario disponible")
                                    .css("color", "Green");
                                $("#btnRegistrarse").removeAttr('disabled');
                            }
                            else {
                                $("#<% = lblValidacionUsuario.ClientID %>")
                                    .html("Nombre de Usuario NO disponible")
                                    .css("color", "Red");
                                $("#btnRegistrarse").attr('disabled', 'disabled');
                            }
                        },
                        function () {
                            alert("Se ha producido un error al verificar el usuario");
                        });
                    return false;
                }
            });
        })
        $(function () {
            $("#<% = txtMail.ClientID %>").on('blur', function () {
                var user = $("#<% = txtMail.ClientID %>").val();
                if (user == null || user == '' || user.length < 5) {
                    $("#<% = lblValidacionMail.ClientID %>")
                        .html("")
                        .css("color", "Red");
                    return false;
                }
                else {
                    PageMethods.MailDisponible(user,
                        function (resul) {
                            if (resul) {
                                $("#<% = lblValidacionMail.ClientID %>")
                                    .html("Correo disponible.")
                                    .css("color", "Green");
                                $("#btnRegistrarse").removeAttr('disabled');
                            }
                            else {
                                $("#<% = lblValidacionMail.ClientID %>")
                                    .html("El correo electrónico ingresado ya está registrado.")
                                    .css("color", "Red");
                                $("#btnRegistrarse").attr('disabled', 'disabled');
                            }
                        },
                        function () {
                            alert("Se ha producido un error al verificar el mail");
                        });
                    return false;
                }
            });
        })
    </script>
</head>
<body>
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
            
        </asp:ScriptManager>
            <asp:Label ID="lblRegistro" runat="server" CssClass="h3 mb-3 fw-normal" Text="Registrarse"></asp:Label>         
            <div>
                <asp:Label ID="lblUsuario" runat="server" Text="Nombre Usuario"></asp:Label>
                <asp:TextBox ID="txtUsuario" PlaceHolder="Usuario" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtUsuario" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
                <asp:Label ID="lblValidacionUsuario" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblMail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtMail" PlaceHolder="Email" runat="server" TextMode="Email" CssClass="form-control mb-2"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtMail" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
                <asp:Label ID="lblValidacionMail" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre)"></asp:Label>                            
                <asp:TextBox ID="txtNombre" PlaceHolder="Clave" runat="server" TextMode="SingleLine" CssClass="form-control mb-2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtNombre" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>                            
                <asp:TextBox ID="txtApellido" PlaceHolder="Clave" runat="server" TextMode="SingleLine" CssClass="form-control mx-sm-3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtApellido" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>                            
                <asp:TextBox ID="txtClave" PlaceHolder="Clave" runat="server" TextMode="Password" CssClass="form-control mx-sm-3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtClave" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblConfirmacion" runat="server" Text="Confirmar Clave"></asp:Label>                            
                <asp:TextBox ID="txtClave2" PlaceHolder="Clave" runat="server" TextMode="Password" CssClass="form-control mb-2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtClave2" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
            </div>
            <br /> 
               <asp:CompareValidator 
               ID="comparaClaveConfirmacion" Operator="Equal" runat="server"
               ValidationGroup="Nuevo" ControlToValidate="txtClave"  
               ControlToCompare="txtClave2" ErrorMessage="Las contraseñas no coinciden" SetFocusOnError="true" >
               </asp:CompareValidator>
           <br/>
           <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
           <br/>
            <br/>
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" OnClick="RegistrarUsuario" CssClass="w-20 btn btn-lg btn-primary" ValidationGroup="Nuevo" />
        </form>
</body>
</html>
