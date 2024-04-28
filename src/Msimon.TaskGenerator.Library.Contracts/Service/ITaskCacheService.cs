
using Msimon.TaskGenerator.Library.Impl.Model;

namespace Msimon.TaskGenerator.Library.Contracts.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaskCacheService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TaskItem> GetTasks();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public bool AddTask(TaskItem task);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public bool AddTask(IEnumerable<TaskItem> tasks);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public bool UpdateTask(TaskItem task);
    }
}
