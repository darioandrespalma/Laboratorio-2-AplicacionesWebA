using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_tipo")]
        public int IdTipo { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("valor")]
        public double Valor { get; set; }

        [Column("costo")]
        public double Costo { get; set; }

        [ForeignKey("IdTipo")]
        public TipoProducto? TipoProducto { get; set; }
    }
}