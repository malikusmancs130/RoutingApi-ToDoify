using RoutingApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoutingApi.Application.Common.Interfaces
{
    public interface ITodoHandler
    {
        //create, update, delete and get
        Task<TodoDto> Create(TodoDto model);
        Task<TodoDto> Update(TodoDto model);
        Task<bool> Delete(int Id);
        Task<TodoDto> GetById(int Id);
        Task<List<TodoDto>> GetAll();
        Task<TodoAnalytics> GetAnalyticsForLastDays(int totalDays);
    }
}
