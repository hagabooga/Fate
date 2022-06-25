using Godot;
using System;
using Utility;
using static Godot.GD;

public class Gateway : EzServer<Gateway>
{
    private readonly Authentication authentication;

    public Gateway(ServerOptions<Gateway> options,
                   X509Certificate certificate,
                   CryptoKey cryptoKey,
                   Authentication authentication) : base(options, certificate, cryptoKey)
    {
        this.authentication = authentication;
        this.authentication.Connect(nameof(Authentication.ReceivedAuthenticationResults), this, nameof(ReturnLoginRequest));
    }

    public override void _Ready()
    {
        base._Ready();
    }

    private void ReturnLoginRequest(int playerId, Error result, string token)
    {
        RpcId(playerId, "ReceiveLoginRequest", result, token);
        network.DisconnectPeer(playerId);
    }

    [Remote]
    void ReceiveLoginRequest(string username, string password)
    {
        Print("Login request received.");
        var playerId = CustomMultiplayer.GetRpcSenderId();
        authentication.RequestAuthenticatePlayer(playerId, username, password);

    }

}
