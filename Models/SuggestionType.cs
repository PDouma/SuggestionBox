using System.ComponentModel.DataAnnotations;

namespace suggestionbox.Models
{
    public class SuggestionType
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool require_daterange { get; set; }

        public ICollection<Suggestion> suggestions { get; } = new List<Suggestion>();
    }
}
