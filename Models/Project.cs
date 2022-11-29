using NPoco;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebsite.Models
{
    [TableName("projects")]
    [PrimaryKey("id")]
    public class Project
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        [Column("category")]
        public string ProjectCategory { get; set; } = string.Empty;

        [Display(Name = "Status")]
        [Column("status")]
        public string ProjectStatus { get; set; } = string.Empty;

        [Column("platform")]
        public string Platform { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; }

        [Display(Name = "Languages / Frameworks")]
        [Column("languages")]
        public string[] Languages { get; set; } = new string[] {};

        [Column("keywords")] 
        public string[] Keywords { get; set; } = new string[] {};

        [Display(Name = "Source Code")]
        [Column("src_code_link")] 
        public string? SourceCodeLink { get; set; }

        [Display(Name = "Demo")]
        [Column("demo_link")] 
        public string? DemoLink { get; set; }

        [Display(Name = "Distributed")]
        [Column("distr_link")] 
        public string? DistributionLink { get; set; }

        [Display(Name = "In short...")]
        [Column("short_desc_html")] 
        public string? ShortDescHtml { get; set; }

        [Display(Name = "Some more details...")]
        [Column("detailed_desc_html")]
        public string? DetailedDescHtml { get; set; }

        [Column("images")] 
        public string[]? Images { get; set; }

        [Display(Name = "Current Features")]
        [Column("current_features")] 
        public string[] CurrentFeatures { get; set; } = new string[] {};

        [Column("anticipated_features")] 
        public string[]? AnticipatedFeatures { get; set; }

        [Display(Name = "Likes")]
        [Column("favs")]
        public int Favs { get; set; }

        [Column("summary_bullets")]
        public string[] SummaryBulletPoints { get; set; } = new string[] { };

        [Column("put_on_resume")]
        public bool PutOnResume { get; set; }
    }
}
