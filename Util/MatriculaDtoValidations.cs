namespace ApiActividad.Util
{
    using ApiActividad.Dto;
    using FluentValidation;

    public class MatriculaDtoValidations: AbstractValidator<MatriculaDTO>
    {
        #region Validaciones
        public MatriculaDtoValidations() {

        RuleFor(v => v.Numero).NotEmpty().WithMessage("campo Numero requerido")
        .Length(3, 20)
        .WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
        RuleFor(v => v.Expedicion).NotEmpty().WithMessage("campo fecha de expedicion requerido");
        RuleFor(v => v.Valido).NotEmpty().WithMessage("campo fecha de validez requerido");
        RuleFor(v => v.Activo).NotEmpty().WithMessage("campo activo requerido");
        }
        #endregion
    }
}
