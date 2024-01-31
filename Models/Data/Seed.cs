using Microsoft.EntityFrameworkCore;
using suggestionbox.Data;
using System;

namespace suggestionbox.Models.Data
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new suggestionboxContext(
                serviceProvider.GetRequiredService<DbContextOptions<suggestionboxContext>>()))
            {
                SeedSuggestionType(context);
            }
        }

        public static void SeedSuggestionType(suggestionboxContext context)
        {
            if (context.SuggestionType.Any())
            {
                return;   // SuggestionType has already been seeded
            }

            context.SuggestionType.AddRange(
                new SuggestionType
                {
                    name = "suggestie",
                    description = ""
                },
                new SuggestionType
                {
                    name = "uitje",
                    description = "",
                    require_daterange = true
                }
            );

            context.SaveChanges();
        }
    }
}
