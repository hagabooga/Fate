using Godot;
using System;
using static Godot.GD;
using Utility;

namespace CreateAccount
{
    public class Presenter : FailSuccessEventerWithTween
    {
        public event Action goBackToLoginPressed;

        private readonly View view;
        private readonly Model model;

        public Presenter(View view, Model model)
        {
            this.view = view;
            this.model = model;

            view.Username.Connect("text_changed", this, nameof(UsernameTextChanged));
            view.Password.Connect("text_changed", this, nameof(PasswordTextChanged));
            view.ConfirmPassword.Connect("text_changed", this, nameof(ConfirmPasswordTextChanged));
            view.CreateAccount.Connect("pressed", this, nameof(CreateAccountButtonPressed));
            view.GoBackToLogin.Connect("pressed", this, nameof(GoBackToLoginButtonPressed));

            AddShortPopupTween(view.Result);
        }

        private void GoBackToLoginButtonPressed()
        {
            goBackToLoginPressed?.Invoke();
        }

        public void SetVisible(bool yes) => view.Root.Visible = yes;


        private void ConfirmPasswordTextChanged(string text)
        {
            model.ConfirmPassword = text;
        }

        private void PasswordTextChanged(string text)
        {
            model.Password = text;
        }

        private void UsernameTextChanged(string text)
        {
            model.Username = text;
        }

        private void CreateAccountButtonPressed()
        {
            string result;
            if (!model.IsValidUsername(out result))
            {
                InvokeFailed(result);
            }
            else if (!model.IsValidPassword(out result))
            {
                InvokeFailed(result);
            }
            else if (!model.IsConfirmPasswordValid(out result))
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