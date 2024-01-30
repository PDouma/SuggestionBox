using System.ComponentModel.DataAnnotations;

namespace suggestionbox.Models
{
    public class Suggestion
    {
        public int id { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public int? userId { get; set; }
        public string? userName { get; set; }
        public string type { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime startDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime endDate { get; set; }

        public string[]? categories { get; set; }
    }
}
