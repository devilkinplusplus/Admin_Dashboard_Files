using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class MailValidator:AbstractValidator<FileOperation>
    {
        public MailValidator()
        {
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Can't be empty");
            RuleFor(x => x.ReceiverID).NotEmpty().WithMessage("Can't be empty");
        }
    }
}
