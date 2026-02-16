# Product Management System – QA-Focused Portfolio Project

# Visão Geral

Este projeto foi desenvolvido com foco explícito em Quality Assurance (QA), utilizando uma aplicação ASP.NET Core MVC como base para validar regras de negócio, estruturar cenários de teste e aplicar análise crítica ao comportamento do sistema.

Mais do que implementar funcionalidades, o objetivo foi criar uma aplicação que permita:

* Testar fluxos completos de autenticação e autorização
* Validar estados de utilizadores (Pending / Active)
* Verificar persistência real de dados
* Documentar testes e evoluir o sistema com base em resultados obtidos

O sistema implementa registo de utilizadores com aprovação administrativa e gestão de produtos com rastreabilidade de alterações.



##  Objetivos do Projeto

Este projeto foi construído para demonstrar:

* Capacidade de análise de requisitos e regras de negócio
* Estruturação de testes funcionais manuais
* Identificação de cenários positivos e negativos
* Validação de controlo de acesso por perfil
* Aplicação de melhorias com base em testes
* Evolução incremental com controlo de versão (Git)

O foco principal é consolidar os conhecimentos de Quality Assurance.



##  Stack Técnica

* ASP.NET Core MVC (.NET 7)
* Entity Framework Core (Code First)
* SQL Server Express
* Autenticação baseada em sessão
* Autorização por role (Admin / User)
* Migrations para controlo da base de dados

Estrutura do projeto:

* Controllers
* Models
* Services
* Data (DbContext)
* Views


##  Funcionalidades Implementadas

###  Gestão de Utilizadores

* Registo de novo utilizador (Status inicial: Pending)
* Aprovação manual pelo Administrador
* Login condicionado ao estado do utilizador
* Bloqueio de acesso à área administrativa para utilizadores comuns
* Controlo de sessão

###  Gestão de Produtos

* Criar produto
* Editar produto
* Desativar produto
* Persistência em base de dados
* Registo do último utilizador que modificou o produto



##  Persistência de Dados

A aplicação utiliza SQL Server Express com Entity Framework Core (Code First).

O banco é criado e versionado através de migrations:

Add-Migration InitialCreate
Update-Database

Os dados permanecem após reinício da aplicação, permitindo testes reais de persistência.


##  Estratégia de Testes

O projeto foi estruturado para permitir execução e documentação de testes.

##  Abordagem de Qualidade

O projeto é analisado sob os seguintes critérios:

* Consistência de dados
* Clareza de mensagens de erro
* Validação de regras de negócio
* Integridade de estados (Pending / Active)
* Controlo de permissões

As melhorias são implementadas com base em falhas identificadas durante testes manuais.



##  Próximas Evoluções Planeadas

* Implementação de testes unitários (xUnit)
* Testes de integração
* Automatização básica de cenários críticos
* Implementação de hash de password
* Registo de data/hora de alterações
* Melhoria de validação de inputs

Todos os testes e documentação serão disponibilizados em um ficheiro.

##  Motivação

Este projeto foi desenvolvido como parte de consolidação de competências técnicas com foco em transição e crescimento na área de Quality Assurance.
