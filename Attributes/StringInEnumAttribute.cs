using System.ComponentModel.DataAnnotations;

namespace Gmess.SharperAnnotationsForDataType.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
public class StringInEnumAttribute : DataTypeAttribute
{

  public Type ValidEnum { get; set; }
  public bool CaseSensitive { get; set; } = false;

  public StringInEnumAttribute(Type validEnum) : base("Enum Validator")
  {
    if (!validEnum.IsEnum) throw new Exception("EnumValidator must have a ValidEnum");
    ValidEnum = validEnum;
    ErrorMessage = "The {0} property might have a value that matches the enum.";
  }

  public override bool IsValid(object? value)
  {
    if (value == null || ValidEnum == null || !ValidEnum.IsEnum) return true;
    if (value is not string valueAsString) return false;

    if (CaseSensitive) return ValidateCaseSensitive(valueAsString);
    return ValidateWithoutCaseSensitive(valueAsString);
  }
 
  private bool ValidateWithoutCaseSensitive(in string valueAsString)
  {
    bool isValid = false;

    Array validValues = Enum.GetValues(ValidEnum);

    foreach (var validValue in validValues)
    {
      if (validValue?.ToString()?.ToLower() == valueAsString.ToLower())
      {
        isValid = true;
        break;
      }
    }

    return isValid;
  }

  private bool ValidateCaseSensitive(in string valueAsString)
  {
    bool isValid = false;

    Array validValues = Enum.GetValues(ValidEnum);

    foreach (var validValue in validValues)
    {
      if (validValue.ToString() == valueAsString)
      {
        isValid = true;
        break;
      }
    }

    return isValid;
  }

}
