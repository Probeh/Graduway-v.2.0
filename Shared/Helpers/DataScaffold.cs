using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shared.Context;
using Shared.Enums;
using Shared.Models;

namespace Shared.Helpers
{
    public static class DataScaffold
    {
        public static async void Initialize(IApplicationBuilder builder)
        {
            DataContext context = builder
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<DataContext>();

            await context.Database.EnsureCreatedAsync();
            SetEmployees(context);
        }

        private static async void SetEmployees(DataContext context)
        {
            if (!(await context.Set<Employee>().AnyAsync()))
            {
                var stream = await File.ReadAllTextAsync("../Shared/Context/Employees.json");
                JsonConvert
                    .DeserializeObject<List<Employee>>(stream)
                    .ForEach(async(Employee member) =>
                        await context.Set<Employee>()
                        .AddAsync(new Employee(member.FirstName, member.LastName, member.Gender, member.Picture, member.Title, member.Description)
                        {
                            Tasks = GenerateTasks()
                        }));

                await context.SaveChangesAsync();
            }
        }

        private static List<EmployeeTask> GenerateTasks()
        {
            var items = new List<EmployeeTask>();

            for (var i = 0; i < new Random().Next(2, 50); i++)
            {
                var employeeTask = new EmployeeTask()
                {
                    Estimate = new TimeSpan(new Random().Next(24), new Random().Next(60), new Random().Next(60)),
                    Priority = (TaskPriority) new Random().Next(3),
                    State = (TaskState) new Random().Next(4),
                    Description = "Adipisicing nisi nisi in cupidatat nostrud ex ut non. Dolor voluptate amet reprehenderit anim. Sunt occaecat exercitation deserunt tempor occaecat exercitation Lorem magna est non ea. Non consectetur deserunt incididunt sint laborum dolore enim cillum id dolore. Do non ut enim adipisicing laborum proident laborum tempor et incididunt dolor consequat."
                };
                employeeTask.Title = $"Task #{employeeTask.GetHashCode()}";
                items.Add(employeeTask);
            }

            return items;
        }
    }
}