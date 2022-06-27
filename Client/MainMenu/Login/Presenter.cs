using Godot;
using System;
using static Godot.GD;
using Utility;
namespace Login
{
    public class Presenter : FailSuccessEventer
    {
        public event Action signUpPressed;

        private readonly Login.View view;
        private readonly Login.Model model;

        public Presenter(Login.View view, Login.Model model)
        {
            this.view = view;
            this.model = model;

            view.Username.Connect("text_changed", this, nameof(UsernameTextChanged));
            view.Password.Connect("text_changed", this, nameof(PasswordTextChanged));
            view.Login.Connect("pressed", this, nameof(LoginButtonPressed));
            view.SignUp.Connect("pressed", this, nameof(SignUpButtonPressed));
        }

        private void SignUpButtonPressed()
        {
            signUpPressed?.Invoke();
        }

        private void PasswordTextChanged(string text)
        {
            model.Password = text;
        }

        private void UsernameTextChanged(string text)
        {
            model.Username = text;
        }

        private void LoginButtonPressed()
        {
            string result;
            if (!model.IsUsernameValid(out result))
            {
                InvokeFailed(result);
            }
            else if (!model.IsPasswordValid(out result))
            {
                InvokeFailed(result);
            }
            else
            {
                InvokeSuccess();
            }
        }
    }
}