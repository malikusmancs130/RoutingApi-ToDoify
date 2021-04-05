using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoutingApi.Application.Common.Interfaces;
using RoutingApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoutingApi.Application.Common.Exceptions;

namespace RoutingApi.Application.TODO
{
    public class TodoHandler : ITodoHandler
    {
        private readonly IRepository<Domain.Entities.Todo> repository;
        private readonly IMapper _mapper;
        public TodoHandler(IRepository<Domain.Entities.Todo> repo, IMapper mapper)
        {
            repository = repo;
            _mapper = mapper;
        }
        public async Task<TodoDto> Create(TodoDto model)
        {
            try
            {
                var dbModel = new Domain.Entities.Todo 
                {
                    CreationTime=DateTime.UtcNow,
                    DueDate=model.DueDate,
                    IsCompleted=false,
                    IsDeleted=false,
                    TaskName=model.TaskName
                };
                var rowId = await repository.Add(dbModel);
                if (rowId > 0)
                {
                    return _mapper.Map<TodoDto>(dbModel);
                }
                else
                {
                    throw new ValidationException();
                }
            }
            catch(Exception exp)
            {
                throw exp;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                bool isDeleted = false;
                var task = await repository.TableNoTracking.Where(r => r.Id == Id).FirstOrDefaultAsync();
                if (task != null)
                {
                    var operationId=await repository.Delete(task);
                    isDeleted = operationId > 0;
                }
                return isDeleted;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public async  Task<List<TodoDto>> GetAll()
        {
            try
            {
                var result = await repository.TableNoTracking.ToListAsync();
                return _mapper.Map<List<TodoDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    public async Task<TodoAnalytics> GetAnalyticsForLastDays(int totalDays)
        {
            try
            {
                TodoAnalytics response = new TodoAnalytics();
                var daySince = DateTime.UtcNow.AddDays(-totalDays);
                var completed = await repository.TableNoTracking.Where(r => r.IsCompleted == true).ToListAsync();
                var inCompleted = await repository.TableNoTracking.Where(r => r.IsCompleted == false).ToListAsync();
                response.DaySince = daySince;
                response.CompletedItems = _mapper.Map<List<TodoDto>>(completed);
                response.NotCompletedItems = _mapper.Map<List<TodoDto>>(inCompleted);
                response.TotalRecords = response.CompletedItems.Count() + response.NotCompletedItems.Count();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TodoDto> GetById(int Id)
        {
            try
            {
                var todo = await repository.TableNoTracking.Where(r=>r.Id==Id).FirstOrDefaultAsync();
                if (todo == null)
                {
                    throw new NotFoundException("no record found for requested id");
                }
                return _mapper.Map<TodoDto>(todo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TodoDto> Update(TodoDto model)
        {
            try
            {
                var todo = await repository.TableNoTracking.Where(r => r.Id == model.Id).FirstOrDefaultAsync();
                if (todo == null)
                {
                    throw new NotFoundException("no record found for requested id");
                }
                if (model.IsCompleted == false)
                {
                    todo.DueDate = model.DueDate;
                    todo.IsCompleted = model.IsCompleted;
                    todo.TaskName = model.TaskName;
                    await repository.Update(todo);
                }
                else
                {
                    throw new NotFoundException("This Todo is already Completed.");
                }
                return _mapper.Map<TodoDto>(todo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
