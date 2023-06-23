# SharperAnnotationsForDataType

Biblioteca de estudo para criação de anotações personalizadas de DataType (e também para evitar ter que ficar criando essas anotações para cada projeto que eu tiver que fazer).

Algumas das anotações são parecidas com as nativas porque descobri que já havia nativo depois, mas, ainda há diferenças quanto ao funcionamento e a biblioteca permite maior personalização para o futuro.

A biblioteca utiliza apenas das anotações de DataType já fornecidas pelo pr óprio C#.

## Regex
A biblioteca tem como uma de suas funções gerar alguns regexes em tempo de compilação, otimizando a performace das validações.

Atuais Regex:
- **NotNumericalDigit** regex que seleciona digitos não númericos.
- **CpfDocumentRegex** regex para o formato de CPF.
- **CnpjDocumenteRegex** regex para formato de CNPJ.
- **CpfOrCnpjDocumentRegex** regex para formato de CPF ou CNPJ.

## Atributos
<br>

## **[StringInEnum(typeof(Enum))]**

Passando um tipo de Enum como parâmetro de construtor dessa anotação, você valida se a string tem um valor parecido com algum dos valores do Enum. 

Esse atributo tem um parâmetro CaseSensitive que por padrão é falso, mas pode ser colocado como true.

```C#
public enum BrazilianGenderEnum {
  Masculino,
  Feminino,
  Outro
}
```

```C#

public class Pessoa {

  [StringInEnum(typeof(BrazilianGenderEnum))]
  public string Genero { get; set; }

  // Verifica se o valor da string está dentro do enum "BrazilianGenderEnum":
  // "Masculino", "Feminino" e "Outro".

}
```

No exemplo anterior, existe um enum de gênero brasileiros: "Masculino", "Feminino" ou "Outro". O código vai verificar se a string "Genero" da classe "Pessoa" possui um dos valores nesta enum. 
<br>

## **[EnglishGender]**

Verifica se a string possui um desses valores de gênero em inglês: "Male", "Female", ou "Other". Por padrão, não é case sensitive.

```C#
public class Person {

  [EnglishGender]
  public string Gender { get; set; }
  // Verifica se é:
  // - Male
  // - Female
  // - Other


}
```
<br>

## **[EnglishSeason]**
Verifica se a string possui um desses valores de estação do ano em inglês: "Spring", "Summer", "Autumn" ou "Winter". Por padrão, não é case sensitive.

```C#
public class Movie {

  [EnglishSeason]
  public string RelaseSeason { get; set; }
  // Verifica se é o valor é:
  // - Spring, Summer, Autumn ou Winter

}
```

## **[BrazilPhone]**
Verifica o regex de um número de telefone do Brasil. Aceita apenas números e pode funcionar para celular ou numero de telefone.

```C#
public class Person {

  [BrazilPhone]
  public string Phone { get; set; }
  // Verifica o formato: 
  // (XX) XXXXX-XXXX
}
```

## **[CpfDocument]**
Verifica se o formato do documento é um CPF. Aceita apenas números. A validação não é apenas de Regex.

```C#
public class Person {

  [CpfDocument]
  public string Cpf { get; set; }

  // Aceita strings no formato:
  // XXX.XXX.XXX-XX
  // Aceita apenas números.
}
```

## **[CnpjDocument]**

Verifica se o formato do documento é um CNPJ. Aceita apenas números. A validação não é apenas de Regex, envolve também algumas lógicas.

```C#
public class Company {

  [CnpjDocument]
  public string Cnpj { get; set; }
  // Aceito no formato:
  // XX.XXX.XXX/XXXX-XX.
  // Pode aceitar apenas números.
}
```