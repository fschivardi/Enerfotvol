<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="Enerfotvol.Formulario_web4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <style>
        body {
            color: #566787;
            background: #f5f5f5;
            font-family: 'Varela Round', sans-serif;
            font-size: 13px;
        }

        .table-responsive {
            margin: 30px 0;
        }

        .table-wrapper {
            background: #fff;
            padding: 20px 25px;
            border-radius: 3px;
            min-width: 1000px;
            box-shadow: 0 1px 1px rgba(0,0,0,.05);
        }

        .table-title {
            padding-bottom: 15px;
            background: #435d7d;
            color: #fff;
            padding: 16px 30px;
            min-width: 100%;
            margin: -20px -25px 10px;
            border-radius: 3px 3px 0 0;
        }

            .table-title h2 {
                margin: 5px 0 0;
                font-size: 24px;
            }

            .table-title .btn-group {
                float: right;
            }

            .table-title .btn {
                color: #fff;
                float: right;
                font-size: 13px;
                border: none;
                min-width: 50px;
                border-radius: 2px;
                border: none;
                outline: none !important;
                margin-left: 10px;
            }

                .table-title .btn i {
                    float: left;
                    font-size: 21px;
                    margin-right: 5px;
                }

                .table-title .btn span {
                    float: left;
                    margin-top: 2px;
                }

        table.table tr th, table.table tr td {
            border-color: #e9e9e9;
            padding: 12px 15px;
            vertical-align: middle;
        }

            table.table tr th:first-child {
                width: 60px;
            }

            table.table tr th:last-child {
                width: 100px;
            }

        table.table-striped tbody tr:nth-of-type(odd) {
            background-color: #fcfcfc;
        }

        table.table-striped.table-hover tbody tr:hover {
            background: #f5f5f5;
        }

        table.table th i {
            font-size: 13px;
            margin: 0 5px;
            cursor: pointer;
        }

        table.table td:last-child i {
            opacity: 0.9;
            font-size: 22px;
            margin: 0 5px;
        }

        table.table td a {
            font-weight: bold;
            color: #566787;
            display: inline-block;
            text-decoration: none;
            outline: none !important;
        }

            table.table td a:hover {
                color: #2196F3;
            }

            table.table td a.edit {
                color: #FFC107;
            }

            table.table td a.delete {
                color: #F44336;
            }

        table.table td i {
            font-size: 19px;
        }

        table.table .avatar {
            border-radius: 50%;
            vertical-align: middle;
            margin-right: 10px;
        }

        .pagination {
            float: right;
            margin: 0 0 5px;
        }

            .pagination li a {
                border: none;
                font-size: 13px;
                min-width: 30px;
                min-height: 30px;
                color: #999;
                margin: 0 2px;
                line-height: 30px;
                border-radius: 2px !important;
                text-align: center;
                padding: 0 6px;
            }

                .pagination li a:hover {
                    color: #666;
                }

            .pagination li.active a, .pagination li.active a.page-link {
                background: #03A9F4;
            }

                .pagination li.active a:hover {
                    background: #0397d6;
                }

            .pagination li.disabled i {
                color: #ccc;
            }

            .pagination li i {
                font-size: 16px;
                padding-top: 6px
            }

        .hint-text {
            float: left;
            margin-top: 10px;
            font-size: 13px;
        }
        /* Custom checkbox */
        .custom-checkbox {
            position: relative;
        }

            .custom-checkbox input[type="checkbox"] {
                opacity: 0;
                position: absolute;
                margin: 5px 0 0 3px;
                z-index: 9;
            }

            .custom-checkbox label:before {
                width: 18px;
                height: 18px;
            }

            .custom-checkbox label:before {
                content: '';
                margin-right: 10px;
                display: inline-block;
                vertical-align: text-top;
                background: white;
                border: 1px solid #bbb;
                border-radius: 2px;
                box-sizing: border-box;
                z-index: 2;
            }

            .custom-checkbox input[type="checkbox"]:checked + label:after {
                content: '';
                position: absolute;
                left: 6px;
                top: 3px;
                width: 6px;
                height: 11px;
                border: solid #000;
                border-width: 0 3px 3px 0;
                transform: inherit;
                z-index: 3;
                transform: rotateZ(45deg);
            }

            .custom-checkbox input[type="checkbox"]:checked + label:before {
                border-color: #03A9F4;
                background: #03A9F4;
            }

            .custom-checkbox input[type="checkbox"]:checked + label:after {
                border-color: #fff;
            }

            .custom-checkbox input[type="checkbox"]:disabled + label:before {
                color: #b8b8b8;
                cursor: auto;
                box-shadow: none;
                background: #ddd;
            }
        /* Modal styles */
        .modal .modal-dialog {
            max-width: 400px;
        }

        .modal .modal-header, .modal .modal-body, .modal .modal-footer {
            padding: 20px 30px;
        }

        .modal .modal-content {
            border-radius: 3px;
            font-size: 14px;
        }

        .modal .modal-footer {
            background: #ecf0f1;
            border-radius: 0 0 3px 3px;
        }

        .modal .modal-title {
            display: inline-block;
        }

        .modal .form-control {
            border-radius: 2px;
            box-shadow: none;
            border-color: #dddddd;
        }

        .modal textarea.form-control {
            resize: vertical;
        }

        .modal .btn {
            border-radius: 2px;
            min-width: 100px;
        }

        .modal form label {
            font-weight: normal;
        }
    </style>
    <script>
        $(document).ready(function () {
            // Activate tooltip
            $('[data-toggle="tooltip"]').tooltip();

            // Select/Deselect checkboxes
            var checkbox = $('table tbody input[type="checkbox"]');
            $("#selectAll").click(function () {
                if (this.checked) {
                    checkbox.each(function () {
                        this.checked = true;
                    });
                } else {
                    checkbox.each(function () {
                        this.checked = false;
                    });
                }
            });
            checkbox.click(function () {
                if (!this.checked) {
                    $("#selectAll").prop("checked", false);
                }
            });
        });

        function validar(f) {
            var coinciden = (f.elements['txtClave'].value == f.elements['txtClave2'].value);
            if (!coinciden) alert("Las contraseñas no coinciden.");
            return coinciden;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-xl">
        <div class="table-responsive">
            <div style="margin-left: 40px">
                <asp:Label ID="lblGestPerfiles" runat="server" Text="Gestión de Perfiles"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblPerfilB" runat="server" Text="Perfil"></asp:Label>
                <asp:TextBox ID="txtPerfilB" runat="server" CssClass="text-dark"></asp:TextBox>
                <br />
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="w-30 btn btn-lg btn-primary" CausesValidation="False" />
                <br />
                <a href="#altaModal" class="btn pull-right btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Nuevo</span></a>
                <asp:GridView ID="dgvPerfiles" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="dgvPerfiles_PageIndexChanging" CssClass="table table-striped table-hover" OnRowCancelingEdit="dgvPerfiles_RowCancelingEdit" OnRowDeleting="dgvPerfiles_RowDeleting" OnRowEditing="dgvPerfiles_RowEditing" OnRowUpdating="dgvPerfiles_RowUpdating" DataKeyNames="Perfil" ShowHeaderWhenEmpty="True" ValidationGroup="GridView" >
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataTemplate>
                        No hay registros activos.
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True"  ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>
                        <asp:BoundField DataField="Perfil" HeaderText="Nombre Perfil" />                        
                        <asp:CommandField ShowEditButton="True" ValidationGroup="GridView" />
                        <asp:CommandField ShowDeleteButton="True" ValidationGroup="GridView" />                        
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
        <div id="altaModal" class="modal fade" style="display: none;" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                       <asp:Label ID="lblAltaPerfil" runat="server" Text="Nuevo Perfil" ></asp:Label>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label ID="lblPerfil" runat="server" Text="Nombre Perfil" ></asp:Label>
                            <asp:TextBox ID="txtPerfil" runat="server" CssClass="text-dark" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPerfil" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtNombre" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtApellido" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" ></asp:TextBox>                            
                            <br />
                            <asp:Label ID="lblMail" runat="server" Text="Mail"></asp:Label>
                            <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" TextMode="Email" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtMail" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtClave" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblConfirmacion" runat="server" Text="Confirmación Clave"></asp:Label>
                            <asp:TextBox ID="txtClave2" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtClave2" runat="server" ErrorMessage="*" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
                            <br /> 
                            <asp:CompareValidator 
                                   ID="comparaClaveConfirmacion" Operator="Equal" runat="server"
                                   ValidationGroup="Nuevo" ControlToValidate="txtClave"  
                                   ControlToCompare="txtClave2" ErrorMessage="Las contraseñas no coinciden" SetFocusOnError="true" >
                            </asp:CompareValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
                        <asp:Button ID="btnGuardar" runat="server" Text="Crear" OnClick="btnCrear_Click" CssClass="btn btn-success"  ValidationGroup="Nuevo" />
                    </div>
                </div>
            </div>
        </div>
             </div>
</asp:Content>
