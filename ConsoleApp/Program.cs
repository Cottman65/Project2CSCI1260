using ConsoleLib;

ConsoleRepo file = new ConsoleRepo("Consoles.txt"); // instantiates our file object
List<Consoles> consoles; 

int choice;
do // a do while loop allowin us to capture our cases and allow the user to input a choice
{
    consoles = file.ReadAll();
    ShowConsoles(consoles);
    MainMenu();
    choice = int.Parse(Console.ReadLine()!);

    switch(choice.ToString())
    {
        case "1":
            file.Create(ConsoleReader());
            break;
        case "2":
            ViewConsoles(file);
            break;
        case "3":
            UpdateConsole(file);
            break;
        case "4":
            DeleteConsole(file);
            break;
        case "5":
            CountTextWithinAGivenFile();
            break;
        default:
            while (choice < 1 || choice > 6) // validates that numbers 1-6 are available to the user
            {
                if (choice < 1 || choice > 6)
                {
                    Console.WriteLine("Only choices from 1 - 6 are available!");
                    Console.WriteLine();
                }
                break;
            }
            break;
            
    }

}while(choice.ToString() != "6");


static void UpdateConsole(ConsoleRepo file) // this method updates a console
{
    var consoleBrand = StringReader("Enter your console's BRAND: ");
    var console = file.Read(consoleBrand);
    if (console != null)
    {
        var newConsole = ConsoleReader();
        file.Update(consoleBrand, newConsole);
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Your console was not located!");
        Console.WriteLine();
    }
}

static void ShowConsoles(List<Consoles> consoles) // this method allows us to constantly see the consoles inside our text file
{
    Console.WriteLine("The following consoles are as shown: ");
    foreach (Consoles console in consoles)
    {
        Console.WriteLine($"Brand is {console.Brand}, Model is {console.Model}, and ID is {console.ID}");
    }
}

static void ViewConsoles(ConsoleRepo file) // this methods allows us to look up and view a console
{
    var consoleName = StringReader("Enter your console's BRAND: ");
    var console = file.Read(consoleName);
    if (console != null)
    {
        var newConsole = ConsoleReader();
        Console.WriteLine(newConsole);
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("The console was not located!");
        Console.WriteLine();
    }
}

static void ReadID(Consoles console) // this method helps to make our custom exception work as intended
{
    do
    {
        int id = IntReader("Please enter your consoles ID: ");
        try
        {
            console.ID = id;
            break;
        }
        catch (InvalidIDException ex)
        {
            Console.WriteLine(ex.Message);
        }
    } while (true);
}

static string StringReader(string prompt) // this method reads in a string
{
    string value = "";
    Console.Write(prompt);
    string? strValue = Console.ReadLine();
    if (strValue != null)
    {
        value = strValue.ToString();
    }
    return value;

}

static int IntReader(string prompt) // this method read in an integer
{
    int value;
    do
    {
        Console.Write(prompt);
        string? strValue = Console.ReadLine();
        if (strValue != null)
        {
            try
            {
                value = int.Parse(strValue);
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    } while (true);
    return value;
}

static Consoles ConsoleReader() // this method reads the console
{
    Consoles console = new();
    console.Brand = StringReader("Enter your console's new BRAND: ");
    Model(console);
    ReadID(console);
    return console;
}

static void Model(Consoles console)
{
    do
    {
        string model = StringReader("Enter your console's MODEL: ");
        try
        {
            console.Model = model;
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }
    } while (true);
}

static void DeleteConsole(ConsoleRepo file) //this method deletes the console
{
    var consoleName = StringReader("Enter your console's BRAND: ");
    var console = file.Read(consoleName);
    if (console != null)
    {
        var newConsole = ConsoleReader();
        file.Delete(consoleName);
        Console.WriteLine($"{consoleName} was DELETED!");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Your console was not located!");
        Console.WriteLine();
    }
}

static void MainMenu() //main menu method
{
    Console.WriteLine("Press 1 to CREATE a new game console!");
    Console.WriteLine("Press 2 to VIEW all game consoles in repo");
    Console.WriteLine("Press 3 to UPDATE a game console in repo");
    Console.WriteLine("Press 4 to DELETE a game console from repo");
    Console.WriteLine("Press 5 to access Console Query");
    Console.WriteLine("Press 6 to EXIT the application");
    Console.Write("Please enter your choice: ");
}

//My additonal Functionality is below

static void CountTextWithinAGivenFile() // this method counts how many words are in a text file using a delimiter to split each line into words
{
    string[] line = null;
    string lines = null;

    string nameOfFile = null;
    Console.Write("What is the name of the file?: ");
    nameOfFile = Console.ReadLine()!;

    StreamReader sr = new(nameOfFile);
    string comma = ":";
    int counter = 0;

    while (!sr.EndOfStream)
    {
        lines = sr.ReadLine()!;
        line = lines.Split(comma.ToCharArray());
        counter += line.Length;
    }
    sr.Close();
    Console.WriteLine($"Count is {counter}");
}