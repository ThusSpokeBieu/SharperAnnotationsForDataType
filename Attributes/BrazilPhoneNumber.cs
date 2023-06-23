using Gmess.SharperAnnotationsForDataType.Consts;
using System.ComponentModel.DataAnnotations;

namespace Gmess.SharperAnnotationsForDataType.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
public sealed class BrazilPhoneNumber : RegularExpressionAttribute
{
  public BrazilPhoneNumber() : base(RegexPatterns.BrazilPhoneNumber)
  {
    ErrorMessage = "The {0} must match a valid format for a Brazil phone number.";
  }
}
