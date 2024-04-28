using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Msimon.TaskGenerator.Library.Contracts.Dto;
using Msimon.TaskGenerator.Library.Contracts.Service;

namespace Msimon.TaskGenerator.WebApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class TaskController(ITaskGeneratorService taskGeneratorService) : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllTask")]
        [ProducesResponseType(typeof(IEnumerable<TaskItemRsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> GetAllTask()
        {
            var result = await taskGeneratorService.GetAllTask();
            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("InsertTask")]
        public async Task<ActionResult> InsertTask(TaskItemRqDto taskItemRqDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var result = await taskGeneratorService.AddNewTask(taskItemRqDto);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("SortTask")]
        public async Task<ActionResult> SortTask()
        {
            var result = await taskGeneratorService.SortTask();
            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("CheckTaskAsCompleted/{taskId}")]
        public async Task<ActionResult> CheckTask(int taskId)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var result = await taskGeneratorService.CheckAsCompleted(taskId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
