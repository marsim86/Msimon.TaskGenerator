using Microsoft.Extensions.Caching.Memory;
using Msimon.TaskGenerator.Library.Contracts.Service;
using Msimon.TaskGenerator.Library.Impl.Model;

namespace Msimon.TaskGenerator.Library.Impl.Service
{
    public class TaskCacheService(IMemoryCache memoryCache) : ITaskCacheService
    {
        private const string CACHE_NAME = "taskCache";
        public IEnumerable<TaskItem> GetTasks()
        {

            try
            {

                _ = !memoryCache.TryGetValue(CACHE_NAME, out var task);

                return (List<TaskItem>)(task ?? new List<TaskItem>());
            }
            catch (Exception ex)
            {
                //Pinta Logs
                Console.WriteLine(ex.ToString());
                return Enumerable.Empty<TaskItem>();
            }
        }

        public bool AddTask(TaskItem task)
        {
            try
            {
                _ = !memoryCache.TryGetValue(CACHE_NAME, out var objList);

                List<TaskItem> taskList = (List<TaskItem>)(objList ?? new List<TaskItem>());
                taskList.Add(task);

                memoryCache.Set(CACHE_NAME, taskList);
            }
            catch (Exception ex)
            {
                //Pinta Logs
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public bool AddTask(IEnumerable<TaskItem> tasks)
        {
            try
            {
                _ = !memoryCache.TryGetValue(CACHE_NAME, out var objList);

                List<TaskItem> taskList = (List<TaskItem>)(objList ?? new List<TaskItem>());
                taskList.AddRange(tasks);

                memoryCache.Set(CACHE_NAME, taskList);
            }
            catch (Exception ex)
            {
                //Pinta Logs
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public bool UpdateTask(TaskItem task)
        {
            try
            {
                _ = !memoryCache.TryGetValue(CACHE_NAME, out var objList);

                List<TaskItem> taskList = (List<TaskItem>)(objList ?? new List<TaskItem>());

                var newTaskList = taskList.Select(x => x.TaskId == task.TaskId ? task : x).ToList();
                memoryCache.Set(CACHE_NAME, newTaskList);
            }
            catch (Exception ex)
            {
                //Pinta Logs
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }



    }
}
