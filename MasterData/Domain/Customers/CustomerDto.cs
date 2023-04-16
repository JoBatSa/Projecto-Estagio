using System;
using MasterData.Domain.ValueObjects;

namespace DDDSample1.Domain.Customers
{
    public class CustomerDto
{
    public Guid Id { get; set; }

    public string Company { get; set; }

    public string Name { get; set; }

    public string CustomerEmail {get;set;}

    public string CustomerPhoneNumber {get;set;}

    public int Nif { get; set; }
    
    public string Password {get;set;}

     public int CustPosition {get;set;}

     public bool Active {get;set;}
}
}