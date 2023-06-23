using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Gmess.SharperAnnotationsForDataType.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
public class RegexValidatorAttribute : DataTypeAttribute
{
  public string Pattern { get; set; }

  public RegexValidatorAttribute(in string pattern) : base("Regex validator")
  {
    Pattern = pattern;
    ErrorMessage = "The {0} field must match the regex pattern.";
  }

  public override bool IsValid(object? value)
  {

    if (value == null || Pattern == null) return true;
    if (value is not string valueAsString) return false;
    Regex validRegex = new(Pattern);

    return validRegex.IsMatch(valueAsString);
  }
}
