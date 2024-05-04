namespace Dish.Core.Exceptions;

public class DatabaseException : Exception
{
    public DatabaseException(string message, Exception exception) : base(message, exception)
    {
    }
}