namespace QuickDictionary.Contracts.CQRS
{
    public interface ICommand
    {
        void Execute(ISession session);
    }

    public interface ICommand<T>
    {
        T Execute(ISession session);
    }
}
