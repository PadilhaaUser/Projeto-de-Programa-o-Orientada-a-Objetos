using NUnit.Framework;
using NUnit.Framework.Constraints;

[TestFixture]
public class Tests
{
    //CPF
    [TestCase("123456789", "12345678909")]
    [TestCase("1234567", "00123456797")] //preenchimento de zeros
    public void test_validar_numero_completo_cpf(string cpf_base, string expectedResult)
    {
        CPF cPF = new CPF(cpf_base);
        string result = cPF.GetNumeroCompletoCPF();
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("123456789", "123.456.789-09")]
    [TestCase("1234567", "001.234.567-97")] //preenchimento de zeros
    public void test_validar_numero_formatado_cpf(string cpfBase, string expectedFormattedNumber)
    {
        CPF cpf = new CPF(cpfBase);
        string result = Documento.GetNumeroFormatadoCPF(cpf.GetNumeroCompletoCPF());
        Assert.That(result, Is.EqualTo(expectedFormattedNumber));
    }

    [TestCase("12345678909", true)]
    [TestCase("123.456.789-09", true)]
    [TestCase("12345678934", false)]
    [TestCase("1234567890a", false)]
    [TestCase("123456789012", false)]
    public void test_valida_cpf(string cpfCompleto, bool expectedResult)
    {
        bool result = CPF.ValidarCPF(cpfCompleto);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    //CNPJ
    [TestCase("123456780001", "12345678000195")]
    [TestCase("12345678", "00001234567897")] //preenchimento de zeros
    public void test_validar_numero_completo_cnpj(string cnpj_base, string expectedResult)
    {
        CNPJ cNPJ = new CNPJ(cnpj_base);
        string result = cNPJ.GetNumeroCompletoCNPJ();
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("123456780001", "12.345.678/0001-95")]
    [TestCase("12345678", "00.001.234/5678-97")] //preenchimento de zeros
    public void test_validar_numero_formatado_cnpj(string cnpjBase, string expectedFormattedNumber)
    {
        CNPJ cnpj = new CNPJ(cnpjBase);
        string result = Documento.GetNumeroFormatadoCNPJ(cnpj.GetNumeroCompletoCNPJ());
        Assert.That(result, Is.EqualTo(expectedFormattedNumber));
    }

    [TestCase("12345678000195", true)]
    [TestCase("12.345.678/0001-95", true)]
    [TestCase("12345678000156", false)]
    [TestCase("123456780001xx", false)]
    [TestCase("123456780001", false)]
    public void test_valida_cnpj(string cnpjCompleto, bool expectedResult)
    {
        bool result = CNPJ.ValidarCNPJ(cnpjCompleto);
        Assert.That(result, Is.EqualTo(expectedResult));
    }


    //PIS
    [TestCase("1002723088", "10027230888")]
    [TestCase("10027230", "00100272304")] //preenchimento de zeros
    public void test_validar_numero_completo_pis(string pis_base, string expectedResult)
    {
        PIS pIS = new PIS(pis_base);
        string result = pIS.GetNumeroCompletoPIS();
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("1002723088", "1.002.723.088-8")]
    [TestCase("10027230", "0.010.027.230-4")] //preenchimento de zeros
    public void test_validar_numero_formatado_PIS(string pisBase, string expectedFormattedNumber)
    {
        PIS pis = new PIS(pisBase);
        string result = Documento.GetNumeroFormatadoPIS(pis.GetNumeroCompletoPIS());
        Assert.That(result, Is.EqualTo(expectedFormattedNumber));
    }

    [TestCase("10027230888", true)]
    [TestCase("1.002.723.088-8", true)]
    [TestCase("10027230884", false)]
    [TestCase("1002723088x", false)]
    [TestCase("100272308", false)]
    public void test_valida_pis(string pisCompleto, bool expectedResult)
    {
        bool result = PIS.ValidarPIS(pisCompleto);
        Assert.That(result, Is.EqualTo(expectedResult));
    }


    //IE
    [TestCase("12345678", "1234567850")]
    [TestCase("123456", "0012345607")] //preenchimento de zeros
    public void test_validar_numero_completo_IE(string ie_base, string expectedResult)
    {
        InscricaoEstadualPR inscricaoEstadualPR = new InscricaoEstadualPR(ie_base);
        string result = inscricaoEstadualPR.GetNumeroCompletoIE();
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("12345678", "123.45678-50")]
    [TestCase("123456", "001.23456-07")] //preenchimento de zeros
    public void test_validar_numero_formatado_IE(string ieBase, string expectedFormattedNumber)
    {
        InscricaoEstadualPR inscricaoEstadualPR = new InscricaoEstadualPR(ieBase);
        string result = Documento.GetNumeroFormatadoIE(inscricaoEstadualPR.GetNumeroCompletoIE());
        Assert.That(result, Is.EqualTo(expectedFormattedNumber));
    }

    [TestCase("1234567850", true)]
    [TestCase("123.45678-50", true)]
    [TestCase("1234567829", false)]
    [TestCase("12345678xx", false)]
    [TestCase("1234567", false)]
    public void test_valida_IE(string ieCompleto, bool expectedResult)
    {
        bool result = InscricaoEstadualPR.ValidarIE(ieCompleto);
        Assert.That(result, Is.EqualTo(expectedResult));
    }


    //TE
    [TestCase("1023850106", "102385010671")]
    [TestCase("10238506", "001023850639")] //preenchimento de zeros
    public void test_validar_numero_completo_TE(string te_base, string expectedResult)
    {
        TituloEleitoralPR tituloEleitoralPR = new TituloEleitoralPR(te_base);
        string result = tituloEleitoralPR.GetNumeroCompletoTE();
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("102385010671", "1023.8501.0671")]
    [TestCase("001023850639", "0010.2385.0639")]
    public void test_validar_numero_formatado_TE(string teBase, string expectedFormattedNumber)
    {
        TituloEleitoralPR tituloEleitoralPR = new TituloEleitoralPR(teBase);
        string result = Documento.GetNumeroFormatadoTE(tituloEleitoralPR.GetNumeroCompletoTE());
        Assert.That(result, Is.EqualTo(expectedFormattedNumber));
    }

    [TestCase("102385010671", true)]
    [TestCase("1023.8501.0671", true)]
    [TestCase("102385010689", false)]
    [TestCase("1023850106xx", false)]
    [TestCase("10238506", false)]
    public void test_valida_TE(string teCompleto, bool expectedResult)
    {
        bool result = TituloEleitoralPR.ValidarTE(teCompleto);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

}
