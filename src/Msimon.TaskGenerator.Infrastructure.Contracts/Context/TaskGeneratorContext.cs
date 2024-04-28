using Microsoft.EntityFrameworkCore;
using Msimon.TaskGenerator.Infrastructure.Contracts.Model;
namespace Msimon.TaskGenerator.Infrastructure.Contracts.Context
{
    public class TaskGeneratorContext(DbContextOptions<TaskGeneratorContext> options) : DbContext(options)
    {
        public virtual DbSet<TaskItemModel> TaskItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder),
                    "modelBuilder cannot be null");

            modelBuilder.Entity<TaskItemModel>(entity =>
            {
                entity.HasKey(x => x.TaskId);
                //Aqui van todas las propiedades
            });
        }
    }
}
