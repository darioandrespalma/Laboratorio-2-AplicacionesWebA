using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models
{
    [Table("Tipo_Producto")] // Mapea a la tabla exacta
    public class TipoProducto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;
    }
}