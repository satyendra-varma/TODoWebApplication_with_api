using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Net.Http.Headers;


namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly HttpClient _httpClient;
        private readonly MediaTypeHeaderValue mediaType = new MediaTypeHeaderValue("application/json");
        private readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public TodoItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri("http://todoitemapi:5217");
            _httpClient.BaseAddress = new Uri("http://localhost:5206");
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync(string user_id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/items/" + user_id );
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var items = JsonSerializer.Deserialize<TodoItem[]>(content, jsonSerializerOptions);
                if(items==null){
                    throw new Exception("items not found");
                }
                else{
                    return items;
                }
            }
            else
            {
                throw new Exception("items not found");
            }
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.IsDone = false;
            /*
            var content = JsonContent.Create(newItem, typeof(newItem), JsonSerializerOptions);
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/items/additem");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            */
            var content = JsonContent.Create(newItem, typeof(TodoItem), mediaType);
            var response = await _httpClient.PostAsync("/api/items/additem", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> MarkDoneAsync(int id)
        {
            var response = await _httpClient.PutAsync("/api/items/" + id +"/markdone", null);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTitleAsync(int id, string title)
        {
            var content = JsonContent.Create(title, typeof(string), mediaType);
            var response = await _httpClient.PutAsync("/api/items/" + id +"/updatetitle", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateStartDateAsync(int id, DateTimeOffset startdate)
        {
            var content = JsonContent.Create(startdate, typeof(DateTimeOffset), mediaType);
            var response = await _httpClient.PutAsync("/api/items/" + id + "/updatestartdate", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateNumberOfDaysAsync(int id, int numberofdays)
        {
            var content = JsonContent.Create(numberofdays, typeof(int), mediaType);
            var response = await _httpClient.PutAsync("/api/items/" + id + "/updatedays", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePriorityAsync(int id, int priority)
        {
            var content = JsonContent.Create(priority, typeof(int), mediaType);
            var response = await _httpClient.PutAsync("/api/items/" + id + "/updatepriority", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateDueDateAsync(int id, DateTimeOffset duedate)
        {
            var content = JsonContent.Create(duedate, typeof(DateTimeOffset), mediaType);
            var response = await _httpClient.PutAsync("/api/items/" + id + "/updateduedate", content);

            return response.IsSuccessStatusCode;
        }
    }

}
