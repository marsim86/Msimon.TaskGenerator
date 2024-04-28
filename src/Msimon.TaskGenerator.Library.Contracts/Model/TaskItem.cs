using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msimon.TaskGenerator.Library.Impl.Model
{
    /// <summary>
    /// 
    /// </summary>
    public record TaskItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int TaskId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TaskName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(1000)]
        public string TaskDescription { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public bool IsCompleted { get; set; } = false;
    }
}
