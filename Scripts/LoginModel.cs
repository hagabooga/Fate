using Godot;
using System;
using static Godot.GD;

public sealed partial class LoginModel
{
    public event Action<string> OnResultOutput;

    private const int MinimumPasswordLength = 7;

    string _ipAddress;

    public string Username { get; set; }
    public string Password { get; set; }
    public string IpAddress
    {
        get => _ipAddress.IsNullOrEmpty() ? "localhost" : _ipAddress;
        set => _ipAddress = value;
    }

    public bool IsValidUsername
    {
        get
        {
            bool ok = true;
            if (Username.IsNullOrEmpty())
            {
                ok = false;
                OnResultOutput?.Invoke("Please provide a valid username!");
            }
            return ok;
        }
    }

    public bool IsValidPassword
    {
        get
        {
            bool ok = true;
            if (Password.IsNullOrEmpty())
            {
                ok = false;
                OnResultOutput?.Invoke("Please provide a valid password!");
            }
            else if (Password.Length < MinimumPasswordLength)
            {
                ok = false;
                OnResultOutput?.Invoke("Password must contain at least 7 characters.");
            }
            return ok;
        }
    }

    public bool IsValidIpAddress
    {
        get
        {
            bool ok = true;
            if (!IpAddress.IsValidIPAddress())
            {
                if (IpAddress == "localhost")
                {
                    return ok;
                }
                ok = false;
                OnResultOutput?.Invoke("Please enter a valid IP address!");
            }
            return ok;
        }
    }
}
