using NPoco;

namespace MyPortfolioWebsite.Models.Resume
{
    [TableName("skills")]
    [PrimaryKey("id")]
    public class Skill
    {
        [Column("id")] 
        public string Id { get; set; }

        [Column("name")] 
        public string Name { get; set; } = string.Empty;

        [Column("category")] 
        public string Category { get; set; } = string.Empty;

        [Column("level")] 
        public string Proficiency { get; set; } = string.Empty;

        [Column("accomplishments")] 
        public string[]? Accomplishments { get; set; } = new string[] { };
    }
}
