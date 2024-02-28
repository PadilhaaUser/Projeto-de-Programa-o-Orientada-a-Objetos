using System;
using System.Linq;

public class Documento
{
    protected string BaseNumber { get; set; }

    public Documento(string baseNumber, int baseLength)
    {
        if (baseNumber.Length < baseLength)
        {
            BaseNumber = baseNumber.PadLeft(baseLength, '0');
        }
        else
        {
            BaseNumber = baseNumber.Substring(0, baseLength);
        }
    }

    protected int Multiplicacao(string baseNumber, int[] pesos, Func<int, int> regra)
    {
        int soma = 0;
        for (int i = 0; i < baseNumber.Length; i++)
        {
            soma += (baseNumber[i] - '0') * pesos[i];
        }

        return regra(soma);
    }

    public static string GetNumeroFormatadoCPF(string cpfCompleto)
    {
        return $"{cpfCompleto.Substring(0, 3)}.{cpfCompleto.Substring(3, 3)}.{cpfCompleto.Substring(6, 3)}-{cpfCompleto.Substring(9)}";
    }

    public static string GetNumeroFormatadoCNPJ(string cnpjCompleto)
    {
        return $"{cnpjCompleto.Substring(0, 2)}.{cnpjCompleto.Substring(2, 3)}.{cnpjCompleto.Substring(5, 3)}/{cnpjCompleto.Substring(8, 4)}-{cnpjCompleto.Substring(12)}";
    }

    public static string GetNumeroFormatadoPIS(string pisCompleto)
    {
        return $"{pisCompleto.Substring(0, 1)}.{pisCompleto.Substring(1, 3)}.{pisCompleto.Substring(4, 3)}.{pisCompleto.Substring(7, 3)}-{pisCompleto.Substring(10)}";
    }

    public static string GetNumeroFormatadoIE(string ieCompleta)
    {
        return $"{ieCompleta.Substring(0, 3)}.{ieCompleta.Substring(3, 5)}-{ieCompleta.Substring(8)}";
    }

    public static string GetNumeroFormatadoTE(string teCompleta)
    {
        return $"{teCompleta.Substring(0, 4)}.{teCompleta.Substring(4, 4)}.{teCompleta.Substring(8)}";
    }

}

public class CPF : Documento
{
    public CPF(string cpfBase) : base(cpfBase, 9)
    {
    }

    public string CalcularDigitoVerificadorCPF()
    {
        if (BaseNumber.Length != 9 || !BaseNumber.All(char.IsDigit))
        {
            throw new ArgumentException("CPF deve conter 9 dígitos numéricos.");
        }

        int[] peso1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int primeiroDigitoVerificador = Multiplicacao(BaseNumber, peso1, total => total % 11 < 2 ? 0 : 11 - (total % 11));

        BaseNumber += primeiroDigitoVerificador;

        int[] peso2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int segundoDigitoVerificador = Multiplicacao(BaseNumber, peso2, total => total % 11 < 2 ? 0 : 11 - (total % 11));

        BaseNumber += segundoDigitoVerificador;

        return BaseNumber;
    }

    public string GetNumeroCompletoCPF()
    {
        return CalcularDigitoVerificadorCPF();
    }

    public static bool ValidarCPF(string cpfCompleto)
    {
        string cpfNumeros = new string(cpfCompleto.Where(char.IsDigit).ToArray());

        if (cpfNumeros.Length != 11)
        {
            return false;
        }

        string cpfBase = cpfNumeros.Substring(0, 9);
        string cpfCalculado = new CPF(cpfBase).CalcularDigitoVerificadorCPF();

        if (cpfCalculado != cpfNumeros)
        {
            return false;
        }

        return true;
    }
}

public class CNPJ : Documento
{
    public CNPJ(string cnpjBase) : base(cnpjBase, 12)
    {
    }

    public string CalcularDigitoVerificadorCNPJ()
    {
        if (BaseNumber.Length != 12 || !BaseNumber.All(char.IsDigit))
        {
            throw new ArgumentException("CNPJ deve conter 12 dígitos numéricos.");
        }

        int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int primeiroDigitoVerificador = Multiplicacao(BaseNumber, multiplicadores1, total => total % 11 < 2 ? 0 : 11 - (total % 11));

        BaseNumber += primeiroDigitoVerificador;

        int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int segundoDigitoVerificador = Multiplicacao(BaseNumber, multiplicadores2, total => total % 11 < 2 ? 0 : 11 - (total % 11));

        BaseNumber += segundoDigitoVerificador;

        return BaseNumber;
    }

    public string GetNumeroCompletoCNPJ()
    {
        return CalcularDigitoVerificadorCNPJ();
    }

    public static bool ValidarCNPJ(string cnpjCompleto)
    {
        string cnpjNumeros = new string(cnpjCompleto.Where(char.IsDigit).ToArray());

        if (cnpjNumeros.Length != 14)
        {
            return false;
        }

        string cnpjBase = cnpjNumeros.Substring(0, 12);
        string cnpjCalculado = new CNPJ(cnpjBase).CalcularDigitoVerificadorCNPJ();

        if (cnpjCalculado != cnpjNumeros)
        {
            return false;
        }

        return true;
    }
}


public class PIS : Documento
{
    public PIS(string pisBase) : base(pisBase, 10)
    {
    }

    public int CalcularDigitoVerificadorPIS()
    {
        if (BaseNumber.Length != 10 || !BaseNumber.All(char.IsDigit))
        {
            throw new ArgumentException("O número do PIS deve conter 10 dígitos.");
        }

        int[] peso = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma = Multiplicacao(BaseNumber, peso, total => 11 - (total % 11));
        int result = 0;

        if (soma == 10 || soma == 11)
        {
            result = 0;
        }
        else
        {
            result = soma;
        }

        return result;
    }


    public string GetNumeroCompletoPIS()
    {
        return BaseNumber + CalcularDigitoVerificadorPIS();
    }

    public static bool ValidarPIS(string pisCompleto)
    {
        string pisSemFormatacao = new string(pisCompleto.Where(char.IsDigit).ToArray());

        if (pisSemFormatacao.Length != 11 || !pisSemFormatacao.All(char.IsDigit))
        {
            return false;
        }

        string pisBase = pisSemFormatacao.Substring(0, 10);
        int pisCalculado = new PIS(pisBase).CalcularDigitoVerificadorPIS();

        if (pisCalculado != int.Parse(pisSemFormatacao.Substring(10, 1)))
        {
            return false;
        }

        return true;
    }
}

public class InscricaoEstadualPR : Documento
{
    public InscricaoEstadualPR(string ieBase) : base(ieBase, 8)
    {
    }

    public string CalcularDigitoVerificadorIE()
    {
        int[] pesoPrimeiroDigito = { 3, 2, 7, 6, 5, 4, 3, 2 };
        int somaPrimeiroDigito = Multiplicacao(BaseNumber, pesoPrimeiroDigito, total => 11 - (total % 11));
        int primeiroDigito = somaPrimeiroDigito >= 10 ? 0 : somaPrimeiroDigito;

        string inscricaoComPrimeiroDigito = BaseNumber + primeiroDigito;

        int[] pesoSegundoDigito = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
        int somaSegundoDigito = Multiplicacao(inscricaoComPrimeiroDigito, pesoSegundoDigito, total => 11 - (total % 11));
        int segundoDigito = somaSegundoDigito >= 10 ? 0 : somaSegundoDigito;

        return inscricaoComPrimeiroDigito + segundoDigito;
    }

    public string GetNumeroCompletoIE()
    {
        return CalcularDigitoVerificadorIE();
    }

    public static bool ValidarIE(string ieCompleta)
    {
        string ieSemFormatacao = new string(ieCompleta.Where(char.IsDigit).ToArray());

        if (ieSemFormatacao.Length != 10 || !ieSemFormatacao.All(char.IsDigit))
        {
            return false;
        }

        string ieBase = ieSemFormatacao.Substring(0, 8);
        string ieCalculada = new InscricaoEstadualPR(ieBase).CalcularDigitoVerificadorIE();

        if (ieCalculada != ieSemFormatacao)
        {
            return false;
        }

        return true;
    }
}

public class TituloEleitoralPR : Documento
{
    public TituloEleitoralPR(string teBase) : base(teBase, 10)
    {
    }

    public string CalcularDigitoVerificadorTE()
    {
        int[] peso1 = { 2, 3, 4, 5, 6, 7, 8, 9 };
        int somaPrimeiroDigito = Multiplicacao(BaseNumber.Substring(0, 8), peso1, total => total % 11);
        int primeiroDigito = somaPrimeiroDigito == 10 ? 0 : somaPrimeiroDigito;

        char digito1UF = BaseNumber[8];
        char digito2UF = BaseNumber[9];

        int[] peso2 = { 7, 8, 9 };
        int somaSegundoDigito = Multiplicacao($"{digito1UF}{digito2UF}{primeiroDigito}", peso2, total => total % 11);
        int segundoDigito = somaSegundoDigito == 10 ? 0 : somaSegundoDigito;

        return $"{BaseNumber}{primeiroDigito}{segundoDigito}";
    }

    public string GetNumeroCompletoTE()
    {
        return CalcularDigitoVerificadorTE();
    }

    public static bool ValidarTE(string teCompleta)
    {
        string teSemFormatacao = new string(teCompleta.Where(char.IsDigit).ToArray());

        if (teSemFormatacao.Length != 12 || !teSemFormatacao.All(char.IsDigit))
        {
            return false;
        }

        string teBase = teSemFormatacao.Substring(0, 10);
        string teCalculada = new TituloEleitoralPR(teBase).CalcularDigitoVerificadorTE();

        return teCalculada == teSemFormatacao;
    }
}
