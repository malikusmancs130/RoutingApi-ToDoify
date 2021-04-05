using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingApi.Application.Common.Models
{
    [AutoMap(typeof(Domain.Entities.Todo))]
    public class TodoDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TodoAnalytics
    {
        public int TotalRecords { get; set; }
        public DateTime DaySince { get; set; }
        public List<TodoDto> CompletedItems { get; set; }
        public List<TodoDto> NotCompletedItems { get; set; }
    }
}
