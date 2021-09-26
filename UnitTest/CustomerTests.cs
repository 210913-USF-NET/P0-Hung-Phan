using Xunit;
using Models;
using System;
using System.Collections.Generic;
using StoreBL;

public class CustomerTests{
    [Fact]
    public void Test_CreateCustomer(){

        CCustomer c1 = new CCustomer("Hung", "hungp", "password123");
// blah blah blah
        Assert.NotNull(c1);
        // Add the add customer logic here to test this is adding a customer in theory
    }

    // [Fact]
    // public void Test_GetAllCustomer(){
           // Arrange
    //     var c1 = blah;
    // var c2 = blah blah blah
    // addCustomer();
            
    //     var expectedResult = 2;

            // Act and Assert
            //var customers = dummyContext.GetAllCustomer();
    //     Assert.Equal(expectedResult, customers.Count);

    // }
}