using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(string user_id);

        Task<bool> AddItemAsync(TodoItem newItem);

        Task<bool> MarkDoneAsync(int id);

        Task<bool> UpdateTitleAsync(int id, string title);

        Task<bool> UpdateStartDateAsync(int id, DateTimeOffset startdate);

        Task<bool> UpdateNumberOfDaysAsync(int id, int numberofdays);

        Task<bool> UpdatePriorityAsync(int id, int priority);

        Task<bool> UpdateDueDateAsync(int id, DateTimeOffset duedate);
    }
}