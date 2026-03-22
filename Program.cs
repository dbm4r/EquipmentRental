using EquipmentRental.Models;
using EquipmentRental.Services;

class Program
{
    static void Main()
    {
        var service = new RentalService();

        var student = new Student { Id = 1, FirstName = "Omar", LastName = "Ali" };
        var employee = new Employee { Id = 2, FirstName = "John", LastName = "Smith" };

        var laptop = new Laptop { Id = 1, Name = "Dell", Ram = 16, Cpu = "i7" };
        var camera = new Camera { Id = 2, Name = "Canon", Megapixels = 24, LensType = "Wide" };
        var projector = new Projector { Id = 3, Name = "Epson", Lumens = 3000, Resolution = "Full HD" };

        service.AddUser(student);
        service.AddUser(employee);

        service.AddEquipment(laptop);
        service.AddEquipment(camera);
        service.AddEquipment(projector);

        Console.WriteLine("Correct rental:");
        service.RentEquipment(1, 1);

        Console.WriteLine();

        Console.WriteLine("Invalid rental:");
        try
        {
            service.RentEquipment(1, 1);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine();
        service.ShowAllEquipment();

        Console.WriteLine();

        Console.WriteLine("On-time return:");
        service.ReturnEquipment(1);

        Console.WriteLine();

        Console.WriteLine("Late return:");
        service.RentEquipment(2, 2);
        service.SetRentalDueDate(2, DateTime.Now.AddDays(-2));
        service.ReturnEquipment(2);

        Console.WriteLine();
        service.ShowAvailableEquipment();

        Console.WriteLine();
        service.ShowUserRentals(1);

        Console.WriteLine();
        service.ShowOverdueRentals();

        Console.WriteLine();
        service.ShowSummaryReport();
    }
}