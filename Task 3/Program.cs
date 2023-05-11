using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_3
{
    class Program
    {
        //Defines a class for vehicles with all appropriate attributes 
        internal class Vehicle
        {
            public string Registration { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public string FuelType { get; set; }
        }

        static void Main()
        {
            // Imports data from CSV file
            var filePath = ("Technical Test Data.csv");
            var lines = File.ReadAllLines(filePath).Skip(1);
            var vehicles = lines.Select(line => line.Split(','))
                .Select(fields => new Vehicle
                {
                    Registration = fields[0],
                    Make = fields[1],
                    Model = fields[2],
                    Color = fields[3],
                    FuelType = fields[4],
                })
                .ToList();
#if DEBUG
            Console.WriteLine("Importing from CSV...");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Reg: {vehicle.Registration}, Make: {vehicle.Make}, Model: {vehicle.Model}, Color: {vehicle.Color}, Fuel Type: {vehicle.FuelType}");
            }
#endif
            // Removes duplicates by vehicle registration
            var uniqueVehicles = vehicles
                .GroupBy(v => v.Registration)
                .Select(g => g.First())
                .ToList();
#if DEBUG
            Console.WriteLine("Removing duplicates...");
            foreach (var vehicle in uniqueVehicles)
            {
                Console.WriteLine($"Reg: {vehicle.Registration}, Make: {vehicle.Make}, Model: {vehicle.Model}, Color: {vehicle.Color}, Fuel Type: {vehicle.FuelType}");
            }
#endif

            // Creates a CSV for each unique fuel type in the CSV
            var fuelTypes = uniqueVehicles.Select(v => v.FuelType).Distinct();
            foreach (var fuelType in fuelTypes)
            {
                var fuelTypeVehicles = uniqueVehicles.Where(v => v.FuelType == fuelType);
                var fuelTypeLines = new List<string> { "Registration,Make,Model,FuelType,Color,Year" };
                foreach (var vehicle in fuelTypeVehicles)
                {
                    fuelTypeLines.Add($"{vehicle.Registration},{vehicle.Make},{vehicle.Model},{vehicle.FuelType},{vehicle.Color}");
                }
                File.WriteAllLines($"{fuelType}.csv", fuelTypeLines);
            }

            // Finds vehicles with valid registration and writes them to a list
            var validRegistrationVehicles = uniqueVehicles
                .Where(v => v.Registration.Length == 8 && v.Registration[0..2].All(char.IsLetter) && v.Registration[2..4].All(char.IsDigit) && v.Registration[4] == ' ' && v.Registration[5..].All(char.IsLetter))
                .ToList();
            //Prints the registrations of the vehicles in the validRegistrationVehicles list
            Console.WriteLine("Vehicles with valid registration:");
            validRegistrationVehicles.ForEach(i => Console.Write("{0},", i.Registration));
            Console.Write("\n");


            // Counts vehicles without valid registration and prints the number
            var invalidRegistrationCount = uniqueVehicles.Count - validRegistrationVehicles.Count;
            Console.WriteLine($"Number of vehicles without valid registration: {invalidRegistrationCount}");

        }
    }
}
