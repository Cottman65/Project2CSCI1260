namespace ConsoleLib;

public class ConsoleRepo // our console repository class
{
    private string _file;
    public ConsoleRepo(string file) // one arg constructor
    {
        _file = file;
    }
    public Consoles Create(Consoles console) // creates a file and writes our object to it in one
    {
        try
        {
            StreamWriter writer = new(_file, append: true);
            writer.WriteLine(console.TextOutput());
            writer.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message); // if exception is caught will throw the error message
        }
        return console;
    }

    public void Delete(string id) // delets an object from our file
    {
        try
        {
            string tempPath = _file + ".temp";
            StreamWriter writer = new(tempPath, append: true);

            string? record;
            StreamReader reader = new(_file);
            record = reader.ReadLine();
            while(record != null)
            {
                string[] line = record.Split(':');
                if (line[0] != id)
                {
                    writer.WriteLine(record);
                }
                record = reader.ReadLine();
            }
            reader.Close();
            writer.Close();

            File.Delete(_file);
            File.Move(tempPath, _file);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public Consoles? Read(string id) // reads in an object from the file
    {
        Consoles? console = null;
        try
        {
            string? record;
            StreamReader reader = new(_file);
            record = reader.ReadLine();
            while(record != null)
            {
                string[] line = record.Split(":");
                if (line[0] == id)
                {
                    console = new Consoles()
                    {
                        Brand = line[0],
                        Model = line[1],
                        ID = int.Parse(line[2])
                    };
                    break;
                }
                record = reader.ReadLine();
            }
            reader.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return console;
    }

    public List<Consoles> ReadAll() 
    {
        List<Consoles> consoles = new List<Consoles>();
        try
        {
            string? record;
            StreamReader reader = new(_file);
            record = reader.ReadLine();
            while(record != null)
            {
                string[] line = record.Split(':');
                Consoles console = new()
                {
                    Brand = line[0],
                    Model = line[1],
                    ID = int.Parse(line[2])
                };
                consoles.Add(console);
                record = reader.ReadLine();
            }
            reader.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return consoles;
    }

    public void Update(string oldId, Consoles console) // allows up to update an object within our file
    {
        try
        {
            string tempPath = _file + ".temp";
            StreamWriter writer = new StreamWriter(tempPath, append: true);
            string? record;
            StreamReader reader = new(_file);
            record = reader.ReadLine();
            while(record != null)
            {
                string[] line = record.Split(':');
                if (line[0] != oldId)
                {
                    writer.WriteLine(record);
                }
                else
                {
                    writer.WriteLine(console.TextOutput());
                }
                record = reader.ReadLine();
            }
            reader.Close();
            writer.Close();
            File.Delete(_file);
            File.Move(tempPath, _file);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
