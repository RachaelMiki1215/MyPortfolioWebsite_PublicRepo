using System.ComponentModel.DataAnnotations;
using NPoco;

namespace MyPortfolioWebsite.Models
{
    [TableName("articles")]
    [PrimaryKey("id")]
    public class Article
    {
        [Column("id")] 
        public string Id { get; set; }

        [Column("title")] 
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Column("updated_date")] 
        public DateTime UpdatedDate { get; set; }

        [Column("content_html")] 
        public string ContentHtml { get; set; } = string.Empty;

        [Column("images")] 
        public string[]? Images { get; set; }

        [Column("keywords")] 
        public string[]? Keywords { get; set; }

        [Display(Name = "Likes")]
        [Column("favs")]
        public int Favs { get; set; }
    }
}
