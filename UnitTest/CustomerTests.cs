using System;
using Xunit;

public class CustomerTests{
    [Fact]
    public void Test_CreateCustomer(){

        CCustomer c1 = new CCustomer("Hung", "hungp", "password123");
        Assert.NotNull(c1);
}