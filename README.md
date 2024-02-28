Projeto feito com base nas seguintes especificações:

Exercício 1: Calculador de dígitos verificadores de
documentos – C#

Crie um conjunto de classes capazes de calcular os dígitos verificadores de documentos.
As classes devem receber os números de documentos SEM os dígitos verificadores e de alguma
forma permitir a consulta do número do documento completo, com ou sem formatação.
Os documentos suportados e as respectivas instruções de como realizar o cálculo são:

• Inscrição estadual do Paraná: https://www.fazenda.pr.gov.br/Pagina/calculo-digitoverificador
• CPF e CNPJ: http://cpfgenerator.com.br/calculo-cpf.html e/ou
http://www.cadcobol.com.br/calcula_cpf_cnpj_caepf.htm
• PIS: https://www.macoratti.net/alg_pis.htm
• Título de eleitor: http://clubes.obmep.org.br/blog/a-matematica-nos-documentos-titulo-deeleitor/
Todos os documentos devem ter validação de tamanho máximo, com preenchimento de zeros à
esquerda sempre que necessário.

Os números dos documentos devem ser informados à classe em seu construtor e deve ser possível
obter da classe a versão completa do número do documento, seja apenas com os dígitos ou a versão
formatada (com traços, espaços e/ou quaisquer outros sinais de pontuação de acordo com o
documento validado).

Deve ser possível também usar as classes informando o documento completo (com os dígitos
verificadores). Neste caso, a classe deve validar o documento informado e indicar eventuais
problemas de validação.

Pondere cuidadosamente a representação e interação da classe com os demais componentes do
sistema para otimizar ao máximo o consumo de CPU.

Todo o código deve ser projetado para uso no backend, portanto nada de exibir textos na tela dentro
do código das classes! Um código bem feito é testado e validado pelos testes unitários!

A implementação deve zelar pela eficiência e manutenibilidade, portanto tente seguir as seguintes
recomendações:

• Use as melhores práticas de orientação a objetos (S.O.L.I.D.);
• A implementação deve ter pelo menos 6 classes;
• Uma boa implementação só terá UMA operação de multiplicação em todo o código;
• Planeje MUITO BEM as entradas e saídas de cada método;
• Use nomes adequados para todos os elementos (especialmente as classes) e arquivos.
Metade do problema se resolve usando a abstração correta!
• Para ter a nota máxima, além dos demais itens os testes unitários devem cobrir 100% do
código.
