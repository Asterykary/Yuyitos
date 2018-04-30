﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegOrdenPedido.aspx.cs" Inherits="YUYITOS.Vista.RegOrdenPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/regOrden.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Registro de Orden de Pedido</h1>
    <h1>Prueba pull remote Carlos a Karina </h1>
    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#0000CC"></asp:Label>
        <br />
        <div class="col-auto my-1">
            <p><strong>Seleccione un Proveedor:</strong></p>
            <asp:DropDownList ID="DropDownList1" runat="server">
               

            </asp:DropDownList>

            <br>
            <br>

            <div class="form-group">

                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">
                                <p><strong>Seleccione un Producto:</strong></p>
                            </th>
                            <th>
                                <asp:DropDownList ID="DropDownList2" runat="server">

                                </asp:DropDownList>
                            </th>
                        </tr>
                        <tr>
                            <th scope="col">
                                <div class="form-group">
                                    <label>Ingrese Cantidad&nbsp;</label>
                                </div>
                            </th>
                            <th>
                                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" Enabled="True"></asp:TextBox>
                                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th scope="col">
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                            </th>

                        </tr>
                    </thead>
                </table>
            </div>

        </div>
        <!--table-->
        <asp:Table ID="tablaProductos" runat="server" CssClass="table table-dark" Visible="False">
            <asp:TableRow>
                <asp:TableHeaderCell>Item</asp:TableHeaderCell>
                <asp:TableHeaderCell>Descripción</asp:TableHeaderCell>
                <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                <asp:TableHeaderCell>Valor Unitario</asp:TableHeaderCell>
                <asp:TableHeaderCell>Valor Total</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
        <p>Ingrese el n° de item a eliminar: </p>
        <asp:TextBox ID="txtEliminar" runat="server" />
        <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click1" /><br /><br />
        <table class="table table-dark">
            <tbody>
                <tr>
                    <th scope="row"></th>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>Valor Neto:<asp:Label ID="lblNeto" runat="server" Text="$ 0"></asp:Label></td>
                </tr>
                <tr>
                    <th scope="row"></th>
                    <td>
                        <asp:Button ID="btnGenerar" Text="Generar orden" runat="server" CssClass="btn btn-success" OnClick="btnGenerar_Click"  />
                    <td></td>
                    <td></td>
                    <td>Valor Iva:<asp:Label ID="lblIva" runat="server" Text="$ 0"></asp:Label></td>
                </tr>
                <tr>
                    <th scope="row"></th>
                    <td>
                        <asp:Button ID="btnCancelarOrden" runat="server" Text="Cancelar Orden" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>Valor Total:<asp:Label ID="lblTotal" runat="server" Text="$ 0"></asp:Label></td>
                </tr>
            </tbody>
        </table>
</asp:Content>
