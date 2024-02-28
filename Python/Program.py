class Documento:
    @staticmethod
    def multiplicacao(digitos, pesos):
        return sum(int(digitos[i]) * pesos[i] for i in range(len(digitos)))

    @staticmethod
    def GetNumeroFormatadoCPF(cpf_completo):
        return f"{cpf_completo[:3]}.{cpf_completo[3:6]}.{cpf_completo[6:9]}-{cpf_completo[9:]}"

    @staticmethod
    def GetNumeroFormatadoCNPJ(cnpj_completo):
        return f"{cnpj_completo[:2]}.{cnpj_completo[2:5]}.{cnpj_completo[5:8]}/{cnpj_completo[8:12]}-{cnpj_completo[12:]}"

    @staticmethod
    def GetNumeroFormatadoPIS(pis_completo):
        return f"{pis_completo[:1]}.{pis_completo[1:4]}.{pis_completo[4:7]}.{pis_completo[7:10]}-{pis_completo[-1]}"

    @staticmethod
    def GetNumeroFormatadoIE(ie_completa):
        return f"{ie_completa[:3]}.{ie_completa[3:8]}-{ie_completa[8:10]}"

    @staticmethod
    def GetNumeroFormatadoTE(te_completa):
        return f"{te_completa[:4]}.{te_completa[4:8]}.{te_completa[8:12]}"


class CPF:
    def __init__(self, cpf_base):
        if len(cpf_base) < 9:
            cpf_base = cpf_base.zfill(9)
        self.cpf_base = cpf_base

    def CalcularDigitoVerificadorCPF(self):
        if len(self.cpf_base) != 9 or not self.cpf_base.isdigit():
            return "CPF base deve ter 9 dígitos numéricos."

        pesos_primeiro_digito = [10, 9, 8, 7, 6, 5, 4, 3, 2]
        soma = Documento.multiplicacao(self.cpf_base, pesos_primeiro_digito)
        primeiro_digito = 11 - (soma % 11)
        if primeiro_digito >= 10:
            primeiro_digito = 0

        cpf_com_primeiro_digito = self.cpf_base + str(primeiro_digito)

        pesos_segundo_digito = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2]
        soma = Documento.multiplicacao(cpf_com_primeiro_digito, pesos_segundo_digito)
        segundo_digito = 11 - (soma % 11)
        if segundo_digito >= 10:
            segundo_digito = 0

        return cpf_com_primeiro_digito + str(segundo_digito)

    def GetNumeroCompletoCPF(self):
        cpf_completo = self.CalcularDigitoVerificadorCPF()
        return cpf_completo

    @staticmethod
    def ValidarCPF(cpf_completo):
        cpf_sem_formatacao = ''.join(filter(str.isdigit, cpf_completo))

        if len(cpf_sem_formatacao) != 11 or not cpf_sem_formatacao.isdigit():
            return False

        cpf_base = cpf_sem_formatacao[:9]
        cpf_calculado = CPF(cpf_base).CalcularDigitoVerificadorCPF()

        if cpf_calculado != cpf_sem_formatacao:
            return False

        return True


class CNPJ:
    def __init__(self, cnpj_base):
        if len(cnpj_base) < 12:
            cnpj_base = cnpj_base.zfill(12)
        self.cnpj_base = cnpj_base

    def CalcularDigitoVerificadorCNPJ(self):
        if len(self.cnpj_base) != 12 or not self.cnpj_base.isdigit():
            return "CNPJ base deve ter 12 dígitos numéricos."

        pesos_primeiro_digito = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
        soma = Documento.multiplicacao(self.cnpj_base, pesos_primeiro_digito)
        primeiro_digito = 11 - (soma % 11)
        if primeiro_digito >= 10:
            primeiro_digito = 0

        cnpj_com_primeiro_digito = self.cnpj_base + str(primeiro_digito)

        pesos_segundo_digito = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
        soma = Documento.multiplicacao(cnpj_com_primeiro_digito, pesos_segundo_digito)
        segundo_digito = 11 - (soma % 11)
        if segundo_digito >= 10:
            segundo_digito = 0

        return cnpj_com_primeiro_digito + str(segundo_digito)

    def GetNumeroCompletoCNPJ(self):
        cnpj_completo = self.CalcularDigitoVerificadorCNPJ()
        return cnpj_completo

    @staticmethod
    def ValidarCNPJ(cnpj_completo):
        cnpj_sem_formatacao = ''.join(filter(str.isdigit, cnpj_completo))

        if len(cnpj_sem_formatacao) != 14 or not cnpj_sem_formatacao.isdigit():
            return False

        cnpj_base = cnpj_sem_formatacao[:12]
        cnpj_calculado = CNPJ(cnpj_base).CalcularDigitoVerificadorCNPJ()

        if cnpj_calculado != cnpj_sem_formatacao:
            return False

        return True
    
    
class PIS:
    def __init__(self, pis_base):
        self.pis_base = pis_base
        if len(pis_base) < 10:
            pis_base = pis_base.zfill(10)
        self.pis_base = pis_base

    def CalcularDigitoVerificadorPIS(self):
        if len(self.pis_base) != 10:
            raise ValueError("O número do PIS deve conter 10 dígitos.")

        peso = [3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
        soma = Documento.multiplicacao(self.pis_base, peso)
        result = 11 - (soma % 11)
        return 0 if result in (10, 11) else result

    def GetNumeroCompletoPIS(self):
        PIS_completo = self.pis_base + str(self.CalcularDigitoVerificadorPIS())
        return PIS_completo

    @staticmethod
    def ValidarPIS(pis_completo):
        pis_sem_formatacao = ''.join(filter(str.isdigit, pis_completo))

        if len(pis_sem_formatacao) != 11 or not pis_sem_formatacao.isdigit():
            return False

        pis_base = pis_sem_formatacao[:10]
        pis_calculado = PIS(pis_base).CalcularDigitoVerificadorPIS()

        if pis_calculado != int(pis_sem_formatacao[-1]):
            return False

        return True


class InscricaoEstadualPR:
    def __init__(self, IE_base):
        self.IE_base = IE_base
        if len(IE_base) < 8:
            self.IE_base = IE_base.zfill(8)

    def CalcularDigitoVerificadorIE(self):
        peso_primeiro_digito = [3, 2, 7, 6, 5, 4, 3, 2]
        soma_primeiro_digito = Documento.multiplicacao(self.IE_base, peso_primeiro_digito)
        primeiro_digito = 11 - (soma_primeiro_digito % 11)
        primeiro_digito = 0 if primeiro_digito >= 10 else primeiro_digito

        inscricao_com_primeiro_digito = self.IE_base + str(primeiro_digito)

        peso_segundo_digito = [4, 3, 2, 7, 6, 5, 4, 3, 2]
        soma_segundo_digito = Documento.multiplicacao(inscricao_com_primeiro_digito, peso_segundo_digito)
        segundo_digito = 11 - (soma_segundo_digito % 11)
        segundo_digito = 0 if segundo_digito >= 10 else segundo_digito

        return inscricao_com_primeiro_digito + str(segundo_digito)

    def GetNumeroCompletoIE(self):
        IE_completo = self.CalcularDigitoVerificadorIE()
        return IE_completo

    @staticmethod
    def ValidarIE(ie_completa):
        ie_sem_formatacao = ''.join(filter(str.isdigit, ie_completa))

        if len(ie_sem_formatacao) != 10 or not ie_sem_formatacao.isdigit():
            return False

        ie_base = ie_sem_formatacao[:8]
        ie_calculada = InscricaoEstadualPR(ie_base).CalcularDigitoVerificadorIE()

        if ie_calculada != ie_sem_formatacao:
            return False

        return True


class TituloEleitoralPR:
    def __init__(self, te_base):
        if len(te_base) < 10:
            te_base = te_base.zfill(10)
        self.te_base = te_base

    def CalcularDigitoVerificadorTE(self):
        peso1 = [2, 3, 4, 5, 6, 7, 8, 9]
        soma_primeiro_digito = Documento.multiplicacao(self.te_base[:8], peso1)
        resto_primeiro_digito = soma_primeiro_digito % 11
        primeiro_digito = 0 if resto_primeiro_digito == 10 else resto_primeiro_digito

        digito1UF = self.te_base[8]
        digito2UF = self.te_base[9]

        peso2 = [7, 8, 9]
        soma_segundo_digito = Documento.multiplicacao(f"{digito1UF}{digito2UF}{primeiro_digito}", peso2)
        resto_segundo_digito = soma_segundo_digito % 11
        segundo_digito = 0 if resto_segundo_digito == 10 else resto_segundo_digito

        return f"{self.te_base}{primeiro_digito}{segundo_digito}"

    def GetNumeroCompletoTE(self):
        TE_completo = self.CalcularDigitoVerificadorTE()
        return TE_completo

    @staticmethod
    def ValidarTE(te_completa):
        te_sem_formatacao = ''.join(filter(str.isdigit, te_completa))

        if len(te_sem_formatacao) != 12 or not te_sem_formatacao.isdigit():
            return False

        te_base = te_sem_formatacao[:10]
        te_calculada = TituloEleitoralPR(te_base).CalcularDigitoVerificadorTE()

        if te_calculada != te_sem_formatacao:
            return False

        return True
