using IST.Models.Shared;

namespace PushTasks.Hubs
{
    public interface ITasksHubClient
    {
        Task SendTasksToUser(List<UserTasksDTO> tasks);
        Task SendTaskToUser(UserTasksDTO task);
    }
}
