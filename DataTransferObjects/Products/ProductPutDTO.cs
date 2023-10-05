using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.Products
{
    public class ProductPutDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public string ProductName { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public double Price { get; set; }

        [Display(Name = "Estoque mínimo")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public int MinimumStock { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public int DepartmentId { get; set; }

        public ProductPutDTO() { }

        public ProductPutDTO(ProductGetDTO productGetDTO)
        {
            Id = productGetDTO.Id;
            ProductName = productGetDTO.ProductName;
            Price = productGetDTO.Price;
            MinimumStock = productGetDTO.MinimumStock;
            DepartmentId = productGetDTO.DepartmentId;
        }
    }
}
