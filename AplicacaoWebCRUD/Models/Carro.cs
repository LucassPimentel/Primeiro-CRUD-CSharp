using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoWebCRUD.Models
{
    public class Carro
    {

        [Key]
        [Column("Id_Carro")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(100)]
        public string Marca { get; set; }
        [Required]
        public int Potencia { get; set; }

    }
}
