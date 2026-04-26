namespace GoodHamburguer.SharedKernel.Exceptions;

public class BadRequestException : GoodHamburguerException
{
    public BadRequestException(string message) : base(message)
    {
    }
}
