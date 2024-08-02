using System;
using SpaceVc;

namespace SpaceVC
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomArray<Spaceship> fleet = new CustomArray<Spaceship>();

            // Sample data
            fleet.Add(new Spaceship { Name = "Apollo", Model = "X1", CrewCapacity = 5, MaxSpeed = 10000, Status = Status.Active, LaunchDate = DateTime.Now, MissionType = MissionType.Research });

            bool exit = false;
            while (!exit)
            {
                // Display menu options
                Console.WriteLine("1. Add Spaceship");
                Console.WriteLine("2. Search Spaceship");
                Console.WriteLine("3. Remove Spaceship");
                Console.WriteLine("4. Display Fleet");
                Console.WriteLine("5. Get Spaceship");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                // Handle menu selection
                switch (choice)
                {
                    case 1:
                        AddSpaceship(fleet);
                        break;
                    case 2:
                        SearchSpaceship(fleet);
                        break;
                    case 3:
                        RemoveSpaceship(fleet);
                        break;
                    case 4:
                        fleet.Print();
                        break;
                    case 5:
                        GetSpaceship(fleet);
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddSpaceship(CustomArray<Spaceship> fleet)
        {
            // Prompt user for spaceship details
            Console.Write("Enter spaceship name: ");
            string name = Console.ReadLine();
            Console.Write("Enter model: ");
            string model = Console.ReadLine();
            Console.Write("Enter crew capacity: ");
            int crewCapacity = int.Parse(Console.ReadLine());
            Console.Write("Enter max speed: ");
            double maxSpeed = double.Parse(Console.ReadLine());
            Console.Write("Enter status (Active, Inactive, Maintenance): ");
            Status status = (Status)Enum.Parse(typeof(Status), Console.ReadLine(), true);
            Console.Write("Enter launch date (yyyy-mm-dd): ");
            DateTime launchDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter mission type (Research, Transport, Military, Communications): ");
            MissionType missionType = (MissionType)Enum.Parse(typeof(MissionType), Console.ReadLine(), true);

            // Add new spaceship to the fleet
            fleet.Add(new Spaceship
            {
                Name = name,
                Model = model,
                CrewCapacity = crewCapacity,
                MaxSpeed = maxSpeed,
                Status = status,
                LaunchDate = launchDate,
                MissionType = missionType
            });

            Console.WriteLine("Spaceship added successfully!");
        }

        static void SearchSpaceship(CustomArray<Spaceship> fleet)
        {
            // Prompt user for spaceship name to search
            Console.Write("Enter spaceship name to search: ");
            string name = Console.ReadLine();
            int index = fleet.Search(new Spaceship { Name = name });

            // Display search result
            if (index != -1)
            {
                Console.WriteLine($"Spaceship found at index {index}");
            }
            else
            {
                Console.WriteLine("Spaceship not found");
            }
        }

        static void RemoveSpaceship(CustomArray<Spaceship> fleet)
        {
            // Prompt user for spaceship name to remove
            Console.Write("Enter spaceship name to remove: ");
            string name = Console.ReadLine();
            bool removed = fleet.Remove(new Spaceship { Name = name });

            // Display removal result
            if (removed)
            {
                Console.WriteLine("Spaceship removed successfully!");
            }
            else
            {
                Console.WriteLine("Spaceship not found");
            }
        }

        static void GetSpaceship(CustomArray<Spaceship> fleet)
        {
            // Prompt user for the index of the spaceship to get
            Console.Write("Enter the index of the spaceship to get: ");
            int index = int.Parse(Console.ReadLine());

            try
            {
                // Get and display the spaceship at the specified index
                Spaceship spaceship = fleet.Get(index);
                Console.WriteLine($"Spaceship at index {index}: {spaceship.Name}, {spaceship.Model}, {spaceship.CrewCapacity}, {spaceship.MaxSpeed}, {spaceship.Status}, {spaceship.LaunchDate}, {spaceship.MissionType}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
