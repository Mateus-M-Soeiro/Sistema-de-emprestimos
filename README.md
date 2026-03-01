# 🏦 Sistema de Empréstimos

API REST desenvolvida em .NET para gerenciamento de empréstimos entre usuários, com suporte a pagamento parcial e controle de status.

## 🚀 Tecnologias Utilizadas

- .NET 8

- ASP.NET Core Web API

- Entity Framework Core

- SQL Server

- Migrations

- Arquitetura em Camadas (Controller + Service)

## Funcionalidades

-  Registro de empréstimo

- Validação de regras de negócio

- Pagamento total

- Pagamento parcial

- Controle automático de status (Ativo / Pago)

- Cálculo de valor restante

- Tratamento de erros via Enum de resultado

## Regras de Negócio Implementadas

- Credor e devedor devem ser diferentes

- Valor do empréstimo deve ser maior que zero

- Data limite deve ser futura

- Não é possível pagar empréstimo já quitado

- Não é permitido pagar valor maior que o restante da dívida

## 🏗 Arquitetura

O projeto utiliza separação de responsabilidades:

Controller: responsável apenas por HTTP

Service: centraliza regras de negócio

DTOs: isolamento de modelo de domínio

Entity: representação do banco

## 🔄 Fluxo de Pagamento Parcial

- Incrementa ValorPago

- Calcula ValorRestante

- Quando ValorPago == ValorOriginal:

- Status muda para Pago

-  Campo PagoEm é preenchido

## 🛠 Como executar o projeto

```
git clone https://github.com/Mateus-M-Soeiro/Sistema-de-emprestimos.git
cd SistemaDeEmprestimo
dotnet restore
dotnet ef database update
dotnet run
```