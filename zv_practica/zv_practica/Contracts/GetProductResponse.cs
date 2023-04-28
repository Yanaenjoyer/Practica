namespace zv_practica.Contracts
{
    public class GetProductResponse
    {
        public int ProductId { get; set; }

        public double? ProductPrice { get; set; }

        public double? ProductWeight { get; set; }

        public double? ProductLenght { get; set; }

        public double? ProductWidth { get; set; }

        public string? Comment { get; set; }

        public bool IsDeleted { get; set; }

        public int? SumProduct { get; set; }

    }
}
