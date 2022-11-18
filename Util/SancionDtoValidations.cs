namespace ApiActividad.Util
{
    using ApiActividad.Dto;
    using FluentValidation;

    public class SancionDtoValidations:AbstractValidator<SancionDTO>
    {
        #region Validaciones
        public SancionDtoValidations()
        {

            RuleFor(s => s.Tipo).NotEmpty().WithMessage("campo tipo requerido")
            .Length(5, 100)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(s => s.Observacion).NotEmpty().WithMessage("campo observacion requerido")
            .Length(5, 100)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(s => s.Valor).NotEmpty().WithMessage("campo Valor requerido");

            RuleFor(s => s.IdentificacionId).NotEmpty().WithMessage("campo identificacion id requerido")
            .MaximumLength(20).WithMessage("el campo no debe exceder 20 caracteres");

        }
        #endregion

    }
}


/*
 mas validaciones
.NotEmpty().WithMessage("No ha indicado el nombre de usuario.") .Length(2,50).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
RuleFor(user => user.Name).NotEqual(user => user.LastName);
RuleFor(user => user.PlateNumber).Length(7,12).When(user => user.HasCar);
RuleFor(user => user.BirthDate) .Must(IsOver18) .WithMessage("Tiene que ser mayor de edad para poder registrarse.");
************************************************************************************************************
.Length(2,50)
.WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
************************************************************************************************************

RuleFor(customer => customer.Email).EmailAddress();
RuleFor(x => x.Id).ExclusiveBetween(1,10);
VALIDADOR DE PRECISION( DECIMAL)
RuleFor(x => x.Amount).ScalePrecision(2, 4);
 
 */