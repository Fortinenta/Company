using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Models
{
    public class UploadedFile
    {
        public int Id { get; set; }

        [Required]
        public string OriginalFileName { get; set; } = string.Empty;

        [Required]
        public string StoredFileName { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;

        public DateTime UploadDate { get; set; }

        public long Size { get; set; }

        public string Status { get; set; } = string.Empty; // e.g., "Pending", "Processed", "Failed"

        // Optional: Link to a batch process if needed
        public int? BatchProcessId { get; set; }
    }
}
