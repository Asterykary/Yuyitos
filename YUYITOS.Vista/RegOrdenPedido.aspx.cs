using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUYITOS.Negocio;

namespace YUYITOS.Vista
{
    public partial class RegOrdenPedido : System.Web.UI.Page
    {
        private static Coleccion con = new Coleccion();
        private static int neto = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LeerProveedores();
                LeerProductos();
            }

        }
        
        /// <summary>
        /// Obtiene el listado de proveedores desde la clase Colección y los muestra en el ddl1
        /// </summary>
        private void LeerProveedores()
        {
            DropDownList1.Items.Clear();
            foreach (Proveedor ent in con.ListadoIdProveedor())
            {
                DropDownList1.Items.Add(new ListItem() { Value = ent.NOMBRE });
            }


        }

        /// <summary>
        /// Obtiene el listado de productos desde la clase Colección y los muestra en el ddl2
        /// </summary>
        private void LeerProductos()
        {
            DropDownList2.Items.Clear();
           
            foreach (Producto ent in con.ListadoProductos())
            {
                DropDownList2.Items.Add(new ListItem() { Value = ent.Descripcion});
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {   
            var producto = (Producto)con.ListadoProductos().First(p => p.Descripcion == DropDownList2.SelectedItem.Text);
            producto.Cantidad = int.Parse(txtCantidad.Text);
            con.carrito.Add(producto);
            txtCantidad.Text = string.Empty;
            mostrarLista();
        }

        private void mostrarLista()
        {
            neto = 0;
            tablaProductos.Visible = true;
            int i = 1;

            //Poblando tabla
            foreach (var prod in con.carrito)
            {
                TableRow fila = new TableRow();
                TableCell item = new TableCell();
                item.Text = i.ToString();
                fila.Cells.Add(item);
                TableCell descripcion = new TableCell();
                descripcion.Text = prod.Descripcion;
                fila.Cells.Add(descripcion);
                TableCell cantidad = new TableCell();
                cantidad.Text = prod.Cantidad.ToString();
                fila.Cells.Add(cantidad);
                TableCell valorUnitario = new TableCell();
                valorUnitario.Text = "$ " + prod.Precio.ToString("0,0");
                fila.Cells.Add(valorUnitario);
                TableCell valorTotal = new TableCell();
                string total = (prod.Precio * prod.Cantidad).ToString();
                valorTotal.Text = "$ " + int.Parse(total).ToString("0,0");
                fila.Cells.Add(valorTotal);
                tablaProductos.Rows.Add(fila);
                i++;
                neto += int.Parse(total);
            }
            lblNeto.Text = " $ " + neto.ToString("0,0");
            lblIva.Text = " $ " + ((int)(neto * 0.19)).ToString("0,0");
            lblTotal.Text= " $ " + ((int)(neto * 1.19)).ToString("0,0");
        }
        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            con.carrito.Remove(con.carrito[int.Parse(txtEliminar.Text)-1]);
            txtEliminar.Text = string.Empty;
            mostrarLista();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Orden orden = new Orden();
            orden.ID_ORDEN = orden.getLastId() + 1;
            orden.ID_USUARIO = 123456;
            orden.CREADO_EN = DateTime.Now;
            var proveedor = con.ListadoIdProveedor().First(p => p.NOMBRE == DropDownList1.SelectedItem.Text);
            orden.PROVEEDOR_ID_PROVEEDOR = proveedor.ID_PROVEEDOR;
            orden.ESTADO_ORDEN = 0;
            if (orden.Create()) //Se inserta la Orden en la base de datos
            {
                foreach (var producto in con.carrito)
                {
                    DetalleOrden detalleOrden = new DetalleOrden();
                    detalleOrden.ID_DETALLE_ORDEN = detalleOrden.getLastId() + 1;
                    detalleOrden.DESCRIPCION = producto.Descripcion;
                    detalleOrden.ORDEN_ID_ORDEN = (int)orden.ID_ORDEN;
                    detalleOrden.CANT_DETALLE_O = (int)producto.Cantidad;
                    detalleOrden.PRODUCTO_ID_PRODUCTO = producto.Id_producto;
                    detalleOrden.Create(); // Se inserta cada detalle en la base de datos
                }
                con.carrito = new List<Producto>();
                lblMensaje.Text = "Orden generada exitosamente!";
            }else
            {
                lblMensaje.Text = "Hubo un error al generar la orden";
            }
            
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            con.carrito = new List<Producto>();
            lblNeto.Text = " $ 0";
            lblIva.Text = " $ 0";
            lblTotal.Text = " $ 0";
        }
    }
}