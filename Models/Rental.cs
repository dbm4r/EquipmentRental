using System;

namespace EquipmentRental.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Equipment Equipment { get; set; } = null!;
        public DateTime RentDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double Penalty { get; set; }
    }
}