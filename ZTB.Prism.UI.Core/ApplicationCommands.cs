﻿using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTB.Prism.UI.Core
{
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _saveCommand = new CompositeCommand();
        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }
    }
}
