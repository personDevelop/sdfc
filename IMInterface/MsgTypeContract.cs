using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMInterface
{
    public enum MsgTypeContract
    {
        UserStateNotify,
        CloseConnection,
        ServerChatMessage,
        ClientChatMessage,
        SetupP2PMessage,
        ChatMessage,
        GetFriends,
        GetOnlineUser,
        UserLogin,
        ChangePsw,
    }
}
