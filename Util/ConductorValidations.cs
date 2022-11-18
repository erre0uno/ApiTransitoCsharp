namespace ApiActividad.Util
{
    using ApiActividad.Entitys;
    using FluentValidation;


    public class ConductorValidations: AbstractValidator<Conductor>
    {
        #region Validaciones
        public ConductorValidations() {
            RuleFor(v => v.Identificacion).NotEmpty().WithMessage("campo identificacion requerido")
            .Length(3, 20)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(v => v.Nombre).NotEmpty().WithMessage("campo Nombre requerido")
            .Length(3, 20)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(v => v.Apellidos).NotEmpty().WithMessage("campo Apellidos requerido")
            .Length(3, 20)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(v => v.Direccion).NotEmpty().WithMessage("campo Direccion requerido")
            .Length(3, 20)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(v => v.Telefono).NotEmpty().WithMessage("campo Telefono requerido")
            .Length(3, 20)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(v => v.Correo).NotEmpty().WithMessage("campo Correo requerido")
            .EmailAddress()
            .Length(3, 20)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(v => v.FechaNacimiento).NotEmpty().WithMessage("campo Fecha Nacimiento requerido");

            RuleFor(v => v.Activo).NotEmpty().WithMessage("campo Activo requerido");

            RuleFor(v => v.MatriculaId).NotEmpty().WithMessage("campo Matricula Id requerido")
            .Length(3, 20)
            .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
        }
        #endregion
    }
}

