using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<TodoItem[]> GetIncompleteItemsAsync(string userid)
        {
            var item1 = new TodoItem
            {
                Title = "Learn ASP.NET Core",
                StartDate = DateTime.Now,
                NumberofDays = 20,
                Priority = 5,
                DueAt = DateTimeOffset.Now.AddDays(31)
            };

            var item2 = new TodoItem
            {
                Title = "Build awesome apps",
                StartDate = DateTime.Now,
                NumberofDays = 4,
                Priority = 4,
                DueAt = DateTimeOffset.Now.AddDays(5)
            };

            var item3 = new TodoItem
            {
                Title = "Learn ASP.NET",
                StartDate = DateTime.Now,
                NumberofDays = 3,
                Priority = 3,
                DueAt = DateTimeOffset.Now.AddDays(4)
            };

            var item4 = new TodoItem
            {
                Title = "Build apps",
                StartDate = DateTime.Now,
                NumberofDays = 5,
                Priority = 2,
                DueAt = DateTimeOffset.Now.AddDays(6)
            };

            var item5 = new TodoItem
            {
                Title = "Build apps",
                StartDate = DateTime.Now,
                NumberofDays = 4,
                Priority = 1,
                DueAt = DateTimeOffset.Now.AddDays(4)
            };

            return Task.FromResult(new[] { item1, item2, item3, item4, item5 });
        }

        public Task<bool> AddItemAsync(TodoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkDoneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTitleAsync(int id, string title)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStartDateAsync(int id, DateTimeOffset startdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNumberOfDaysAsync(int id, int numberofdays)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePriorityAsync(int id, int priority)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDueDateAsync(int id, DateTimeOffset duedate)
        {
            throw new NotImplementedException();
        }
    }
}