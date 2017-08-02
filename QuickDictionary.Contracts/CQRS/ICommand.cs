namespace QuickDictionary.Contracts.CQRS
{
    public interface ICommand
    {
        void Execute(ISession session);
    }
}
