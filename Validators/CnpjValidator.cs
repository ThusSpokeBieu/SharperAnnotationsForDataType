using Gmess.SharperAnnotationsForDataType.Consts;

namespace Gmess.SharperAnnotationsForDataType.Validators;
internal class CnpjValidator
{
  internal static bool Validate(string potentialCnpj)
  {
    if (!RegexConst.CnpjDocumentRegex().IsMatch(potentialCnpj)) return false;

    string cnpj = RegexConst.NotNumericalDigit().Replace(potentialCnpj, "");
    if (cnpj.Length != 14) return false;


    bool everyDigitIsTheSame = true;

    for (int i = 0; i < cnpj.Length - 1; i++)
    {
      if (cnpj[i] != cnpj[i + 1])
      {
        everyDigitIsTheSame = false;
        break;
      }
    }

    if (everyDigitIsTheSame) return false;

    int[] factors = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
    int[] digits = cnpj.Select(c => int.Parse(c.ToString())).ToArray();
    int[] calculatedDigits = digits.Take(12)
        .Select((digit, index) => digit * factors[index])
        .ToArray();

    int sum = calculatedDigits.Sum();
    int firstDigit = sum % 11 < 2 ? 0 : 11 - sum % 11;

    calculatedDigits = digits.Take(13)
        .Select((digit, index) => digit * factors[index])
        .ToArray();

    sum = calculatedDigits.Sum() + firstDigit * factors[12];
    int secondDigit = sum % 11 < 2 ? 0 : 11 - sum % 11;

    return digits[12] == firstDigit && digits[13] == secondDigit;
  }


}
