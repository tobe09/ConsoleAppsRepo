using System;

namespace TobeConsolePractise
{
    public enum PaymentMethod  //enumeration representing customer's choice
    {
        Bank_One,
        Bank_Two,
        Best_For_Me,
        Pay_Pal,
        Bill_Desk
    }

    public enum ProductType
    {
        Television,
        Radio,
        Watch,
        Car,
        Bike
    }


    public interface IPaymentGatewayFactory
    {
        IBankPaymentGateway CreatePaymentGateway(PaymentMethod method, IProduct product);
    }
    public class PaymentGatewayFactory:IPaymentGatewayFactory  //factory to choose/create payment gateway
    {
        public virtual IBankPaymentGateway CreatePaymentGateway(PaymentMethod method, IProduct product)
        {
            IBankPaymentGateway gateway = null;
            switch (method)
            {
                case PaymentMethod.Bank_One:
                    gateway = new BankOne();
                    break;
                case PaymentMethod.Bank_Two:
                    gateway = new BankTwo();
                    break;
                case PaymentMethod.Best_For_Me:
                    if (product.Price < 50)
                    {
                        gateway = new BankTwo();
                    }
                    else
                    {
                        gateway = new BankOne();
                    }
                    break;
                default:
                    gateway = new BankOne();
                    break;
            }
            return gateway;
        }
    }
    public class PaymentGatewayFactory2 : PaymentGatewayFactory
    {
        public override sealed IBankPaymentGateway CreatePaymentGateway(PaymentMethod method, IProduct product)
        {
            IBankPaymentGateway gateway = null;

            switch (method)
            {
                case PaymentMethod.Pay_Pal:
                    gateway = new PayPal();
                    break;
                case PaymentMethod.Bill_Desk:
                    gateway = new BillDesk();
                    break;
                default:
                    gateway = base.CreatePaymentGateway(method, product);
                    break;
            }
            return gateway;
        }
    }


    public abstract class AbstractProductCreator
    {
        public  virtual IProduct CreateProduct(ProductType pType)
        {
            IProduct p = null;
            switch (pType)
            {
                case ProductType.Bike:
                    p = new Product();
                    p.Name = "Bike";
                    p.Description = "A regular bike";
                    p.Price = 100;
                    break;
                case ProductType.Car:
                    p = new Product();
                    p.Name = "Car";
                    p.Description = "A regular Car";
                    p.Price = 200;
                    break;
                case ProductType.Television:
                    p = new Product();
                    p.Name = "Television";
                    p.Description = "A regular television";
                    p.Price = 80;
                    break;
                case ProductType.Watch:
                    p = new Product();
                    p.Name = "Watch";
                    p.Description = "A regular watch";
                    p.Price = 40;
                    break;
                default:
                    p = new Product();
                    break;
            }
            return p;
        }
    }
    public class ProductCreator:AbstractProductCreator
    {
        public  override IProduct CreateProduct(ProductType pType)
        {
            IProduct p = null;
            switch (pType)
            {
                case ProductType.Radio:
                    p = new Product();
                    p.Name = "Radio";
                    p.Description = "A regular radio";
                    p.Price = 30;
                    break;
                default:
                    p = base.CreateProduct(pType);
                    break;
            }
            return p;
        }
    }


    public interface IBankPaymentGateway  //payment gateway interface
    {
        void MakePayment(IProduct p);
    }
    //2% discount on price for first 50 naira and 1% discount subsequently
    public class BankOne : IBankPaymentGateway
    {
        public void MakePayment(IProduct p)
        {
            Console.WriteLine("Payment made using BankOne: " + p.Name + ", " + p.Price);
        }
    }
    //1.5% dicount irrespective of price
    public class BankTwo : IBankPaymentGateway
    {
        public void MakePayment(IProduct p)
        {
            Console.WriteLine("Payment made using BankTwo: " + p.Name + ", " + p.Price);
        }
    }
    public class PayPal : IBankPaymentGateway
    {
        public void MakePayment(IProduct p)
        {
            Console.WriteLine("Payment made using Pay Pal: " + p.Name + ", " + p.Price);
        }
    }
    public class BillDesk : IBankPaymentGateway
    {
        public void MakePayment(IProduct p)
        {
            Console.WriteLine("Payment made using Bill Desk: " + p.Name + ", " + p.Price);
        }
    }


    public interface IProduct  //interface for exposing general xtics of products
    {
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
    }
    public class Product : IProduct  //concrete product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }


    public class PaymentProcessor
    {
        IBankPaymentGateway gateway = null;

        public void MakePayment(PaymentMethod method, IProduct product)
        {
            IPaymentGatewayFactory factory = new PaymentGatewayFactory2();
            gateway = factory.CreatePaymentGateway(method, product);
            gateway.MakePayment(product);
        }

        public static void run()
        {
            PaymentMethod method = PaymentMethod.Best_For_Me;
            IProduct product = new ProductCreator().CreateProduct(ProductType.Radio);
            new PaymentProcessor().MakePayment(method, product);
            Console.WriteLine("Product class name: " + product.GetType().Name);
            Console.ReadKey();
        }
    }
}
