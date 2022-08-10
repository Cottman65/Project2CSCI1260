namespace ConsoleLib;

public class Consoles
{
    private int _id;
    public string Brand { get; set; } = String.Empty;
    public string Model { get; set; } = String.Empty;
    public int ID // if value is not within the following range, throw the exception
    {
        get { return _id; }
        set
        {
            if (value <= 0 || value > 999999)
            {
                throw new InvalidIDException("Console ID cannot be NULL or larger than 999999!");
            }
            _id = value;
        }
    }

    public override string ToString()
    {
        return $"Brand is {Brand}, Model is {Model}, and ID is {ID}";
    }

    public string TextOutput() // allows our properties to be properly written to the text file
    {
        return $"{Brand}:{Model}:{ID}";
    }


}