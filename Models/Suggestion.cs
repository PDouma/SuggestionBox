using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Hosting;
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

        public int suggestionTypeId { get; set; }
        [ValidateNever] //TODO this is currently needed because data isnt sent correctly from frontend. Consider use of viewmodels or building the list from scratch
        public SuggestionType suggestionType { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime startDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime endDate { get; set; }

        public string[]? categories { get; set; }
    }
}
