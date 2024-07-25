# Projeto de Autenticação e Integração com Asaas

Este projeto é um teste técnico que inclui autenticação e autorização usando Blazor, integração com o Asaas para gerar e receber pagamentos via webhook, e funcionalidades de cadastro e login.

## Funcionalidades

- **Cadastro de Usuários**: Permite o cadastro de novos usuários no sistema.
- **Login**: Permite que usuários façam login no sistema.
- **Usuário Admin/Cliente**: Diferencia entre permissões de usuário administrador e cliente.
- **Criação de Cobranças**: Cria cobranças no Asaas passando os dados do cliente, com prioridade para cobranças recorrentes.
- **Detecção de Pagamentos**: Detecta quando uma cobrança é paga através de um webhook.

## Pré-requisitos

- .NET 6.0 SDK ou superior
- Visual Studio 2022 ou superior
- Conta no Asaas (para integração com a API)
- Conhecimento básico de Blazor e Entity Framework Core

## Configuração

2. **Configure o Asaas**:
    - Obtenha sua chave de API do Asaas.
    - Utilize os Secrets do Visual Studio para armazenar a chave de API de forma segura.
    - No terminal do Visual Studio, execute o seguinte comando para adicionar a chave de API aos Secrets:

    ```sh
    dotnet user-secrets init
    dotnet user-secrets set "Asaas:ApiKey" "SUA_CHAVE_DE_API"
    ```

2. **Configure a string de conexão do banco de dados**:
    - Atualize o `appsettings.json` com sua string de conexão do banco de dados.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=.;Database=SeuBancoDeDados;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
    ```
3. **Atualize seu Banco de dados com o entity framework**:
    - Update-database no console do gerenciador de pacotes


## Uso

1. **Cadastro e Login**:
    - Acesse a aplicação e cadastre um novo usuário.
    - Faça login com as credenciais cadastradas.

2. **Criação de Cobranças**:
    - Faça login como usuário administrador com o email `felipeteste@gmail.com` e a senha `Pa$$w0rd`.
    - Acesse a página de criação de cobranças e preencha os dados necessários para gerar uma cobrança no Asaas.

3. **Webhooks**:
    - Configure a URL de webhook no Asaas para apontar para sua aplicação.
    - A aplicação irá detectar automaticamente quando um pagamento for realizado.


