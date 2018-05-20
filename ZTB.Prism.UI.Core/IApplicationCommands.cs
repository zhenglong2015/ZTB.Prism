using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTB.Prism.UI.Core
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
    }
}
