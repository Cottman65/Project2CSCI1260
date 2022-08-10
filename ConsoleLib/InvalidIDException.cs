namespace ConsoleLib;

public class InvalidIDException : Exception
{
    public InvalidIDException() : base("Identification cannot be less than 0 or larger than 999999!")
    {

    }
    public InvalidIDException(string message) : base(message)
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    public InvalidIDException(string message, Exception inner) : base(message, inner)
    {

    }
}
