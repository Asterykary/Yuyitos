//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YUYITOS.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class CIUDAD
    {
        public CIUDAD()
        {
            this.PROVEEDOR = new HashSet<PROVEEDOR>();
        }
    
        public int ID_CIUDAD { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual ICollection<PROVEEDOR> PROVEEDOR { get; set; }
    }
}
