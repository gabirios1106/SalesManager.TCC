using Models;

namespace DataTransferObjects.StockMovement
{
    public class StockMovementGetDTO
    {
        public MovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public StockMovementGetDTO() { }
    }
}
