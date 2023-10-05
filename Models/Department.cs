namespace Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Department() { }
    }
}
