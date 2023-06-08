using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public String Name { get; private set; }
        public Category(string name)
        {
            ValidateDomain(name);

        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            Name = name;
            
        }
        public void update(string name)
        {
            ValidateDomain(name);
        }
        public ICollection<Product> Products { get; set; }
        private void ValidateDomain(string name){
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 caracters");
            Name = name;
        }
        
    }
}