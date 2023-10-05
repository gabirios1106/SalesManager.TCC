using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.Departments
{
    public class DepartmentPostDTO
    {
        [Display(Name = "Nome do departamento")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string DepartmentName { get; set; }

        public DepartmentPostDTO() { }
    }
}
