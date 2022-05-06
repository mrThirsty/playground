// See https://aka.ms/new-console-template for more information


using BasicRealm.Model;
using BasicRealm.Services;

IOrgService service = new OrgService();

ConsoleKeyInfo menuOption = new ConsoleKeyInfo();

while (menuOption == null || menuOption.Key != ConsoleKey.D3)
{
    Console.ForegroundColor = ConsoleColor.White;
    
    var orgs = await service.GetOrgs();

    foreach (var org in orgs)
    {
        Console.WriteLine($"Organisation: {org.OrgName}");
        Console.WriteLine("Employees:");

        foreach (var employee in org.Contacts)
        {
            Console.WriteLine($"{employee.Firstname} {employee.Lastname}");
        }

        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }

    
    Console.WriteLine("1. Create an Org");
    Console.WriteLine("2. Create a Contact");
    Console.WriteLine("3. Exit");
    
    menuOption = Console.ReadKey();

    Console.Clear();
    
    if (menuOption.Key == ConsoleKey.D1)
    {
        Console.Write("Org name: ");
        string orgName = Console.ReadLine();

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        
        bool success = await service.CreateOrg(new Organisation() { OrgName = orgName });
        
        Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
            
        if(success) Console.WriteLine($"Organisation created");
        else Console.WriteLine("Unable to create the organisation");
    }

    if (menuOption.Key == ConsoleKey.D2)
    {
        Console.Write("Organisation: ");
        string org = Console.ReadLine();
        
        Console.Write("First name: ");
        string firstname = Console.ReadLine();
        
        Console.Write("Last name: ");
        string lastname = Console.ReadLine();

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        
        var orgRecord = await service.FindOrg(org);

        if (orgRecord == null)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unable to find the organisation, will not add the contact");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
        else
        {
            bool success = await service.CreateContact(new Contact()
                { Firstname = firstname, Lastname = lastname, Employer = orgRecord });

            Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
            
            if(success) Console.WriteLine($"Contact created for the organisation");
            else Console.WriteLine("Unable to create the contact for the organisation");
        }
    }
    
    Console.WriteLine(" ");
    Console.WriteLine(" ");
}