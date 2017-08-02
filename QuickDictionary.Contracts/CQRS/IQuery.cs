namespace QuickDictionary.Contracts.CQRS
{
    public interface IQuery<out T>
    {
        T Execute(ISession session);
    }
}
