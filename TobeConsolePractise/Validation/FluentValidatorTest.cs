using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;

namespace TobeConsolePractise
{
    public class FluentValidatorTest
    {
        public static void Run()
        {
            var customer = new Customer { Name = null, Age = 0, Address = new Address { Value = "" } };
            var result = customer.Validate();
            Console.WriteLine(result.ToString());
        }
    }

    [Validator(typeof(CustomerValidator))]
    public class Customer : BaseRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }

    class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("'Name' must not be null");
            RuleFor(x => x.Age).NotEqual((int)default);
            RuleFor(x => x.Address).SetValidator(new AddressValidator());
        }
    }

    public class Address
    {
        public string Value { get; set; }
    }

    class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Value).NotEmpty();
        }
    }

    public class ValidatorAttribute : Attribute
    {
        public ValidatorAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }

    internal interface IValidatable
    {
        ValidationResult Validate();
    }

    public abstract class BaseRequest : IValidatable
    {
        public ValidationResult Validate()
        {
            var attrib = GetType().GetCustomAttributes(true).FirstOrDefault(x => typeof(ValidatorAttribute).IsAssignableFrom(x.GetType())) as ValidatorAttribute;
            if (attrib == null)
                throw new Exception("No Validator Configured for " + GetType().Name);

            object validator = Activator.CreateInstance(attrib.Type);
            var validateMethod = validator.GetType().GetMethod("Validate", new[] { GetType() });

            return validateMethod.Invoke(validator, new object[] { this }) as ValidationResult;
        }
    }
}
