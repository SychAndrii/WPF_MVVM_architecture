using MVVM.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Infrastructure.Commands
{
    class LambdaCommand : Command
    {
        public LambdaCommand(Action<object?> execute, Func<object, bool>? canExecute = null)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }

        public Action<object?> _Execute { get; }
        public Func<object, bool>? _CanExecute { get; }

        public override bool CanExecute(object? parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter) => _Execute(parameter);
    }
}
