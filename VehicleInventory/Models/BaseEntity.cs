using SQLite;

namespace VehicleInventory.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }

}
