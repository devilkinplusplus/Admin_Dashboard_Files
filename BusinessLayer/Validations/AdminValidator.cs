using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            //Name validations
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username can't be empty !");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Name must contain at least 3 characters"); 
            RuleFor(x => x.Username).MaximumLength(50).WithMessage("Name must be a maximum of 50 characters");
            RuleFor(x => x.Username).Custom((x, context) =>
            {
                if (x != null)
                {
                    foreach (var item in x)
                    {
                        if (char.IsNumber(item))
                        {
                            context.AddFailure("Name can't contains number");
                            break;
                        }
                    }
                }
            });

            //Email validatons
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address can't be empty !");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address !");

            //Password validations
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty !");
            RuleFor(x => x.Password).MinimumLength(4).WithMessage("Password must contain at least 3 characters");
            RuleFor(x => x.Password).MaximumLength(16).WithMessage("Password must be a maximum of 16 characters");
            RuleFor(x => x.Password).Matches(@"[A-Z]+").WithMessage("Password must consist of at least one capital letter");
            RuleFor(x => x.Password).Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter");
            RuleFor(x => x.Password).Matches(@"[0-9]+").WithMessage("Password must contain at least one number");

        }
    }
}
