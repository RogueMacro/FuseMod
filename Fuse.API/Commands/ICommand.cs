using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.API.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string[] Aliases { get; }
        string Syntax { get; }
    }
}
