namespace EquipmentRental.Models
{
    public class Employee : User
    {
        public override int GetRentalLimit() => 5;
    }
}