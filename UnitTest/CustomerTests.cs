using Xunit;
using Models;
using System;
using System.Collections.Generic;
using StoreBL;

public class CustomerTests{
    [Fact]
    public void Test_CreateCustomer(){

        CCustomer c1 = new CCustomer("Hung", "hungp", "password123");
        Assert.NotNull(c1);
}