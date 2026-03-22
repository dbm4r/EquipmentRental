using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentRental.Services
{
    public class RentalService
    {
        private List<User> users = new();
        private List<Equipment> equipments = new();
        private List<Rental> rentals = new();

        private int rentalIdCounter = 1;

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void AddEquipment(Equipment equipment)
        {
            equipments.Add(equipment);
        }

        public void RentEquipment(int userId, int equipmentId, int rentalDays = 7)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);
            var equipment = equipments.FirstOrDefault(e => e.Id == equipmentId);

            if (user == null || equipment == null)
                throw new Exception("User or Equipment not found");

            if (!equipment.IsAvailable)
                throw new Exception("Equipment not available");

            int activeRentals = rentals.Count(r => r.User.Id == userId && r.ReturnDate == null);

            if (activeRentals >= user.GetRentalLimit())
                throw new Exception("Rental limit exceeded");

            var rental = new Rental
            {
                Id = rentalIdCounter++,
                User = user,
                Equipment = equipment,
                RentDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(rentalDays)
            };

            rentals.Add(rental);
            equipment.IsAvailable = false;
        }

        public void ReturnEquipment(int rentalId)
        {
            var rental = rentals.FirstOrDefault(r => r.Id == rentalId);

            if (rental == null)
                throw new Exception("Rental not found");

            if (rental.ReturnDate != null)
                throw new Exception("Equipment already returned");

            rental.ReturnDate = DateTime.Now;

            if (rental.ReturnDate > rental.DueDate)
            {
                int daysLate = (rental.ReturnDate.Value - rental.DueDate).Days;
                rental.Penalty = daysLate * 5;
            }

            rental.Equipment.IsAvailable = true;

            Console.WriteLine($"Returned: {rental.Equipment.Name}");

            if (rental.Penalty > 0)
                Console.WriteLine($"Late! Penalty: {rental.Penalty}");
            else
                Console.WriteLine("Returned on time");
        }

        public void MarkEquipmentUnavailable(int equipmentId)
        {
            var equipment = equipments.FirstOrDefault(e => e.Id == equipmentId);

            if (equipment == null)
                throw new Exception("Equipment not found");

            equipment.IsAvailable = false;
        }

        public void ShowAllEquipment()
        {
            Console.WriteLine("All equipment:");
            foreach (var e in equipments)
                Console.WriteLine($"{e.Id} - {e.Name} - Available: {e.IsAvailable}");
        }

        public void ShowAvailableEquipment()
        {
            Console.WriteLine("Available equipment:");
            foreach (var e in equipments.Where(e => e.IsAvailable))
                Console.WriteLine($"{e.Id} - {e.Name}");
        }

        public void ShowUserRentals(int userId)
        {
            Console.WriteLine($"Active rentals for user {userId}:");
            foreach (var r in rentals.Where(r => r.User.Id == userId && r.ReturnDate == null))
                Console.WriteLine($"Rental {r.Id} - {r.Equipment.Name} - Due: {r.DueDate.ToShortDateString()}");
        }

        public void ShowOverdueRentals()
        {
            Console.WriteLine("Overdue rentals:");
            foreach (var r in rentals.Where(r => r.ReturnDate == null && r.DueDate < DateTime.Now))
                Console.WriteLine($"{r.Equipment.Name} rented by {r.User.FirstName} {r.User.LastName}");
        }

        public void ShowSummaryReport()
        {
            Console.WriteLine("Summary report:");
            Console.WriteLine($"Users: {users.Count}");
            Console.WriteLine($"Equipment items: {equipments.Count}");
            Console.WriteLine($"Available equipment: {equipments.Count(e => e.IsAvailable)}");
            Console.WriteLine($"Active rentals: {rentals.Count(r => r.ReturnDate == null)}");
            Console.WriteLine($"Completed rentals: {rentals.Count(r => r.ReturnDate != null)}");
            Console.WriteLine($"Overdue rentals: {rentals.Count(r => r.ReturnDate == null && r.DueDate < DateTime.Now)}");
            Console.WriteLine($"Total penalties: {rentals.Sum(r => r.Penalty)}");
        }

        public void SetRentalDueDate(int rentalId, DateTime newDueDate)
        {
            var rental = rentals.FirstOrDefault(r => r.Id == rentalId);

            if (rental == null)
                throw new Exception("Rental not found");

            rental.DueDate = newDueDate;
        }
    }
}