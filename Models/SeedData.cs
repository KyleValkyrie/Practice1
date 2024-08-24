using Microsoft.EntityFrameworkCore;
using Practice1.Data;

namespace Practice1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Practice1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Practice1Context>>()))
            {
                // Look for any movies.
                if (context.Randoms.Any())
                {
                    return;   // DB has been seeded
                }
                context.Randoms.AddRange(
                    new Randoms
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Description = "Romantic Comedy",
                        Number = 7.99M
                    },
                    new Randoms
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Description = "Comedy",
                        Number = 8.99M
                    },
                    new Randoms
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Description = "Comedy",
                        Number = 9.99M
                    },
                    new Randoms
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Description = "Western",
                        Number = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
