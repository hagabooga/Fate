using Godot;
using System;
using Utility;

public class Gateway : EzClient<Gateway>
{
    public event Action receivedLoginRequest;

    public Gateway(ClientOptions<Gateway> options,
                   X509Certificate certificate) :
                   base(options,
                        false,
                        certificate)
    {
    }

    public void RequestLoginRequest(string username, string password, string ip)
    {
        CreateClient(ip);
        connectedToServer += () =>
        {
            RpcId(1, "ReceiveLoginRequest", username, password.SHA256Text());
        };
    }

    private void RequestCreateAccount()
    {

    }


    [Remote]
    void ReceiveLoginRequest(Error result, string token)
    {
        receivedLoginRequest?.Invoke();
    }


}
