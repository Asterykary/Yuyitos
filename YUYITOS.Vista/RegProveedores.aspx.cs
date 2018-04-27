using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUYITOS.Negocio;

namespace YUYITOS.Vista
{
    public partial class RegProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRubroProveedor();
                CargarCiudadProveedor();
            }
        }

        private void CargarCiudadProveedor()
        {
            Coleccion col = new Coleccion();
            ddlCiudad.Items.Clear();
            foreach (Ciudad c in col.ObtenerCiudad())
            {
                ddlCiudad.Items.Add(new ListItem()
                {
                    Text = c.DESCRIPCION,
                    Value = c.ID_CIUDAD.ToString()
                });
            }
            ddlCiudad.DataBind();
        }
        private void CargarRubroProveedor()
        {
            Coleccion col = new Coleccion();
            ddlRubro.DataSource =
                (from rubro in col.ObtenerRubroProveedor()
                 select rubro.RUBRO).Distinct();
            ddlRubro.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor prove = new Proveedor()
                {
                    //RUT = int.Parse(txtRut.Text),
                    //DV = txtDV.Text
                };
                if (prove.Read())
                {
                    txtNombre.Text = prove.NOMBRE;
                    txtTelefono.Text = prove.TELEFONO.ToString();
                    ddlRubro.SelectedValue = prove.RUBRO;
                    //ddlCiudad.SelectedItem.Text = prove.Nombre_Ciudad;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor prove = new Proveedor();
                //prove.RUT = int.Parse(txtRut.Text);
                //prove.DV = txtDV.Text;

                if (prove.Read())
                {
                    prove.NOMBRE = txtNombre.Text;
                    prove.TELEFONO = int.Parse(txtTelefono.Text);
                    prove.RUBRO = ddlRubro.SelectedValue;
                    //prove.CIUDAD_ID_CIUDAD = int.Parse(ddlCiudad.SelectedValue);

                    //if (prove.Actualizar() == false)
                    //{
                    //    lblMensaje.Text = "La actualizacion ha fallado";
                    //    return;
                    //}
                    //else
                    //{
                    //    lblMensaje.Text = "Se ha actualizado exitosamente";
                    //    Limpiar();
                    //}
                }
                else
                {
                    prove.ID_PROVEEDOR = prove.GetId() + 1;
                    prove.NOMBRE = txtNombre.Text;
                    prove.TELEFONO = int.Parse(txtTelefono.Text);
                    prove.RUBRO = ddlRubro.SelectedValue;
                    //prove.CIUDAD_ID_CIUDAD = int.Parse(ddlCiudad.SelectedValue);

                    //if (prove.Registrar() == false)
                    //{
                    //    lblMensaje.Text = "El registro a fallado";
                    //    return;
                    //}
                    //else
                    //{
                    //    lblMensaje.Text = "Su Registro ha sido exitoso";
                    //    Limpiar();
                    //}
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
            }
        }

        private void Limpiar()
        {
            txtRut.Text = "";
            txtDV.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            ddlRubro.SelectedItem.Text = "";
            ddlCiudad.SelectedItem.Text = "";
        }
    }
}   