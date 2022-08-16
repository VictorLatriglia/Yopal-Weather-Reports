
namespace Weather_Report.Models
{
    public abstract class EntityBase : IEntityBase
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        protected EntityBase()
        {

            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.UtcNow.AddHours(-5);
            UpdatedOn = DateTime.UtcNow.AddHours(-5);
        }
    }
}
