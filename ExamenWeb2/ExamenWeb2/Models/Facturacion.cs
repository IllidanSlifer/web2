using ExamenWeb2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenWeb2.Models
{
    public class Facturacion
    {
        [Key]
        public int Id { get; set; }
        public double MontoTotal { get; set; }
        public double SubTotal { get; set; }
        public string Detalle { get; set; }

        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int ProductosID { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }

        public int InventarioID { get; set; }
        public virtual Inventario Inventario { get; set; }



        //        o Debe existir un módulo de facturación donde se pueda introducir en el encabezado de la factura 
        //            el cliente, la fecha, el monto total, subtotal, impuestos (read only). Luego se debe agregar 
        //            productos al detalle y actualizar los precios de monto total, subtotal, impuestos.
        //o Las facturas no se pueden eliminar ni editar solo deshabilitar.

    }
}