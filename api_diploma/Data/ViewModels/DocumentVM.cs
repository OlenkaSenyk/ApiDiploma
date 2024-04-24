namespace api_diploma.Data.ViewModels
{
    public class DocumentVM
    {
        public string Type { get; set; }
        public string Number { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public byte[] ScanCopy { get; set; }
    }
}
