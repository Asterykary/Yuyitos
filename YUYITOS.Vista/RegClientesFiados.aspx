<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegClientesFiados.aspx.cs" Inherits="YUYITOS.Vista.RegClientesFiados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 187px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Registro de clientes fiados</h1>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Id Fiado</td>
                <td>
                    <asp:Label ID="idFiado" runat="server" Text="1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Ingrese R.U.T.</td>
                <td>
                    <input id="rutCliente" type="text" />&nbsp;&nbsp;
                    <input id="buscarBtn" class="btn btn-primary" type="button" value="Buscar RUT" /></td>
            </tr>
            <tr>
                <td class="auto-style1">Nombre</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">Monto</td>
                <td>
                    <input id="monto" type="text" /></td>
            </tr>
            <tr>
                <td class="auto-style1">Fecha de Vencimiento</td>
                <td>
                    <input id="fecha" type="text" /></td>
            </tr>
        </table>
        <br />
        <input id="fiadoBtn" class="btn btn-primary" type="button" value="Registrar Fiado" /><br />
    
</asp:Content>
