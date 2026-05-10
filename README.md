# Sistema de Gerenciamento de Endereços

Aplicação web desenvolvida em ASP.NET MVC para autenticação de usuários e gerenciamento de endereços, com integração à API ViaCEP e exportação de dados em CSV.

---

## Tecnologias Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server / LocalDB
- Bootstrap 5
- JavaScript
- ViaCEP API

---

## Funcionalidades

### Autenticação
- Login de usuários
- Validação de credenciais
- Controle de sessão
- Logout

### Gerenciamento de Endereços
- Cadastro de endereços
- Listagem de endereços
- Edição de endereços
- Exclusão de endereços

### Integrações
- Busca automática de endereço via CEP utilizando ViaCEP
- Exportação de endereços para arquivo CSV

---

## Estrutura do Banco de Dados

### Tabela Usuarios
- Id
- Nome
- Usuario
- Senha

### Tabela Enderecos
- Id
- Cep
- Logradouro
- Complemento
- Bairro
- Cidade
- Uf
- Numero
- UsuarioId

---

## Como Executar o Projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/JuanDias22/CepGestao.git
```

### 2. Abrir o projeto no Visual Studio

### 3. Restaurar os pacotes NuGet

### 4. Executar as migrations

```powershell
Update-Database
```

### 5. Executar o projeto

---

## Observações

- O projeto utiliza Entity Framework Core para gerenciamento do banco de dados.
- O campo Complemento é opcional.
- A integração com ViaCEP é realizada diretamente no frontend utilizando JavaScript e Fetch API.

---

Pré-visualização

https://github.com/user-attachments/assets/77c15274-86a7-413f-a351-2b11b85ae419

---

## Autor
Juan Dias
