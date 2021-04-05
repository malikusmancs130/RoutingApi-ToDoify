using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutingApi.Application.Common.Interfaces;
using RoutingApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingApi.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoifyController : BaseController<TodoifyController>
    {
        private readonly ITodoHandler _handler;

        public TodoifyController(ITodoHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<TodoDto>> GetAll()
        {
            return await _handler.GetAll();
        }

        [HttpPost]
        [Route("CreateTodo")]
        public async Task<TodoDto> CreateTodo(TodoDto model)
        {
            if (!ModelState.IsValid)
                throw new ValidationException();

            return await _handler.Create(model);
        }
        [HttpPost]
        [Route("DeleteTodo")]
        public async Task<bool> DeleteTodo(int Id)
        {
            if (!ModelState.IsValid)
                throw new ValidationException();

           return await _handler.Delete(Id);

        }

        [HttpPost]
        [Route("UpdateTodo")]
        public async Task<TodoDto> UpdateTodo(TodoDto model)
        {
            if (!ModelState.IsValid)
                throw new ValidationException();

            return await _handler.Update(model);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<TodoDto> GetById(int id)
        {
            return await _handler.GetById(id);
        }
        [HttpGet]
        [Route("GetAnalyticsForLastDays/{totalDays}")]
        public async Task<TodoAnalytics> GetAnalyticsForLastDays(int totalDays)
        {
            return await _handler.GetAnalyticsForLastDays(totalDays);
        }
    }
}
