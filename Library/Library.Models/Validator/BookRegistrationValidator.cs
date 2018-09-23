using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Validator
{
    class BookRegistrationValidator : AbstractValidator<Book>
    {
        protected BookRegistrationValidator()
        {
            RuleFor(reg => reg.Title).NotEmpty();
            RuleFor(reg => reg.Author).NotEmpty();
            
        }
    }
}
