using Gmess.SharperAnnotationsForDataType.Validators;
using System.ComponentModel.DataAnnotations;

namespace Gmess.SharperAnnotationsForDataType.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
public sealed class CpfDocumentAttribute : ValidationAttribute
{
  public CpfDocumentAttribute() : base() 
  {
    ErrorMessage = "The {0} property format must matches a CPF document from brazil.";
  }

  public override bool IsValid(object? value)
  {
    if (value == null) return true;
    if (value is not string valueAsSTring) return false;
    return CpfValidator.Validate(valueAsSTring);
  }
}
