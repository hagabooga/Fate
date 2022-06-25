using Godot;
using System;
using Utility;
using static Godot.GD;

public class Authentication : EzClient<Authentication>
{
    [Signal] public delegate void ReceivedAuthenticationResults(int playerId, Error result, string token);
    // [Signal] public delegate void ReceivedCreateAccountResults(int playerId, Error result, string token);

    public Authentication(ClientOptions<Authentication> options) : base(options, true, null)
    {
    }

    public override void _Ready()
    {
        base._Ready();
    }

    public void RequestAuthenticatePlayer(int playerId, string username, string password)
    {
        Print($"Requesting authenticate player. {username} {password}.");
        RpcId(1, "ReceiveAuthenticatePlayer", playerId, username, password);
    }

    [Remote]
    void ReceiveAuthenticationResults(int playerId, Error result, string token)
    {
        Print($"Results received and replying to player login request: {playerId}, {result}, {token}.");
        EmitSignal(nameof(ReceivedAuthenticationResults), playerId, result, token);
    }

}
