using NPoco;

namespace MyPortfolioWebsite.Models.Resume
{
    [TableName("hobbies_interests")]
    [PrimaryKey("id")]
    public class HobbyInterest
    {
        [Column("id")] 
        public string Id { get; set; }

        [Column("name")] 
        public string Name { get; set; } = string.Empty;

        [Column("icon_html")] 
        public string IconHtml { get; set; } = string.Empty;
    }
}
