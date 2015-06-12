using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.Data.Entities;

namespace TaskManagement.Data.QueryProcessors
{
    public interface ITaskByIdQueryProcessor
    {
        Task GetTask(long taskId);
    }
}
