using Gmess.SharperAnnotationsForDataType.Validators;
using System.ComponentModel.DataAnnotations;

namespace Gmess.SharperAnnotationsForDataType.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
public sealed class CnpjDocumentAttribute : ValidationAttribute
{
  public CnpjDocumentAttribute() : base()
  {
    ErrorMessage = "The {0} property format must matches a CNPJ document from brazil.";
  }

  public override bool IsValid(object? value)
  {
    if (value == null) return true;
    if (value is not string valueAsSTring) return false;
    return CnpjValidator.Validate(valueAsSTring);
  }
}
