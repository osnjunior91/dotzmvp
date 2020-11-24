# Dotz MVP - Web Api


O projeto a seguir tem como objetivo simular uma api responsável pela troca de pontos, em produtos diversos:

Para esse fluxo foram construídos alguns endpoints com operações básicas para essas rotinas, são elas:
 - Cadastrar usuarios comuns.
 - Cadastrar usuarios com privilegios administrativos.
 - Cadastrar produtos para troca.
 - Efetuar Login
 Entre Outras.

Para utilziar o sistemas basta seguir os passos descritos.

## Baixar o codigo fonte

Basta clonar o repositório normalmente pelo GitHub, ou como arquivo .zip.

## Rodar os migrations
Após baixar os códigos fontes deve se executar os migrations, esses arquivos irão criar as tabelas no banco que você informou na string de conexão.

Selecione o projeto

**DotzMVP.Lib**

Execute os seguintes comandos:

    Add-Migration InitialCreate
    
    update-database

Pronto agora sua base já está com todas as tabelas necessárias.

## Inserindo dados

Para utilizar o sistema basta criar usuários adm e comuns e ao menos um cliente, para isso execute o projeto e utilize o swagger para esse trabalho.
Alguns endpoints necessitam de autenticação para funcionarem, para se autenticar basta executar o login com algum usuário que você tenha criado, pegar o token e inseri-lo na página do swagger.

E pronto...

