using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public String Name { get; private set; }
        public String Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public String Image { get; private set; }
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 caracters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 caracters");
            DomainExceptionValidation.When(price < 0, "Invalid price value");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value");
            //the "image.Length>250 looks for a image so this box can't be null, but we said that it could
            // so we have to solve this"
            //we'll avaliate the value of image, if it's null the result returned will be "null",
            //this is not going to return a NullReferenceException, that is what was happening, 
            // and our test was passed because of it, cause wasn't null, was nullException.
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, too long, maximum 250 characters");
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}