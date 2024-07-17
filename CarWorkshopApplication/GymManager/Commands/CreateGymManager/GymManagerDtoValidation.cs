using FluentValidation;
using GymManagerDomain.Interfaces;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.Commands.CreateGymManager
{
    public class GymManagerCommandValidation : AbstractValidator<CreateGymManagerCommands>
    {
        public GymManagerCommandValidation(IGymManagerRepository repository)
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MaximumLength(10)
                .WithMessage("First name must be less than 10 characters");
            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MaximumLength(10)
                .WithMessage("Last name must be less than 10 characters");

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
                    var existingEmail = repository.GetByEmail(value).Result;
                    if (existingEmail != null)
                    {
                        context.AddFailure($"{value} Email already exists");
                    }
                })
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
