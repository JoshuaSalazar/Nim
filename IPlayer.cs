using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    interface IPlayer
    {
        bool makeMove(GameManager game);
    }
}