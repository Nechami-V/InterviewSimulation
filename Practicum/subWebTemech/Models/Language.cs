namespace subWebTemech.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public virtual ICollection<TranslateCV> TranslateCVs { get; set; } = new List<TranslateCV>();
    }
}




