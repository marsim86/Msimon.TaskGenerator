using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msimon.TaskGenerator.Library.Contracts.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public record TaskItemRqDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string TaskName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string TaskDescription { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime OperationDate { get; set; }
    }
}
