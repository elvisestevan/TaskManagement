using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.MaintenanceProcessing
{
    public interface IAddTaskMaintenanceProcessor
    {
        Task AddTask(NewTask newTask);
    }
}
