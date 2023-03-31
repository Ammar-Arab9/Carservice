using System;
using System.Collections.Generic;
using System.IO;

public class CarService
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Hello Mono World");
		
		
		LoadCarsData("autos (3).csv");

        // Use the loaded data
        foreach (Dictionary<string, string> row in data)
        {
            Console.WriteLine(row["make"] + ", " + row["num-of-doors"] + ", " + row["body-style"] + ", " + row["engine-location"] + ", " + row["num-of-cylinders"] + ", " + row["horsepower"] + ", " + row["price"]);
        }

        // This is for to call the method again, but this time it should not do anything
        LoadCarsData("autos (3).csv");
		
		
		
    }
    
    /*
    Loads cars data from "autos.csv" file and store in memory. If cars data is already loaded, then this method should not do anything.
    */
    public void LoadCarsData("autos (3).csv")
    {
        if (data != null)
        {
            // Data already loaded, so do nothing
            return;
        }

        data = new List<Dictionary<string, string>>();

        using (var reader = new StreamReader(filePath))
        {
            // Read the header line
            var header = reader.ReadLine();
            var columns = header.Split(',');

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var row = new Dictionary<string, string>();
                for (int i = 0; i < columns.Length; i++)
                {
                    row[columns[i]] = values[i];
                }

                data.Add(row);
            }
        }
    }
    
    /*
    Filters the loaded cars data using the provided filter and returns a list of cars. You should implement Car and CarFilter classes. The caller of this method should be able to filter cars based on their make, hourse power range, price range, number of doors and number of cylinders.
    */
	
	public class Car 
	{
		public string Make { get; set; }
		public int HorsePower { get; set; }
		public decimal Price { get; set; }
		public int NumberOfDoors { get; set; }
		public int NumberOfCylinders { get; set; }
	}










    
	public class CarFilter {
		public string Make { get; set; }
		public int? MinHorsePower { get; set; }
		public int? MaxHorsePower { get; set; }
		public decimal? MinPrice { get; set; }
		public decimal? MaxPrice { get; set; }
		public int? NumberOfDoors { get; set; }
		public int? NumberOfCylinders { get; set; }

		public bool Matches(Car car) {
			if (Make != null && car.Make != Make) {
				return false;
			}
			if (MinHorsePower != null && car.HorsePower < MinHorsePower) {
				return false;
			}
			if (MaxHorsePower != null && car.HorsePower > MaxHorsePower) {
				return false;
			}
			if (MinPrice != null && car.Price < MinPrice) {
				return false;
			}
			if (MaxPrice != null && car.Price > MaxPrice) {
				return false;
			}
			if (NumberOfDoors != null && car.NumberOfDoors != NumberOfDoors) {
				return false;
			}
			if (NumberOfCylinders != null && car.NumberOfCylinders != NumberOfCylinders) {
				return false;
			}
			return true;
		}
	}

	public class CarFilterer {
		public List<Car> FilterCars(List<Car> cars, CarFilter filter) {
			List<Car> filteredCars = new List<Car>();
			foreach (Car car in cars) {
				if (filter.Matches(car)) {
					filteredCars.Add(car);
				}
			}
			return filteredCars;
		}
	}


}