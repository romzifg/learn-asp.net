using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Books title",
                        Description = "Books description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https.....",
                        DataAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "Books title 2",
                        Description = "Books description 2",
                        IsRead = false,
                        Genre = "Biography",
                        Author = "Second Author",
                        CoverUrl = "https.....",
                        DataAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
