namespace GoodHamburguer.SharedKernel.Exceptions;

public class NotFoundException : GoodHamburguerException
{
    public NotFoundException(string message) : base(message)
    {
    }
}
