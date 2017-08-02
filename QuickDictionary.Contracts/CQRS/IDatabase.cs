﻿namespace QuickDictionary.Contracts.CQRS
{
    public interface IDatabase
    {
        T Query<T>(IQuery<T> query);

        void Execute(ICommand command);
    }
}
