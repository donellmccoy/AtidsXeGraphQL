using System;
using Prism.Commands;

namespace TheFund.AtidsXe.Modules.Search.Factories
{
    public static class DelegateCommandFactory
    {
        public static DelegateCommand Create(Action executeMethod, Func<bool> canExecuteMethod)
        {
            return new DelegateCommand(executeMethod, canExecuteMethod);
        }

        public static DelegateCommand<T> Create<T>(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            return new DelegateCommand<T>(executeMethod, canExecuteMethod);
        }
    }
}