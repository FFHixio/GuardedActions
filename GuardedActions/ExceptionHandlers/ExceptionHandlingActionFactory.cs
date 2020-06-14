using System;
using GuardedActions.ExceptionHandlers.Interfaces;

namespace GuardedActions.ExceptionHandlers
{
    public class ExceptionHandlingActionFactory : IExceptionHandlingActionFactory
    {
        public IExceptionHandlingAction Create(Exception exception)
        {
            var genericType = typeof(ExceptionHandlingAction<>).MakeGenericType(exception.GetType());

            return Activator.CreateInstance(genericType, exception) as IExceptionHandlingAction;
        }
    }
}
