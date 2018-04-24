<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegProveedores.aspx.cs" Inherits="YUYITOS.Vista.RegProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Registro de Proveedores</h2>
    <br />
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group">
                <div class="form-row">
                    <div class="col-6">
                        <asp:label id="lblRut" runat="server" text="Rut" associatedcontrolid="txtRut"></asp:label>
                        <asp:textbox id="txtRut" runat="server" cssclass="form-control form-control-sm" aria-describedby="basic-addon3" placeholder="ingrese rut sin digito"></asp:textbox>
                    </div>
                    <div class="col">
                        <asp:label id="lblDV" runat="server" text="Dv" associatedcontrolid="txtDV"></asp:label>
                        <asp:textbox id="txtDV" runat="server" cssclass="form-control form-control-sm" placeholder="digito"></asp:textbox>
                    </div>
                    <div class="col" style="padding-top: 25px">
                        <asp:button id="btnBuscar" runat="server" text="Buscar" cssclass="btn btn-primary form-control form-control-sm" onclick="btnBuscar_Click" />
                    </div>
                </div>
            </div>

            <div class="form-group col-8">
                <asp:label id="lblNombre" runat="server" text="Nombre" associatedcontrolid="txtNombre"></asp:label>
                <asp:textbox id="txtNombre" runat="server" cssclass="form-control form-control-sm" placeholder="ingrese nombre"></asp:textbox>
            </div>
            <div class="form-group col-8">
                <asp:label id="lblTelefono" runat="server" text="Telefono" associatedcontrolid="txtTelefono"></asp:label>
                <asp:textbox id="txtTelefono" runat="server" cssclass="form-control form-control-sm" placeholder="ingrese telefono"></asp:textbox>
            </div>

            <div class="form-group col-8">
                <asp:label id="lblRubro" runat="server" text="Rubro" associatedcontrolid="ddlRubro"></asp:label>
                <asp:dropdownlist id="ddlRubro" runat="server" cssclass="form-control form-control-sm"></asp:dropdownlist>
            </div>
            <div class="form-group col-8">
                <asp:label id="lblCiudad" runat="server" text="Ciudad" associatedcontrolid="ddlCiudad"></asp:label>
                <asp:dropdownlist id="ddlCiudad" runat="server" cssclass="form-control form-control-sm"></asp:dropdownlist>
            </div>


        </div>
        <div style="position: absolute; left: 501px; margin-bottom: 30px; margin-top: 10px;">
            <asp:button id="btnRegistrar" runat="server" text="Registrar" cssclass="btn btn-primary" onclick="btnRegistrar_Click" />
            <asp:button id="btnCancelar" runat="server" text="Cancelar" cssclass="btn btn-danger" />
            <asp:label id="lblMensaje" runat="server" text="" forecolor="Red"></asp:label>
        </div>
    </div>

</asp:Content>
