namespace zv_practica.Contracts
{
    public class GetOrderResponse
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }

            public DateTime? OrderDate { get; set; }

            public string? Login { get; set; }

            public double? Price { get; set; }

            public bool IsDeleted { get; set; }

            public string? DeliveryType { get; set; }

            public string? Status { get; set; }

       
    }
}
