# myfinance-web-netcore
MyFinance - Projeto do Curso de Pós-Graduação em Engenharia de Software da PUC-MG

## Modelagem

    A figura abaixo representa a modelagem lógica da aplicação e Diagrama de Entidades e Relacionamentos.   

<img src="docs\DER.jpeg" alt="diagram">

## Padrão de Arquitetura

Foi utilizado o padrão de arquitetura MVC, que separa a aplicação em três camadas (Model - View - Controller).

Model: É responsável por gerenciar e controlar a forma como os dados se comportam por meio das funções, lógica e regras de negócios estabelecidas. 

View: Essa camada é responsável por apresentar as informações de forma visual ao usuário, montando sua interface gráfica.

Controller: A camada de controle é responsável por intermediar as requisições enviadas pelo View com as respostas fornecidas pelo Model.

<img src="docs\MVC.jpg" alt="MVC">

### Requisitos para executar a aplicação MyFinance

* Versão mais recente do Visual Studio Code

* Extensão do C# para Visual Studio Code -.NET Core SDK 6.0, o qual pode ser obtido através do <a href="https://dotnet.microsoft.com/en-us/download">Link</a>

* Última versão do Git, a qual pode ser adquirida por meio do <a href="https://git-scm.com/downloads">Link</a>

* Última versão do C# extensions, o qual deve ser instalado no Visual Studio Code

* SQL Server 2019

## Como executar?

Acesse o reposítório através do <a href="https://github.com/JonathanBrant/myfinance-web-netcore">Link</a>

Clique em Code e copie o link.

<img src="docs\telaGit.JPG" alt="telaGit">

Em sua máquina, clique com botão direito nas pasta que deseja armazenar o projeto e clique em Git Bash Here.

Digite o comando "git clone + link copiado do projeto no github"

<img src="docs\gitClone.png" alt="GitClone">

<img src="docs\gitClone2.jpg" alt="GitClone">

Ao abrir a pasta com o projeto, abra um terminal e digite **cd myfinance-web-netcore**

<img src="docs\terminal.jpg" alt="Terminal">

Para compilar o projeto, execute o comando **dotnet build**

<img src="docs\build.jpg" alt="Comando Build">

Para executar o projeto, execute o comando **dotnet run**

Clique **ctrl + botão esquerdo** sobre a URL do projeto

<img src="docs\run.jpg" alt="Comando Run">

## Tela inicial do projeto

<img src="docs\index.jpg" alt="Página inicial">

No header, temos as opções Transações e Plano de Contas.

Em Planos de Conta, temos registrados alguns tipos de despesas ou receitas para ser identificado através de ID's na tabela de Transções. A tabela conta com as opções de Editar e Excluir um plano de conta.

<img src="docs\planoConta.jpg" alt="Plano de Contas">

<img src="docs\novoPlano.jpg" alt="Registrar novo plano de contas">

Em Transações, temos uma listagem com as transações registradas pelo usuário. A tabela conta com as opções de Editar e Excluir transações.

<img src="docs\transacao.jpg" alt="Transação">

Ao clicar em Registrar Transação, o usuário será encaminhado para um formulário para registro de novas transações.

<img src="docs\novaTransacao.jpg" alt="Registrar Nova Transação">

## Feature Extra

Este projeto conta com uma feature extra, que tem como objetivo permitir que o usuário registre como uma despesa foi paga.

Caso o usuário escolha registrar uma **receita**, o menu de tipo de pagamento ficará oculto.

<img src="docs\featureReceita.jpg" alt="Novo requisito">

Caso o usuário escolha registrar uma **despesa**, um novo menu de opções de pagamento deve aparecer na tela. Esta listagem de opções foi registrado no DB e vinculada a tabela de transações.

<img src="docs\featureDespesa.jpg" alt="Novo Requisito">

<img src="docs\registros.jpg" alt="Transações criadas">















