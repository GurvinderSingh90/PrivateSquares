using FluentValidation;
using PrivateSquares.Business.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Business.Validators
{
    public class UserRegisterViewValidator : AbstractValidator<UserView>
    {
 
    }

    public class UserLoginViewValidator : AbstractValidator<LoginView>
    {
        public UserLoginViewValidator()
        {
            RuleFor(r => r.UserName).NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(r => r.Password).NotEmpty()
                .WithMessage("Invalid password");
        }
    }
}
