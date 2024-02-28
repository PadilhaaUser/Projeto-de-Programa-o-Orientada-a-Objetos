import pytest
from Program import CPF, CNPJ, PIS, InscricaoEstadualPR, TituloEleitoralPR, Documento

# CPF
def test_validar_numero_completo_cpf():
    cpf = CPF("123456789")
    assert cpf.GetNumeroCompletoCPF() == "12345678909"
    cpf = CPF("1234567")  # Preenchimento de zeros
    assert cpf.GetNumeroCompletoCPF() == "00123456797"

def test_validar_numero_formatado_cpf():
    cpf = CPF("123456789")
    assert Documento.GetNumeroFormatadoCPF(cpf.GetNumeroCompletoCPF()) == "123.456.789-09"
    cpf = CPF("1234567")  # Preenchimento de zeros
    assert Documento.GetNumeroFormatadoCPF(cpf.GetNumeroCompletoCPF()) == "001.234.567-97"

def test_cpf_valido():
    assert CPF.ValidarCPF("12345678909") is True
    assert CPF.ValidarCPF("123.456.789-09") is True

def test_cpf_invalido():
    assert not CPF.ValidarCPF("12345678967")

def test_cpf_invalido_tamanho():
    assert not CPF.ValidarCPF("123456789")

def test_cpf_invalido_caracter():
    assert not CPF.ValidarCPF("123456789xx")

# CNPJ
def test_validar_numero_completo_cnpj():
    cnpj = CNPJ("123456780001")
    assert cnpj.GetNumeroCompletoCNPJ() == "12345678000195"
    cnpj = CNPJ("12345678")  # Preenchimento de zeros
    assert cnpj.GetNumeroCompletoCNPJ() == "00001234567897"

def test_validar_numero_formatado_cnpj():
    cnpj = CNPJ("123456780001")
    assert Documento.GetNumeroFormatadoCNPJ(cnpj.GetNumeroCompletoCNPJ()) == "12.345.678/0001-95"
    cnpj = CNPJ("12345678")  # Preenchimento de zeros
    assert Documento.GetNumeroFormatadoCNPJ(cnpj.GetNumeroCompletoCNPJ()) == "00.001.234/5678-97"

def test_cnpj_valido():
    assert CNPJ.ValidarCNPJ("12345678000195") is True
    assert CNPJ.ValidarCNPJ("12.345.678/0001-95") is True

def test_cnpj_invalido():
    assert not CNPJ.ValidarCNPJ("12345678000101") 

def test_cnpj_invalido_tamanho():
    assert not CNPJ.ValidarCNPJ("123456780001")

def test_cnpj_invalido_caracter():
    assert not CNPJ.ValidarCNPJ("123456780001xx")

# PIS
def test_validar_numero_completo_PIS():
    pis = PIS("1002723088")
    assert pis.GetNumeroCompletoPIS() == "10027230888"
    pis = PIS("10027230")  # Preenchimento de zeros
    assert pis.GetNumeroCompletoPIS() == "00100272304"

def test_validar_numero_formatado_PIS():
    pis = PIS("1002723088")
    assert Documento.GetNumeroFormatadoPIS(pis.GetNumeroCompletoPIS()) == "1.002.723.088-8"
    pis = PIS("10027230")  # Preenchimento de zeros
    assert Documento.GetNumeroFormatadoPIS(pis.GetNumeroCompletoPIS()) == "0.010.027.230-4"

def test_pis_valido():
    assert PIS.ValidarPIS("10027230888") is True
    assert PIS.ValidarPIS("1.002.723.088-8") is True

def test_pis_invalido():
    assert not PIS.ValidarPIS("10027230885")

def test_pis_invalido_tamanho():
    assert not PIS.ValidarPIS("100272308")

def test_pis_invalido_caracter():
    assert not PIS.ValidarPIS("1002723088x")

# InscricaoEstadualPR
def test_validar_numero_completo_IE():
    ie = InscricaoEstadualPR("12345678")
    assert ie.GetNumeroCompletoIE() == "1234567850"
    ie = InscricaoEstadualPR("123456")  # Preenchimento de zeros
    assert ie.GetNumeroCompletoIE() == "0012345607"

def test_validar_numero_formatado_IE():
    ie = InscricaoEstadualPR("12345678")
    assert Documento.GetNumeroFormatadoIE(ie.GetNumeroCompletoIE()) == "123.45678-50"
    ie = InscricaoEstadualPR("123456")  # Preenchimento de zeros
    assert Documento.GetNumeroFormatadoIE(ie.GetNumeroCompletoIE()) == "001.23456-07"

def test_IE_valido():
    assert InscricaoEstadualPR.ValidarIE("1234567850") is True
    assert InscricaoEstadualPR.ValidarIE("123.45678-50") is True

def test_IE_invalido():
    assert not InscricaoEstadualPR.ValidarIE("1234567890")

def test_IE_invalido_tamanho():
    assert not InscricaoEstadualPR.ValidarIE("1234567")

def test_IE_invalido_caracter():
    assert not InscricaoEstadualPR.ValidarIE("12345678xx")

# TituloEleitoralPR
def test_validar_numero_completoTE():
    titulo = TituloEleitoralPR("1023850106")
    assert titulo.GetNumeroCompletoTE() == "102385010671"
    titulo = TituloEleitoralPR("10238506")  # Preenchimento de zeros
    assert titulo.GetNumeroCompletoTE() == "001023850639"

def test_validar_numero_formatadoTE():
    titulo = TituloEleitoralPR("1023850106")
    assert Documento.GetNumeroFormatadoTE(titulo.GetNumeroCompletoTE()) == "1023.8501.0671"
    titulo = TituloEleitoralPR("10238506")  # Preenchimento de zeros
    assert Documento.GetNumeroFormatadoTE(titulo.GetNumeroCompletoTE()) == "0010.2385.0639"

def test_TE_valido():
    assert TituloEleitoralPR.ValidarTE("102385010671") is True
    assert TituloEleitoralPR.ValidarTE("1023.8501.0671") is True

def test_TE_invalido():
    assert not TituloEleitoralPR.ValidarTE("102385010665")

def test_TE_invalido_tamanho():
    assert not TituloEleitoralPR.ValidarTE("10238106")

def test_TE_invalido_caracter():
    assert not TituloEleitoralPR.ValidarTE("1023850106xx")

if __name__ == "__main__":
    pytest.main()
