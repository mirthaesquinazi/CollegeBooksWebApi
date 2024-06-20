﻿using CollegeBooks.Logic.Dtos;
using FluentValidation;

namespace CollegeBooks.Logic.Validator
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.NumberOfReadings).GreaterThan(0);

        }

    }
}
