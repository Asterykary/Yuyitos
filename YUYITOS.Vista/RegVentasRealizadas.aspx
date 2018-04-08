<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegVentasRealizadas.aspx.cs" Inherits="YUYITOS.Vista.RegVentasRealizadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <div class="container">
		<h1>Registro de ventas</h1>
		<br/>
		<div class="row">
			<div class="col">
				<div class="input-group mb-3">
				  <div class="input-group-prepend">
				    <span class="input-group-text" id="basic-addon1">Codigo Producto</span>
				  </div>
				  <input type="text" class="form-control" placeholder="Ingrese codigo" aria-describedby="basic-addon1">
				</div>
			</div>
			<div class="col">
				<button type="button" class="btn btn-primary">Agregar</button>
			</div>
		</div>
		<br>
		<table class="table">
		  <thead>
		    <tr>
		      <th scope="col">Descripcion</th>
		      <th scope="col">Precio</th>
		      <th scope="col">Total</th>
		    </tr>
		  </thead>
		  <tbody>
		    <tr>
		      <td>Super 8</td>
		      <td>$200</td>
		      <td>$200</td>
		    </tr>
		    <tr>
		      <td>Manzana</td>
		      <td>$100</td>
		      <td>$100</td>
		    </tr>
		    <tr>
		      <td></td>
		      <td></td>
		      <th>Total: $300</th>
		    </tr>
		  </tbody>
		</table>

		<div class="custom-control custom-radio">
		  <input type="radio" id="customRadio1" name="customRadio" class="custom-control-input">
		  <label class="custom-control-label" for="customRadio1">Fiado</label>
		</div>
		<div class="custom-control custom-radio">
		  <input type="radio" id="customRadio2" name="customRadio" class="custom-control-input">
		  <label class="custom-control-label" for="customRadio2">No fiado</label>
		</div>
		<br>
		<button type="button" class="btn btn-success">Realizar venta</button>
	</div>

</asp:Content>
