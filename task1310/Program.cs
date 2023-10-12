namespace task1310
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[]
          {
            new Car("Toyota", "Prado", "Gray", 1, "City", 4, false),
            new Car("Tesla", "Model S", "Red", 2.0, "Highway", 4, true),
            new Bicycle("Schwinn", "Cruiser", "Green", 1.0, "Park", "Cruiser"),
            new Bicycle("Giant", "Mountain Bike", "Black", 2.0, "Off-road", "Mountain"),
          };

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(" Vehicle Info ");
                Console.WriteLine(vehicle);
                vehicle.GetInfo();
                Console.WriteLine("Average Speed: " + vehicle.AverageSpeed() + " km/h");
                Console.WriteLine();
            }
        }
    }
    public abstract class Vehicle
    {
        public string FactoryName { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double DriveTime { get; set; }
        public string DrivePath { get; set; }
        public DateTime ProductionDate { get; }

        public Vehicle(string factoryName, string model, string color, double driveTime, string drivePath)
        {
            FactoryName = factoryName;
            Model = model;
            Color = color;
            DriveTime = driveTime;
            DrivePath = drivePath;
            ProductionDate = DateTime.Now;
        }

        public double AverageSpeed()
        {
            return CalculateAverageSpeed();
        }

        protected abstract double CalculateAverageSpeed();

        public virtual void GetInfo()
        {
            Console.WriteLine($"Factory Name: {FactoryName}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Drive Time: {DriveTime} hours");
            Console.WriteLine($"Drive Path: {DrivePath}");
            Console.WriteLine($"Production Date: {ProductionDate:yyyy-MM-dd}");
        }

        public abstract string DefineNatureHarmness();
    }

   
    public class Car : Vehicle
    {
        public int DoorCount { get; set; }
        public bool IsElectricCar { get; set; }

        public Car(string factoryName, string model, string color, double driveTime, string drivePath, int doorCount, bool isElectricCar)
            : base(factoryName, model, color, driveTime, drivePath)
        {
            DoorCount = doorCount;
            IsElectricCar = isElectricCar;
        }

        protected override double CalculateAverageSpeed()
        {
            return DoorCount * 10; 
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Door Count: {DoorCount}");
            Console.WriteLine($"Is Electric Car: {IsElectricCar}");
            Console.WriteLine($"Nature Harmness: {DefineNatureHarmness()}");
        }

        public override string DefineNatureHarmness()
        {
            return IsElectricCar ? "Low" : "High";
        }

        public override string ToString()
        {
            return $"Factory Name: {FactoryName}, Model: {Model}";
        }
    }


    public class Bicycle : Vehicle
    {
        public string Type { get; set; }

        public Bicycle(string factoryName, string model, string color, double driveTime, string drivePath, string type)
            : base(factoryName, model, color, driveTime, drivePath)
        {
            Type = type;
        }

        protected override double CalculateAverageSpeed()
        {
            return ; 
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Nature Harmness: {DefineNatureHarmness()}");
        }

        public override string DefineNatureHarmness()
        {
            return "None";
        }

        public override string ToString()
        {
            return $"Factory Name: {FactoryName}, Model: {Model}";
        }
    }
}
