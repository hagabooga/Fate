using Godot;
using System;
using Utility;

namespace CreateAccount
{
    public class View : EzPrefab
    {
        public readonly Control Root;
        public readonly Label Title;
        public readonly LineEdit Username, Password, ConfirmPassword;
        public readonly Button CreateAccount;
        public readonly VBoxContainer Content;
    }
}