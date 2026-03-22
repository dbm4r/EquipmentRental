namespace EquipmentRental.Models
{
    public class Student : User
    {
        public override int GetRentalLimit() => 2;
    }
}