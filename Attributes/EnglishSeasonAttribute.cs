using Gmess.SharperAnnotationsForDataType.Enums;

namespace Gmess.SharperAnnotationsForDataType.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
internal sealed class EnglishSeasonAttribute : StringInEnumAttribute
{
  public EnglishSeasonAttribute() : base(typeof(EnglishGenderEnum))
  {
    ErrorMessage = "The {0} property must be " + "Spring, " + "Summer, " + "Autumn, "+ "or " + "Winter.";
  }
}
