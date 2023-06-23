using System.Text.RegularExpressions;

namespace Gmess.SharperAnnotationsForDataType.Consts;
internal static partial class RegexConst
{
  [GeneratedRegex(RegexPatterns.CnpjOrCpfDocument)]
  internal static partial Regex CpfOrCnpjDocumentRegex();

  [GeneratedRegex(RegexPatterns.NotNumericalDigit)]
  internal static partial Regex NotNumericalDigit();

  [GeneratedRegex(RegexPatterns.CpfDocument)]
  internal static partial Regex CpfDocumentRegex();

  [GeneratedRegex(RegexPatterns.CnpjDocument)]
  internal static partial Regex CnpjDocumentRegex();
}
