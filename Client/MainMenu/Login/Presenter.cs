using Godot;
using System;
using static Godot.GD;
using Utility;
using System.Collections.Generic;

namespace Login
{
    public class Presenter : FailSuccessEventer
    {
        public event Action signUpPressed;

        readonly Tween tween = new Tween();

        private readonly Login.View view;
        private readonly Login.Model model;

        public string Username => model.Username;
        public string Password => model.Password;


        public Presenter(Login.View view, Login.Model model)
        {
            this.view = view;
            this.model = model;

            view.Username.Connect("text_changed", this, nameof(UsernameTextChanged));
            view.Password.Connect("text_changed", this, nameof(PasswordTextChanged));
            view.Login.Connect("pressed", this, nameof(LoginButtonPressed));
            view.SignUp.Connect("pressed", this, nameof(SignUpButtonPressed));


            failed += msg =>
            {
                view.Result.Text = msg;
                tween.RemoveAll();
                tween.InterpolateProperty(view.Result,
                              "self_modulate",
                              Colors.White,
                              Colors.Transparent,
                              3,
                              Tween.TransitionType.Quad);
                tween.Start();
            };
        }

        public override void _Ready()
        {
            base._Ready();

            AddChild(tween);
        }

        public void SetVisible(bool yes) => view.Root.Visible = yes;



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