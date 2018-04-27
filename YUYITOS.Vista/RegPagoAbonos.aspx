<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegPagoAbonos.aspx.cs" Inherits="YUYITOS.Vista.RegPagoAbonos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Registro de Pago de Abono</h1>

     <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#0000CC"></asp:Label>
         <br />
         <div class="col-auto my-1">
            <p><strong>Seleccione un Proveedor:   <asp:TextBox ID="txtRut" runat="server" CssClass="form-control" Enabled="True"></asp:TextBox></strong></p>
           <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary"/>
            <br/>
            <br/>

            <div class="form-group">

                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">
                                <p><strong>Nombre :</strong></p>
                            </th>
                            <th>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="True"></asp:TextBox>
                            </th>
                        </tr>
                        <tr>
                            <th scope="col">
                                <div class="form-group">
                                    <label>Monto Deuda &nbsp;</label>
                                </div>
                            </th>
                            <th>
                                <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control" Enabled="True"></asp:TextBox>
                            </th>
                        </tr>
                         <tr>
                            <th scope="col">
                                <div class="form-group">
                                    <label>Total a Pagar &nbsp;</label>
                                </div>
                            </th>
                            <th>
                                <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" Enabled="True"></asp:TextBox>

                               
                            </th>
                        </tr>

                        <tr>
                            <th scope="col">
                                <asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-primary"  />
                            </th>

                        </tr>
                    </thead>
                </table>
            </div>

        </div>

</asp:Content>
