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
    }
}
