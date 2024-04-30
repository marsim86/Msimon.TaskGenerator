namespace Msimon.TaskGenerator.Library.Contracts.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public record TaskItemRsDto
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
        public DateTime? OperationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCompleted { get; set; } = false;
    }
}
