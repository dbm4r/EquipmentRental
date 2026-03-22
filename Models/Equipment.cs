namespace EquipmentRental.Models
{
    public abstract class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsAvailable { get; set; } = true;
    }
}