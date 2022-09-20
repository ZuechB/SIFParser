using SIFParser;

Console.WriteLine("Reading file");

var reader = new SIFReader();

var sifs = await reader.Read("pathToFile.sif");

foreach (var sif in sifs)
{
    Console.WriteLine("ProductNumber: " + sif.ProductNumber);
    Console.WriteLine("Product Description: " + sif.ProductDescription);
    Console.WriteLine("Color: " + sif.Color);
    Console.WriteLine("Quantity: " + sif.Quantity);
    Console.WriteLine("Manufacturer: " + sif.ManufacturerName + " (" + sif.ManufacturerCode + ")");
    Console.WriteLine("Option Description: " + sif.OptionDescription);
    Console.WriteLine("");
    Console.WriteLine("");

}

Console.WriteLine("Done reading file");