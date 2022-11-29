using NPoco;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebsite.Models.Resume
{
    [TableName("education")]
    [PrimaryKey("id")]
    public class Education
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;

        [Column("degree")] 
        public string Degree { get; set; } = string.Empty;

        [Column("major")] 
        public string Major { get; set; } = string.Empty;
        
        [Column("institute_name")] 
        public string InstituteName { get; set; } = string.Empty;

        [Column("institute_city")] 
        public string InstituteCity { get; set; } = string.Empty;
    }
}
