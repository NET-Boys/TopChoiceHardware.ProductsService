namespace TopChoiceHardware.Products.Domain.DTOs
{
    public class ProductNotFoundResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }

        public ProductNotFoundResponse()
        {
            Status = "Error";
            Message = "El producto no existe.";
            Code = 404;
        }

    }
}
