<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Enerfotvol.Formulario_web5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 40px">
        <asp:Label ID="lblBitacora" runat="server" Text="Bitácora"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblObjAudit" runat="server" Text="Objeto Auditado"></asp:Label>
        <asp:TextBox ID="txtObjAudit" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblAutor" runat="server" Text="Autor"></asp:Label>
        <asp:TextBox ID="txtAutor" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Desde"></asp:Label>
        <asp:TextBox ID="txtFechaDesde" runat="server"></asp:TextBox>
        <asp:Calendar ID="cldFechaDesde" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
        <br />
        <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha Hasta"></asp:Label>
        <div class="form-group">
            <label for="id_start_datetime">24hr Date-Time:</label>
            <div class="input-group date" id="id_1">
                <input type="text" value="05/16/2018 11:31:00" class="form-control" required/>
                <div class="input-group-addon input-group-append">
                    <div class="input-group-text">
                        <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                    </div>
                </div>
            </div>
        </div>
        <asp:TextBox ID="txtFechaHasta" runat="server"></asp:TextBox>
        <asp:Calendar ID="cldFechaHasta" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" SelectedDate="05/08/2021 19:44:14" Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
        <br />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="w-100 btn btn-lg btn-primary" />
        <br />
        <br />
        <asp:GridView ID="dgvBitacora" runat="server" AutoGenerateColumns="false" AllowPaging="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="dgvBitacora_PageIndexChanging" CssClass="table table-condensed table-hover" >
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
                <asp:BoundField DataField="Objeto" />
                <asp:BoundField DataField="FechaHora" />
                <asp:BoundField DataField="Evento" />
                <asp:BoundField DataField="Autor" />
            </Columns>
        </asp:GridView>        
    </div>
</asp:Content>
