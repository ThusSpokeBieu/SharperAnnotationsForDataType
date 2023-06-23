using Gmess.SharperAnnotationsForDataType.Enums;

namespace Gmess.SharperAnnotationsForDataType.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
public sealed class EnglishGenderAttribute : StringInEnumAttribute
{
  public EnglishGenderAttribute() : base(typeof(EnglishGenderEnum))
  {
    ErrorMessage = "The {0} property must be " + "Male, " + "Female, " +"or " + "Other.";
  }
}
