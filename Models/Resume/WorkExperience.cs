using NPoco;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebsite.Models.Resume
{
    [TableName("work_experience")]
    [PrimaryKey("id")]
    public class WorkExperience
    {
        [Column("id")] 
        public string Id { get; set; }

        [Column("occupation")] 
        public string Occupation { get; set; } = string.Empty;

        [Column("company")] 
        public string Company { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM yyyy}")]
        [Column("start_date")] 
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM yyyy}")]
        [Column("end_date")] 
        public DateTime? EndDate { get; set; }

        [Column("short_desc")] 
        public string ShortDescHtml { get; set; } = string.Empty;

        [Column("responsibilities")] 
        public string[] Responsibilities { get; set; } = new string[] {};

        [Column("accomplishments")] 
        public string[] Accomplishments { get; set; } = new string[] {};
    }
}
