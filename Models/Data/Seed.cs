using Microsoft.EntityFrameworkCore;
using suggestionbox.Data;

namespace suggestionbox.Models.Data
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new suggestionboxContext(
                serviceProvider.GetRequiredService<DbContextOptions<suggestionboxContext>>()))
            {
                if (context.Suggestion.Any())
                {
                    return;   // DB has already been seeded
                }

                context.Suggestion.AddRange(
                    new Suggestion
                    {
                        subject = "Beleg",
                        description = "Ik mis X of Y",
                        userId = 31,
                        userName = "Dirk",
                        type = "suggestie",
                        startDate = DateTime.Now,
                        endDate = DateTime.Today.AddDays(1),
                        categories = new[]
                        {
                            "fun",
                            "intern"
                        }
                    },
                    new Suggestion
                    {
                        subject = "Uitje",
                        description = "Teamuitje naar de stad",
                        type = "suggestie",
                        startDate = DateTime.Today.AddDays(3),
                        endDate = DateTime.Today.AddDays(3),
                        categories = new[]
                        {
                            "borrel"
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
