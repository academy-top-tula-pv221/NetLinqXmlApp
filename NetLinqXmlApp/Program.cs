using ExampleClassLibrary;
using System.Xml.Linq;


User user = new("Bill", 39,
    new Address() { City = "St. Peterburg", Street = "Nevsky" });

// XDocument document = new XDocument();
XElement address = new XElement("address");
XElement city = new XElement("city", user.Address.City);
XElement street = new XElement("street", user.Address.Street);
address.Add(city);
address.Add(street);
XElement xuser = new XElement("user");
XElement name = new XElement("name", user.Name);
XElement age = new XElement("age", user.Age);

xuser.Add(name);
xuser.Add(age);
xuser.Add(address);

XAttribute role = new XAttribute("role", "member");
xuser.Add(role);

XDocument xdoc = XDocument.Load("users.xml");
XElement? xroot = xdoc.Root;

//XElement? xComps = xdoc.Element("companies");

if(xroot is not null)
{
    //xroot.Add(xuser);
    xdoc.Save("users.xml");

    //var u2 = xroot.Elements()
    //              .Where(u => Int32.Parse(u.Element("age").Value) > 25)
    //              .Select(u => new
    //              {
    //                  Name = u.Element("name")?.Value,
    //                  Age = u.Element("age")?.Value
    //              });
    //foreach(var u in u2)
    //    Console.WriteLine($"Name: {u.Name}, age: {u.Age}");

    //XElemenetPrint(xroot);
    //foreach(XElement xuser in xroot.Elements())
    //{
    //    Console.WriteLine($"Element name: {xuser.Name}");
    //    Console.WriteLine($"\tAttributes:");
    //    foreach (var attr in xuser.Attributes())
    //        Console.WriteLine($"\t\t{attr.Name}: {attr.Value}");
    //}
}

void XElemenetPrint(XElement element)
{
    Console.WriteLine($"Element name: {element.Name}");
    Console.WriteLine($"\tAttributes:");
    foreach (var attr in element.Attributes())
        Console.WriteLine($"\t\t{attr.Name}: {attr.Value}");
    Console.WriteLine($"\tValues:");
    foreach (var subElement in element.Elements())
    {
        if (subElement.Elements().Count() != 0)
            XElemenetPrint(subElement);
        else
            Console.WriteLine($"\t\t{subElement.Value}");
    }
}
