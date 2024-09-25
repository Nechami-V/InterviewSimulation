using subWebTemech.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace subWebTemech.Models
{
    public class ExperienceLevel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }
        public int name { get; set; }

    }
}

