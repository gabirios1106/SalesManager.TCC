﻿using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.Products
{
    public class ProductPostDTO
    {
        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public string ProductName { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public double Price { get; set; }

        [Display(Name = "Estoque mínimo")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public int MinimumStock { get; set; }

        [Display(Name = "Quantidade em estoque")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public int BalanceStock { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "O {0} é obrigatorio")]
        public int DepartmentId { get; set; }

        public ProductPostDTO() { }
    }
}
