using Models;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.StockMovement
{
    public class StockMovementPostDTO
    {
        [Display(Name = "Tipo de movimento")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        [EnumDataType(typeof(MovementType), ErrorMessage = "Valor inválido para o campo {0}")]
        public MovementType MovementType { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "A {0} é obrigatorio")]
        public int Quantity { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public int ProductId { get; set; }

        public StockMovementPostDTO() { }
    }
}
