using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ToDoListApi.Controllers;

[ApiController]
[Route("api/items")]
public class ToDoController : ControllerBase
{
    private readonly ILogger<ToDoController> _logger;
    private readonly DataContext _context;

    public ToDoController(ILogger<ToDoController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    /*  [HttpGet(Name = "GetWeatherForecast")]
      public IEnumerable<TodoItem> Get()
      {
          return Enumerable.Range(1, 5).Select(index => new WeatherForecast
          {
              Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
              TemperatureC = Random.Shared.Next(-20, 55),
              Summary = Summaries[Random.Shared.Next(Summaries.Length)]
          })
          .ToArray();
      }*/


    [HttpGet("{user_id}")]
    public async Task<TodoItem[]> GetIncompleteItemsAsync(string user_id)
    {
        var items = await _context.Items
            .Where(x => x.IsDone == false && x.UserId == user_id)
            .ToArrayAsync();
        return items;
    }
    
    [HttpPost]
    [Route("additem")]
    public async Task<bool> AddItemAsync([FromBody]TodoItem newItem)
    {
        newItem.IsDone = false;

        _context.Items.Add(newItem);

        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
    }
    
    [HttpPut("{id}/markdone")]
    public async Task<bool> MarkDoneAsync(int id)
    {
        var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

        if (item == null) return false;

        item.IsDone = true;

        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
    }
    
    [HttpPut("{id}/updatetitle")]
    public async Task<bool> UpdateTitleAsync(int id, [FromBody] string title)
    {
        var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

        if (item == null) return false;

        item.Title = title;

        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
    }

    [HttpPut("{id}/updatestartdate")]
    public async Task<bool> UpdateStartDateAsync(int id, [FromBody] DateTimeOffset startdate)
    {
        var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

        if (item == null) return false;

        item.StartDate = startdate;

        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
    }

    [HttpPut("{id}/updatedays")]
    public async Task<bool> UpdateNumberOfDaysAsync(int id, [FromBody] int numberofdays)
    {
        var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

        if (item == null) return false;

        item.NumberofDays = numberofdays;

        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
    }

    [HttpPut("{id}/updatepriority")]
    public async Task<bool> UpdatePriorityAsync(int id, [FromBody] int priority)
    {
        var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

        if (item == null)
        {
            return false;
        }

        item.Priority = priority;


        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
    }

    [HttpPut("{id}/updateduedate")]
    public async Task<bool> UpdateDueDateAsync(int id, [FromBody] DateTimeOffset duedate)
    {
        var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

        if (item == null) return false;

        item.DueAt = duedate;

        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
    }
}
