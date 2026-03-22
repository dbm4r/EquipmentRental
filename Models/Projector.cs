namespace EquipmentRental.Models
{
    public class Projector : Equipment
    {
        public int Lumens { get; set; }
        public string Resolution { get; set; } = null!;
    }
}