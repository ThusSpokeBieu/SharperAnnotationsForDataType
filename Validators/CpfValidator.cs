
using Gmess.SharperAnnotationsForDataType.Consts;

namespace Gmess.SharperAnnotationsForDataType.Validators;
internal static class CpfValidator
{

  internal static bool Validate(string potentialCpf)
  {
    if (!RegexConst.CpfDocumentRegex().IsMatch(potentialCpf)) return false;

    string cpf = RegexConst.NotNumericalDigit().Replace(potentialCpf, "");
    if (cpf.Length != 11) return false;

    bool everyDigitIsTheSame = true;

    for (int i = 0; i < cpf.Length - 1; i++)
    {
      if (cpf[i] != cpf[i + 1])
      {
        everyDigitIsTheSame = false;
        break;
      }
    }

    if (everyDigitIsTheSame) return false;

    int[] firstDigitMultipliers = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    int[] secondDigitMultipliers = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

    string cpfWithoutDigit = cpf[..9];

    int sum = 0;
    for (int i = 0; i < cpfWithoutDigit.Length; i++)
    {
      sum += int.Parse(cpfWithoutDigit[i].ToString()) * firstDigitMultipliers[i];
    }

    int rest = sum % 11;
    int firstDigitVerifier = rest < 2 ? 0 : 11 - rest;

    if (int.Parse(cpf[9].ToString()) != firstDigitVerifier) return false;

    cpfWithoutDigit += firstDigitVerifier;

    sum = 0;
    for (int i = 0; i < cpfWithoutDigit.Length; i++)
    {
      sum += int.Parse(cpfWithoutDigit[i].ToString()) * secondDigitMultipliers[i];
    }

    rest = sum % 11;
    int segundoDigitoVerificador = rest < 2 ? 0 : 11 - rest;

    return int.Parse(cpf[10].ToString()) == segundoDigitoVerificador;
  }
}
