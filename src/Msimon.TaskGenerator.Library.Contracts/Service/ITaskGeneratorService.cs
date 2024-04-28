using Msimon.TaskGenerator.Library.Contracts.Dto;

namespace Msimon.TaskGenerator.Library.Contracts.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaskGeneratorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TaskItemRsDto>> GetAllTask(bool onlyUncompleted = false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TaskItemRsDto>> SortTask();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskItemRqDto"></param>
        /// <returns></returns>
        public Task<TaskItemRsDto?> AddNewTask(TaskItemRqDto taskItemRqDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public Task<TaskItemRsDto?> CheckAsCompleted(int  taskId);
    }
}
