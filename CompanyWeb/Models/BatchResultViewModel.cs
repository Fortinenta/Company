namespace CompanyWeb.Models
{
    public class BatchResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int SuccessCount { get; set; }
        public int ErrorCount { get; set; }
    }
}
