using EmployeeTaskSystem.Data;
using EmployeeTaskSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskSystem.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var provider = scope.ServiceProvider;

            var data = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();

            SeedEmployees(data);
            SeedTasks(data);

            data.SaveChanges();

            return app;
        }

        private static void SeedTasks(ApplicationDbContext data)
        {
            if (data.Tasks.Any() || data.CompletedTasks.Any())
            {
                return;
            }

            var employees = data.Employees.ToList();

            var random = new Random();

            data.Tasks.AddRange(new[]
            {
                new Data.Models.Task
                {
                    Title = "Walk the dog.",
                    Description = "Walk the dog for at least 15 minutes. Make sure it goes to the toilet.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Repair the printer.",
                    Description = "If you are unable to do it call a technician and pay him.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Fold the laundry.",
                    Description = "Separate clothes by color.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Feed the cat.",
                    Description = "Make sure you chance the cat's water too.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Go over the contract.",
                    Description = "Make sure we are not missing anything.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Call the client.",
                    Description = "Go over the details of the contract with the client.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Repair the printer.",
                    Description = "If you are unable to do it call a technician and pay him.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Write tests for the controllers in our app.",
                    Description = "Dont miss edge cases.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Move office equipment.",
                    Description = "Be very careful with those monitors, they are quite expensive.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Read the documentation.",
                    Description = "Read the whole thing trough, dont skip.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
                new Data.Models.Task
                {
                    Title = "Mentor the new employee for a day.",
                    Description = "Settle him in. Answer his questions. Make sure he does his job right.",
                    EmployeeId = employees[random.Next(employees.Count)].Id,
                    DueDate = DateTime.Now.AddDays(random.Next(20))
                },
            });
        }


        private static void SeedEmployees(ApplicationDbContext data)
        {
            if (data.Employees.Any())
            {
                return;
            }

            data.Employees.AddRange(new[]
            {
               new Employee
               {
                   FullName = "Nikolay Yanev Ivanov",
                   Email = "n1claren.93@gmail.com",
                   PhoneNumber = "0876858618",
                   DateOfBirth = new DateTime(year: 1993, month: 7, day: 9),
                   Salary = 15999
               },
               new Employee
               {
                   FullName = "John F. Kennedy",
                   Email = "J_f_K@CIA.com",
                   PhoneNumber = "(718) 656-4870",
                   DateOfBirth = new DateTime(year: 1917, month: 5, day: 29),
                   Salary = 5800
               },
               new Employee
               {
                   FullName = "Winston Leonard Spencer Churchill",
                   Email = "TheChurchill@yahoo.com",
                   PhoneNumber = "0800 200 326",
                   DateOfBirth = new DateTime(year: 1874, month: 11, day: 30),
                   Salary = 12700
               },
               new Employee
               {
                   FullName = "Vladimir Vladimirovich Putin",
                   Email = "bearguy@vkontakte.ru",
                   PhoneNumber = "8 800 200 23 16",
                   DateOfBirth = new DateTime(year: 1952, month: 10, day: 7),
                   Salary = 2475
               },
               new Employee
               {
                   FullName = "Joseph Robinette Biden",
                   Email = "sleepyJoe@gmail.com",
                   PhoneNumber = "202-456-1111",
                   DateOfBirth = new DateTime(year: 1942, month: 11, day: 20),
                   Salary = 8940
               },
               new Employee
               {
                   FullName = "Jeffrey Preston Bezos",
                   Email = "theBoss@amazon.com",
                   PhoneNumber = "202-456-1111",
                   DateOfBirth = new DateTime(year: 1964, month: 1, day: 12),
                   Salary = 150000
               },
               new Employee
               {
                   FullName = "Kevin Darnell Hart",
                   Email = "funnyGuy79@gmail.com",
                   PhoneNumber = "202-456-1111",
                   DateOfBirth = new DateTime(year: 1979, month: 7, day: 6),
                   Salary = 27450
               },
               new Employee
               {
                   FullName = "Margot Elise Robbie",
                   Email = "barbie__@gmail.com",
                   PhoneNumber = "+61 3 9866 1679",
                   DateOfBirth = new DateTime(year: 1990, month: 7, day: 2),
                   Salary = 55555
               },
               new Employee
               {
                   FullName = "James Francis Gunn",
                   Email = "CEO@DCcomics.com",
                   PhoneNumber = "818-980-7589",
                   DateOfBirth = new DateTime(year: 1966, month: 8, day: 5),
                   Salary = 13750
               }
           });
        }

    }
}
