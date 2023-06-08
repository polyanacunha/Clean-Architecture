using System;
using Xunit;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void createProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
         public void createProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1,"Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
         public void createProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1,"Pr", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
         public void createProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1,"Product Name", "Product Description", 9.99m, 99, "Producttttttttttttttttttttttt imageeeeeeeeeeeeeeeeeee tooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo lonnnnnnnnggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
         public void createProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1,"Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
         public void createProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1,"Product Name", "Product Description", -9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Theory]
        [InlineData(-5)]
         public void createProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1,"Product Name", "Product Description", 9.99m, value, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
         public void createProduct_InvalidImage_NoDomainException()
        {
            Action action = () => new Product(1,"Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should().NotThrow<NullReferenceException>();
        }
    }
}