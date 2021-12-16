<h1 align="center">
  Desafio <img alt="Comuniki.me" title=".github/ComunikiMe.png" width="220px" />
</h1>

A ideia do desafio é desenvolver uma API para o controle do estoque e venda de uma loja de produtos diversos.
Para interface do usuário, é necessário que haja ao menos duas telas: uma para o cadastro dos produtos e uma para a venda.

## 💻 Desenvolvimento:
No Backend foi utilizado C#, ASP.NET e EFCore integrando com o SQLServer para a criação da API, já no Frontend foi utilizado o React.js para a criação das telas.

## 🚀 Como executar?
(Desejável utilizar Visual Studio 2019)
Na API apague a pasta Migrations e mude o parâmetro "DefaultConnection" em appsettings.json apontando para a sua conexão local do SQLServer. Após isso rode no terminal da solução: 
- Add-Migation InitialCreate
- Update-Database
Assim um novo banco de dados será criado em seu computador, armazenando cada produto que você cadastrar.
Rode a .sln, os métodos estão documentados no Swagger.

(Desejável utilizar Visual Studio Code)
No web é necessário rodar o seguinte comando no terminal:
- yarn install (para baixar os modules da aplicação)
Após isso, rode também no terminal:
- yarn start

A aplicação está dividida em duas telas:
- Cadastro de produtos, rota = /dashboard
- Listagem e compra de produtos, rota = /store 