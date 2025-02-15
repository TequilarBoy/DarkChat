using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkChat.Unit
{
    public enum CommandCode
    {
        COMMAND_JOIN,
        COMMAND_LEAVE,
        COMMAND_MSG,
        COMMAND_PING,

        TOKEN_JOIN,
        TOKEN_LEAVE,
        TOKEN_MSG,
        TOKEN_PONG
    }
}
