using System;

namespace TobeConsolePractise
{
    class Driver
    {
        private string _driverName="Default Driver";
        private IVehicle _vehicle;

        //exposing properties (interface), not fields(implementation).
        public string DriverName
        {
            set { _driverName = value; }
            get { return _driverName; }
        }
        public IVehicle Vehicle
        {
            set { _vehicle = value; }
            get { return _vehicle; }
        }

        //programming against interfaces as opposed to implementation
        public Driver(IVehicle v)  //constructor injection.
        {
            Vehicle = v;
        }

        public void setVehicle(IVehicle v)  //method or setter injection.
        {
            Vehicle = v;
        }

        //method to test runtime objects
        public string Drive()  
        {
            return DriverName + " is driving " + Vehicle.VehicleName + " and has moved " + Vehicle.Move() + " mile(s).";
        }

        public static void run()
        {
            Driver driverOne = new Driver(new Car());
            Driver driverTwo = new Driver(new Bike());
            driverTwo.DriverName = "Driver 2";
            Driver driverThree = new Driver(new Bike());
            driverThree.DriverName = "Driver 3";
            driverThree.setVehicle(new Car());
            Console.WriteLine(driverOne.Drive());
            Console.WriteLine();
            Console.WriteLine(driverTwo.Drive());
            Console.WriteLine();
            Console.WriteLine(driverThree.Drive());
            Console.WriteLine();
            Console.WriteLine(driverTwo.Drive());
            Console.ReadKey();
        }
    }
}
