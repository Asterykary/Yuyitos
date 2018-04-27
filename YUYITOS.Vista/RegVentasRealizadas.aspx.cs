using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUYITOS.Negocio;

namespace YUYITOS.Vista
{
    public partial class RegVentasRealizadas : System.Web.UI.Page
    {
        private static Coleccion col = new Coleccion();
        private static List<DetalleStock> detalleStock = new List<DetalleStock>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void mostrarCarrito()
        {
            int i = 1;
            tablaProductos.Visible = true;
            foreach (var prod in col.carritoVenta)
            {
                //TableRow fila = new TableRow();
                //TableCell item = new TableCell();
                //item.Text = i.ToString();
                //fila.Cells.Add(item);
                //TableCell descripcion = new TableCell();
                //descripcion.Text = prod.Descripcion;
                //fila.Cells.Add(descripcion);
                //TableCell cantidad = new TableCell();
                //cantidad.Text = prod.Cantidad.ToString();
                //fila.Cells.Add(cantidad);
                //TableCell valorUnitario = new TableCell();
                //valorUnitario.Text = "$ " + prod.Precio.ToString("0,0");
                //fila.Cells.Add(valorUnitario);
                //TableCell valorTotal = new TableCell();
                //string total = (prod.Precio * prod.Cantidad).ToString();
                //valorTotal.Text = "$ " + int.Parse(total).ToString("0,0");
                //fila.Cells.Add(valorTotal);
                //tablaProductos.Rows.Add(fila);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            var stock = col.ListadoDetalleStock().First(p => p.CODIGO_BARRA == int.Parse(txtCodProducto.Text));
            if (stock.CANT_DETALLE_STOCK >= int.Parse(txtCantidad.Text))
            {
                stock.CANT_DETALLE_STOCK = int.Parse(txtCantidad.Text);
                detalleStock.Add(stock);
                //var producto = col.ListadoProductos().First(p => p.Id_producto == stock.PRODUCTO_ID_PRODUCTO);
                //producto.Cantidad = int.Parse(txtCantidad.Text);
                //col.carritoVenta.Add(producto);
                //txtCantidad.Text = string.Empty;
                //txtCodProducto.Text = string.Empty;
                //mostrarCarrito();
                //lblErrorCantidad.Text = "";
            }
            else
            {
                lblErrorCantidad.Text = "Error: No hay stock del producto ingresado";
                return;
            }
            
        }

        protected void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            foreach (var stDetalle in detalleStock)
            {
                DetalleStock sd = new DetalleStock();
                sd.ID_DETALLE_STOCK = stDetalle.ID_DETALLE_STOCK;
                sd.CANT_DETALLE_STOCK = col.ListadoDetalleStock().First(d=>d.ID_DETALLE_STOCK == stDetalle.ID_DETALLE_STOCK).CANT_DETALLE_STOCK - stDetalle.CANT_DETALLE_STOCK;
                sd.CODIGO_BARRA = stDetalle.CODIGO_BARRA;
                //sd.PRODUCTO_ID_PRODUCTO = stDetalle.PRODUCTO_ID_PRODUCTO;
                sd.STOCK_ID_STOCK = stDetalle.STOCK_ID_STOCK;
                if (sd.Update())
                {
                    lblMensaje.Text = "Venta realizada exitosamente.";
                }else
                {
                    lblMensaje.Text = "Error: No se ha podido realizar la venta.";
                }
            }
        }
    }
}