using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.InquiryProcessing
{
    public interface ITaskByIdInquiryProcessor
    {
        Task GetTask(long taskId);
    }
}
