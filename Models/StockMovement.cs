namespace Models
{
    public class StockMovement
    {
        public int Id { get; set; }
        public MovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public StockMovement() { }
    }
}
