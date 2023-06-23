using Gmess.SharperAnnotationsForDataType.Validators;
using System.ComponentModel.DataAnnotations;

namespace Gmess.SharperAnnotationsForDataType.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
public sealed class CpfOrCnpjDocumentAttribute : ValidationAttribute
{

  public CpfOrCnpjDocumentAttribute() : base() 
  {
    ErrorMessage = "The {0} property format must matches a document from brazil (CPF or CNPJ).";
  }

  public override bool IsValid(object? value)
  {
    if (value == null) return true;
    if (value is not string valueAsSTring) return false;
        
    return CpfValidator.Validate(valueAsSTring) || CnpjValidator.Validate(valueAsSTring);
  }

}
