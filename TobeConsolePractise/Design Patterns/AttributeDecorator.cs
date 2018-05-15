using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class VehicleInfoAttribute : Attribute
    {
        private Type type;
        public VehicleInfoAttribute(Type type)
        {
            this.type = type;
        }

        public Type Type
        {
            get
            {
                return type;
            }
        }
    }


    public enum VehicleType
    {
        [VehicleInfo(typeof(Car))]
        Car,
        [VehicleInfo(typeof(SuperCar))]
        SuperCar,
        [VehicleInfo(typeof(Truck))]
        Truck,
        [VehicleInfo(typeof(Motorcycle))]
        Motorcycle
    }


    public static class Extensions
    {
        public static T GetAttribute<T>(this Enum enumValue)
            where T : Attribute
        {
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(T), false);

            T result = default(T);

            if (attribs.Length > 0)
            {
                result = attribs[0] as T;
            }

            return result;
        }
    }


    public abstract class Vehicle
    {
        public virtual int TopSpeed
        {
            get
            {
                return 150;
            }
        }

        public abstract int Wheels
        {
            get;
        }

        public override string ToString()
        {
            return String.Format("A {0} has {1} wheels, and a top speed of {2} MPH."
                , this.GetType().Name, this.Wheels, this.TopSpeed);
        }
    }


    public class VehicleFactory
    {
        //old method
        public static Vehicle GetVehicle1(VehicleType vehicle)
        {
            switch (vehicle)
            {
                case VehicleType.Car:
                    return new Car();
                case VehicleType.SuperCar:
                    return new SuperCar();
                case VehicleType.Truck:
                    return new Truck();
                case VehicleType.Motorcycle:
                    return new Motorcycle();
                default:
                    return null;
            }
        }

        //decorated method
        public static Vehicle GetVehicle(VehicleType vehicle)
        {
            var vehicleAttribute = vehicle.GetAttribute<VehicleInfoAttribute>();
            if (vehicleAttribute == null)
            {
                throw new Exception("No VehicleInfo Attribute assigned to the VehicleType");
            }

            var type = vehicleAttribute.Type;
            Vehicle result = Activator.CreateInstance(type) as Vehicle;

            return result;
        }

        public static void Run(VehicleType vehicle, bool useDecorator=true)
        {
            Vehicle v;
            if (useDecorator) v = GetVehicle(vehicle);
            else v = GetVehicle1(vehicle);
            Console.WriteLine(v);
            Console.ReadKey();
        }
    }


    public partial class Car : Vehicle
    {
        public override int Wheels
        {
            get { return 4; }
        }
    }


    public class SuperCar : Car
    {
        public override int TopSpeed
        {
            get
            {
                return 200;
            }
        }
    }


    public class Truck : Vehicle
    {
        public override int Wheels
        {
            get { return 18; }
        }
    }


    public class Motorcycle : Vehicle
    {
        public override int Wheels
        {
            get { return 2; }
        }

        public override int TopSpeed
        {
            get
            {
                return 190;
            }
        }
    }
}
