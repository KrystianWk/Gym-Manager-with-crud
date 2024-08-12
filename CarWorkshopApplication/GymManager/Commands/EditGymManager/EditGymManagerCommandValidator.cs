using FluentValidation;
using GymManagerDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.Commands.EditGymManager
{
    public class EditGymManagerCommandValidator : AbstractValidator<EditGymManagerCommand>

    {
        public EditGymManagerCommandValidator()
        {
           

            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required")
                .Matches(@"^\d{9}$")
                .WithMessage("Phone number must be 9 digits");
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not valid")

                .Custom((value, context) =>
                {
                    if (value.Contains("test"))
                    {
                        context.AddFailure("Email cannot contain test");
                    }
                });

        }
    }
}
