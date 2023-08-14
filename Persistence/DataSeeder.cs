using Domain;

namespace Persistence
{
    public static class DataSeeder
    {
        public static DataContext SeedDbContext(this DataContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Children.Any())
            {
                var children = new Child[] {
                    new Child {
                        Id = Guid.NewGuid(),
                        Name = "Petras",
                        Surname = "Petraitis",
                        Presents = new List<Present> {
                            new Present {
                                Id = Guid.NewGuid(),
                                Name = "Traktorius"
                            },
                            new Present {
                                Id = Guid.NewGuid(),
                                Name = "Kamuolys"
                            }
                        }
                    },
                    new Child {
                        Id = Guid.NewGuid(),
                        Name = "Marytė",
                        Surname = "Marytytė",
                        Presents = new List<Present> {
                            new Present {
                                Id = Guid.NewGuid(),
                                Name = "Lėlė"
                            }
                        }
                    },
                    new Child {
                        Id = Guid.NewGuid(),
                        Name = "Jonas",
                        Surname = "Jonaitis"
                    },
                };

                context.AddRange(children);
                context.SaveChanges();
            }

            return context;
        }
    }
}