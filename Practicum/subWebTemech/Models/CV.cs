namespace subWebTemech.Models
{
    public class CV
    {
        public int CVId { get; set; }
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public int TranslateCVId { get; set; }
        public byte[] PdfFile { get; set; }
        public byte[] DocxFile { get; set; }
        public DateTime UploadDate { get; set; }
        public int AmountOfCV { get; set; }
        public bool Favorite { get; set; }

        // Navigation properties
        public virtual Language TransCV { get; set; }
        public virtual User User { get; set; }

    }
}