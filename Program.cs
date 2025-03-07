using System.Runtime.ExceptionServices;
using EntityModels.Models;
using Microsoft.EntityFrameworkCore;
using Week3EntityFramework.Dtos;

//var context = new IndustryConnectWeek2Context();

//var customer = new Customer
//{
//    DateOfBirth = DateTime.Now.AddYears(-20)
//};


//Console.WriteLine("Please enter the customer firstname?");

//customer.FirstName = Console.ReadLine();

//Console.WriteLine("Please enter the customer lastname?");

//customer.LastName = Console.ReadLine();


//var customers = context.Customers.ToList();

//foreach (Customer c in customers)
//{   
//    Console.WriteLine("Hello I'm " + c.FirstName);
//}

//Console.WriteLine($"Your new customer is {customer.FirstName} {customer.LastName}");

//Console.WriteLine("Do you want to save this customer to the database?");

//var response = Console.ReadLine();

//if (response?.ToLower() == "y")
//{
//    context.Customers.Add(customer);
//    context.SaveChanges();
//}



//var sales = context.Sales.Include(c => c.Customer)
//    .Include(p => p.Product).ToList();

//var salesDto = new List<SaleDto>();

//foreach (Sale s in sales)
//{
//    salesDto.Add(new SaleDto(s));
//}



//context.Sales.Add(new Sale
//{
//    ProductId = 1,
//    CustomerId = 1,
//    StoreId = 1,
//    DateSold = DateTime.Now
//});


//context.SaveChanges();




//Console.WriteLine("Which customer record would you like to update?");

//var response = Convert.ToInt32(Console.ReadLine());

//var customer = context.Customers.Include(s => s.Sales)
//    .ThenInclude(p => p.Product)
//    .FirstOrDefault(c => c.Id == response);


//var total = customer.Sales.Select(s => s.Product.Price).Sum();


//var customerSales = context.CustomerSales.ToList();

//var totalsales = customer.Sales



//Console.WriteLine($"The customer you have retrieved is {customer?.FirstName} {customer?.LastName}");

//Console.WriteLine($"Would you like to updated the firstname? y/n");

//var updateResponse = Console.ReadLine();

//if (updateResponse?.ToLower() == "y")
//{

//    Console.WriteLine($"Please enter the new name");

//    customer.FirstName = Console.ReadLine();
//    context.Customers.Add(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//    context.SaveChanges();
//}



//***Week3 Homework***
//1.Using the linq queries retrieve a list of all customers from the database who don't have sales
var context = new IndustryConnectWeek2Context();

//Getting customers
var nosalescustomers = context.Customers
    .Where(c => !context.Sales
                .Select(s => s.CustomerId)
                .Contains(c.Id))
    .ToList();

//Passing to customerDTO
var customerDto = new List<CustomerDto>();
foreach (Customer customer in nosalescustomers)
{
    customerDto.Add(new CustomerDto(customer));
}

//Display names through the DTO
Console.WriteLine("Customers who have no orders:");
foreach (CustomerDto c in customerDto)
{
    Console.WriteLine(c.CustomerFirstName + " " + c.CustomerLastName);
}

//2.Insert a new customer with a sale record
var newcustomer = new Customer();
var newsale = new Sale();

Console.WriteLine("\nNew Customer with Sales..\nFirst Name:");
newcustomer.FirstName = Console.ReadLine();
Console.WriteLine("Last Name:");
newcustomer.LastName = Console.ReadLine();
Console.WriteLine("Product Id:");
newsale.ProductId = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Sold date:");
newsale.DateSold = Convert.ToDateTime(Console.ReadLine());

Console.WriteLine("\nConfirm below details (y/n)?\nFirst name: " + newcustomer.FirstName + "\nLast name: " + newcustomer.LastName + "\nProduct ID: " + newsale.ProductId + "\nSold date: " + newsale.DateSold);
var response = Console.ReadLine()?.ToLower();

if (response == "y")
{
    Console.WriteLine("Adding new record to the DB..");

    try
    {
        //Saving the customer details
        context.Customers.Add(newcustomer);
        context.SaveChanges();

        //Getting new customer ID for the newsale obj
        newsale.CustomerId = context.Customers.Select(c => c.Id).ToList().Max();

        //Saving sale details
        context.Sales.Add(newsale);
        context.SaveChanges();

        Console.WriteLine("New record added!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


}

//3.Add a new store
var newstore = new Store();

Console.WriteLine("\nNew Store..\nStore name:");
newstore.Name = Console.ReadLine();
Console.WriteLine("Location:");
newstore.Location = Console.ReadLine();
Console.WriteLine("Sale Id:"); //Requesting Sales ID since the sales ID is a mandetory filed in the Store table
newstore.SaleId = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\nConfirm below details (y/n)?\nStore name: " + newstore.Name + "\nStore location: " + newstore.Location + "\nSales Id: " + newstore.SaleId);
response = Console.ReadLine()?.ToLower();

if (response == "y")
{
    Console.WriteLine("Adding new record to the DB..");

    try
    {
        //Saving store details
        context.Stores.Add(newstore);
        context.SaveChanges();

        Console.WriteLine("New record added!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

//4.Find the list of all stores that have sales
var salestores = context.Stores
    .Include(s => s.Sale)
    .ToList();

Console.WriteLine("\nStores which have sales:");

foreach (Store st in salestores)
{
    Console.WriteLine("Name: " + st.Name + "\nLocation: " + st.Location + "\n");
}

Console.ReadLine();









