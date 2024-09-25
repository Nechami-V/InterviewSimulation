namespace subWebTemech.Models
{
    public class TranslateCV
    {
        public int TranslateCVId { get; set; }
        public int LanguageId { get; set; }
        public int CVId { get; set; }
        public virtual Language Language { get; set; }
        public virtual CV CV { get; set; }
    }
}

