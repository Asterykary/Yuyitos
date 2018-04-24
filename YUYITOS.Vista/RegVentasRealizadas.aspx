<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegVentasRealizadas.aspx.cs" Inherits="YUYITOS.Vista.RegVentasRealizadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <div class="container">
		<h1>Registro de ventas</h1>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        <br />
		<div class="row">
			<div class="col">
				<div class="input-group mb-3">
				  <div class="input-group-prepend">
				    <span class="input-group-text" id="basic-addon1">Codigo Producto</span>
				  </div>
                    <asp:TextBox ID="txtCodProducto" runat="server" CssClass="form-control"></asp:TextBox>
				</div>
                <div class="input-group mb-3">
				  <div class="input-group-prepend">
				    <span class="input-group-text" id="basic-addon2">Cantidad</span>
				  </div>
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="lblErrorCantidad" runat="server" Text=""></asp:Label>
				</div>
			</div>
			<div class="col">
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" CssClass="btn btn-primary" />
			</div>
		</div>
		<br>
        <asp:Table ID="tablaProductos" runat="server" CssClass="table table-light" Visible="False">
            <asp:TableRow>
                <asp:TableHeaderCell>Item</asp:TableHeaderCell>
                <asp:TableHeaderCell>Descripción</asp:TableHeaderCell>
                <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                <asp:TableHeaderCell>Precio unitario</asp:TableHeaderCell>
                <asp:TableHeaderCell>Precio total</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
		
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Text="&nbsp;Fiado" />
            <asp:ListItem Text="&nbsp;No fiado" Selected="True" />
        </asp:RadioButtonList>
		<br>
        <asp:Button ID="btnRealizarVenta" runat="server" OnClick="btnRealizarVenta_Click" Text="Realizar venta" CssClass="btn btn-success" />
	</div>

</asp:Content>
