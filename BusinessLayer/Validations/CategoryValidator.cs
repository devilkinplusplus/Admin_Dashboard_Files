using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class CategoryValidator:AbstractValidator<Category2>
    {
        public CategoryValidator()
        {
            //File Name
            RuleFor(x => x.FileName).NotEmpty().WithMessage("File name can't be empty");
            RuleFor(x => x.FileName).MinimumLength(3).WithMessage("File name must contain at least 3 characters");
            RuleFor(x => x.FileName).MaximumLength(50).WithMessage("File name must be a maximum of 50 characters");
            RuleFor(x => x.FileURL).NotEmpty().WithMessage("Can't be empty");

        }
    }
}
