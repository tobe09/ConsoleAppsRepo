using System;

namespace TobeConsolePractise
{
    interface IVehicle
    {
        string VehicleName { get; set; }
        int Position { get; set; }
        int Move();
    }

    partial class Car : IVehicle
    {
        private string _carName = "Regular Car";
        private int _position = 1;
        public string VehicleName
        {
            set { _carName = value; }
            get { return _carName; }
        }
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public int Move()
        {
            return ++Position;
        }
    }

    class Bike : IVehicle
    {
        private string _bikeName = "Regular Bike";
        public string VehicleName
        {
            set { _bikeName = value; }
            get { return _bikeName; }
        }
        public int Position { get; set; }  //uses default(int) to initialize i.e. 0
        public int Move()
        {
            return ++Position;
        }
    }

}
