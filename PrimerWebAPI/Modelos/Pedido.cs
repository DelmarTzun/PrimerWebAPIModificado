using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerWebAPI.Modelos
{
    [Table("pedidos_4544")]
    public class Pedido
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cliente_nombre")]
        public string ClienteNombre { get; set; }

        [Column("producto")]
        public string Producto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("fecha_pedido")]
        public DateTime FechaPedido { get; set; }

        [Column("estado")]
        public string Estado { get; set; }
    }
}