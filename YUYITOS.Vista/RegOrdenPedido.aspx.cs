using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUYITOS.Negocio;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace YUYITOS.Vista
{
    public partial class RegOrdenPedido : System.Web.UI.Page
    {
        private static Coleccion col = new Coleccion();
        private static int neto = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LeerProveedores();
                LeerProductos(int.Parse(DropDownList1.SelectedItem.Value));
            }

        }
        
        /// <summary>
        /// Obtiene el listado de proveedores desde la clase Colección y los muestra en el ddl1
        /// </summary>
        private void LeerProveedores()
        {
            DropDownList1.Items.Clear();
            foreach (Proveedor ent in col.ListadoIdProveedor())
            {
                DropDownList1.Items.Add(new System.Web.UI.WebControls.ListItem() {Text = ent.NOMBRE, Value = ent.ID_PROVEEDOR.ToString() });
            }


        }

        /// <summary>
        /// Obtiene el listado de productos desde la clase Colección y los muestra en el ddl2
        /// </summary>
        private void LeerProductos(int id_proveedor)
        {
            DropDownList2.Items.Clear();

            foreach (Producto_proveedor ent in col.ListadoProductos_p().Where(r => r.PROVEEDOR_ID == id_proveedor))

            {
                    DropDownList2.Items.Add(new System.Web.UI.WebControls.ListItem() { Text = ent.Descripcion, Value = ent.ID_PRODUCTO_P.ToString() }) ;
               
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            var producto = (Producto_proveedor)col.ListadoProductos_p().First(p => p.Descripcion == DropDownList2.SelectedItem.Text);
          
            

            try
            {

                producto.Cantidad = int.Parse(txtCantidad.Text);
                
            }
            catch (FormatException fe)
            {
                lblError.Text = "La cantidad no puede ir vacia";
                mostrarLista();
                return;
            }
            if (int.Parse(txtCantidad.Text) > 0)
            {
                producto.Cantidad = int.Parse(txtCantidad.Text);
            }
            else
            {
                mostrarLista();
                lblError.Text = "La Cantidad no puede ser menor a 0";
                return;
            }



            for (int i = 0; i < col.carrito.Count; i++)
            {
                if (col.carrito[i].Descripcion == producto.Descripcion)
                {
                    lblError.Text = "No puede volver a agregar el mismo producto";
                    mostrarLista();
                    txtCantidad.Text = string.Empty;
                    return;
                }

            }
            if (producto.PROVEEDOR_ID != int.Parse(DropDownList1.SelectedItem.Value))
            {
                lblError.Text = "El proveedor no coincide con el producto seleccionado.";
                mostrarLista();
                txtCantidad.Text = string.Empty;
                return;
            }

            col.carrito.Add(producto);
            txtCantidad.Text = string.Empty;
            txtEliminar.Text = string.Empty;
            lblError.Text = string.Empty;
            lblErrorE.Text = string.Empty;
            mostrarLista();




        }

        private void mostrarLista()
        {
            neto = 0;
            tablaProductos.Visible = true;
            int i = 1;
            if (col.carrito.Count == 0)
            {
                DropDownList1.Enabled = true;

            }
            else
            {
                DropDownList1.Enabled = false;
            }
            //Poblando tabla
            foreach (var prod in col.carrito)
            { 
                int precioCompra = col.ListadoProductos().First(p => p.ID_PRODUCTO == prod.PRODUCTO_ID).PRECIO_COMPRA;
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
                valorUnitario.Text = "$ " + precioCompra;
                fila.Cells.Add(valorUnitario);
                TableCell valorTotal = new TableCell();
                string total = (precioCompra * prod.Cantidad).ToString();
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
           
            if (txtEliminar.Text.Length > 0 )
            {
                if (int.Parse(txtEliminar.Text) <= 0 || int.Parse(txtEliminar.Text) > col.carrito.Count)
                {
                    lblErrorE.Text = "El item ingresado no se encuentra en la lista";
                    mostrarLista();
                    return;
                }
                col.carrito.Remove(col.carrito[int.Parse(txtEliminar.Text) - 1]);
                txtEliminar.Text = string.Empty;
                mostrarLista();
                lblError.Text = string.Empty;
                lblErrorE.Text = string.Empty;
            }
            else
            {
                lblErrorE.Text = "Debe indicar un Item a eliminar";
                
            }

            

            
            
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Orden orden = new Orden();
            orden.ID_ORDEN = orden.getLastId() + 1;
            orden.CREADO_EN = (DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            var proveedor = col.ListadoIdProveedor().First(p => p.NOMBRE == DropDownList1.SelectedItem.Text);
            orden.PROVEEDOR_ID = proveedor.ID_PROVEEDOR;
            orden.ESTADO_ORDEN = 0;
            if (orden.Create()) //Se inserta la Orden en la base de datos
            {
                foreach (var producto in col.carrito)
                {
                    DetalleOrden detalleOrden = new DetalleOrden();
                    detalleOrden.ID_DETALLE_ORDEN = detalleOrden.getLastId() + 1;
                    detalleOrden.DESCRIPCION = producto.Descripcion;
                    detalleOrden.ORDEN_ID = (int)orden.ID_ORDEN;
                    detalleOrden.CANT_DETALLE_O = (int)producto.Cantidad;
                    detalleOrden.ESTADO_DET_ORDEN = "0";
                    detalleOrden.PRODUCTO_PROVEEDOR_ID = producto.ID_PRODUCTO_P;
                    detalleOrden.Create(); // Se inserta cada detalle en la base de datos
                }   
                col.carrito = new List<Producto_proveedor>();
                //lblMensaje.Text = "Orden generada exitosamente!";
                mostrarLista();
                MessageBox.Show("Orden generada exitosamente!","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Hubo un error al generar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GenerarPDF((int)orden.ID_ORDEN);
            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", "<script>window.open('http://localhost:49619/PDFs/Orden_" + orden.ID_ORDEN + ".pdf')</script>");

            lblNeto.Text = " $ 0";
            lblIva.Text = " $ 0";
            lblTotal.Text = " $ 0";
            lblErrorE.Text = string.Empty;
            lblError.Text = string.Empty;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            col.carrito = new List<Producto_proveedor>();
            mostrarLista();
            lblNeto.Text = " $ 0";
            lblIva.Text = " $ 0";
            lblTotal.Text = " $ 0";
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if(col.carrito.Count == 0)
            {
                LeerProductos(int.Parse(DropDownList1.SelectedItem.Value));
                lblError.Text = string.Empty;
                lblErrorE.Text = string.Empty;
            }
            else
            {
                lblError.Text = "No se puede cambiar de proveedor mientras existan productos en la lista";
                mostrarLista();
            }
            txtEliminar.Text = string.Empty;
        }

        public void GenerarPDF(int id_orden)
        {
            var orden = col.ListadoOrden().First(o => o.ID_ORDEN == id_orden);
            var proveedor = col.ListadoIdProveedor().First(p => p.ID_PROVEEDOR == orden.PROVEEDOR_ID);
            var detalleOrden = col.ListadoDetalleOrden().Where(dto => dto.ORDEN_ID == id_orden);
   
            var doc1 = new Document();
            string path = Server.MapPath("PDFs");
            PdfWriter.GetInstance(doc1, new FileStream(path + "/Orden_" + id_orden + ".pdf", FileMode.Create));
            doc1.Open();


            Font boldFont = new Font(Font.HELVETICA, 18, Font.BOLD);
            Font boldFont2 = new Font(Font.HELVETICA, 12, Font.BOLD);
            Paragraph pa = new Paragraph("Almacen YUYITOS",boldFont);
            pa.Alignment = Element.ALIGN_CENTER;
            doc1.Add(pa);
            Paragraph pa2 = new Paragraph("Orden de compra N°" + id_orden + "\n\n",boldFont2);
            pa2.Alignment = Element.ALIGN_CENTER;
            
            doc1.Add(pa2);

            var fuente = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA,12, iTextSharp.text.Font.BOLD);
            doc1.Add(new Paragraph("   Proveedor: " + proveedor.NOMBRE , fuente));
            doc1.Add(new Paragraph("   Rubro: " + proveedor.RUBRO + "\n\n",fuente));


            PdfPTable table = new PdfPTable(5);

            table.TotalWidth = 500f;
            table.LockedWidth = true;
            float[] widths = new float[] { 30, 170, 100, 100, 100 };
            table.SetWidths(widths);

            
            PdfPCell cell = new PdfPCell(new Phrase("Detalle de la Orden",boldFont));
            cell.Colspan = 5;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            PdfPCell Nro = new PdfPCell(new Phrase("Nro",boldFont2));
            table.AddCell(Nro);
            PdfPCell Descripcion = new PdfPCell(new Phrase("Descripción", boldFont2));
            table.AddCell(Descripcion);
            PdfPCell Cantidad = new PdfPCell(new Phrase("Cantidad", boldFont2));
            table.AddCell(Cantidad);
            PdfPCell PrecioUnitario = new PdfPCell(new Phrase("Precio Unitario", boldFont2));
            table.AddCell(PrecioUnitario);
            PdfPCell PrecioTotal = new PdfPCell(new Phrase("Precio Total", boldFont2));
            table.AddCell(PrecioTotal);

            int i = 0;
            int sum = 0;
            
            foreach (var detOr in detalleOrden)
            {
                var producto = col.ListadoProductos().First(ip => ip.ID_PRODUCTO == col.ListadoProductos_p().First(ipp => ipp.ID_PRODUCTO_P == detOr.PRODUCTO_PROVEEDOR_ID).PRODUCTO_ID );
                
                table.AddCell(i + 1 + "");
                table.AddCell(detOr.DESCRIPCION);
                table.AddCell(detOr.CANT_DETALLE_O.ToString());
                table.AddCell(producto.PRECIO_COMPRA.ToString());
                table.AddCell((detOr.CANT_DETALLE_O * producto.PRECIO_COMPRA).ToString("0,0"));
                sum += detOr.CANT_DETALLE_O * producto.PRECIO_COMPRA;
                i++;
            }

            doc1.Add(table);
            Paragraph valorNeto = new Paragraph("Valor Neto: $ " + sum.ToString("0,0"), boldFont2);
            valorNeto.Alignment = Element.ALIGN_RIGHT;
            doc1.Add(valorNeto);
            Paragraph iva = new Paragraph("Valor Iva: $ " + ((int)(sum * 0.19)).ToString("0,0"), boldFont2);
            iva.Alignment = Element.ALIGN_RIGHT;
            doc1.Add(iva);
            Paragraph total = new Paragraph("Valor Total: $ " + ((int)(sum * 1.19)).ToString("0,0"), boldFont2);
            total.Alignment = Element.ALIGN_RIGHT;
            doc1.Add(total);

            doc1.Close();
        }

        
    }
}