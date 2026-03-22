namespace EquipmentRental.Models
{
    public class Laptop : Equipment
    {
        public int Ram { get; set; }
        public string Cpu { get; set; } = null!;
    }
}