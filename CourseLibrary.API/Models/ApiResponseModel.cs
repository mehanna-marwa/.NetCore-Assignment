namespace Products.API.Models
{
    public class ApiResponseModel
    {
        public bool IsValid { get; set; }

        public string[]? ValidationMessages { get; set; }

        public object? Data { get; set; } = new { };

        public ApiResponseModel(object? data, bool isValid = true, string[]? errorMessages = null)
        {
            Data = data;
            IsValid = isValid;
            ValidationMessages = errorMessages;
        }
    }
}
