namespace EquipmentRental.Models
{
    public class Camera : Equipment
    {
        public int Megapixels { get; set; }
        public string LensType { get; set; } = null!;
    }
}