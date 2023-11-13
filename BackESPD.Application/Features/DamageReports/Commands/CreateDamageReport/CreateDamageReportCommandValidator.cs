﻿using FluentValidation;

namespace BackESPD.Application.Features.DamageReports.Commands.CreateDamageReport
{
    public class CreateDamageReportCommandValidator : AbstractValidator<CreateDamageReportCommand>
    {
        public CreateDamageReportCommandValidator()
        {
            RuleFor(p => p.AddressDamage).NotEmpty().WithMessage("{ PropertyName} no puede ser vacio.")
               .MaximumLength(300).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            //=Falta terminar de configurar 
            //DescriptionDamage
            //Image
            //TrueInformation
            //TypeDamage
            //IdUser
        }
    }
}
