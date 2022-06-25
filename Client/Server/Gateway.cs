using Godot;
using System;
using Utility;

public class Gateway : EzClient<Gateway>
{
    [Signal] public delegate void ReceivedLoginRequest();

    string username, password;
    bool isNewAccount;

    public Gateway(ClientOptions<Gateway> options,
                   X509Certificate certificate) : base(options,
                                                              false,
                                                              certificate)
    {
    }

    public void ConnectToServer(string username,
                                string password,
                                bool isNewAccount = false,
                                string ip = "localhost")
    {
        CreateClient();
        this.username = username;
        this.password = password;
        this.isNewAccount = isNewAccount;
    }

    protected override void OnConnectedToServer()
    {
        base.OnConnectedToServer();
        RequestLoginRequest();
    }

    [Remote]
    void ReceiveLoginRequest(Error result, string token)
    {
        EmitSignal(nameof(ReceivedLoginRequest), result);
    }

    private void RequestLoginRequest()
    {
        RpcId(1, "ReceiveLoginRequest", username, password.SHA256Text());
        username = "";
        password = "";
    }
}
