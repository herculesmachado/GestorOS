# 🛠️ GestorOS — Sistema de Gestão de Ordens de Serviço

![.NET](https://img.shields.io/badge/.NET-ASP.NET%20Core-512BD4?logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?logo=postgresql&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity%20Framework-Core-6C3EB8)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?logo=bootstrap&logoColor=white)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)

Aplicação web para gerenciamento de clientes, categorias e ordens de serviço, desenvolvida com **ASP.NET Core**, **Entity Framework Core** e **PostgreSQL**, com interface responsiva em **Bootstrap**.

---

## 🎥 Demonstração

📹 **Vídeo mostrando as funcionalidades:** [Assistir ao vídeo](https://drive.google.com/file/d/1KRFeFc_tNIPcad0CaLMSn-UDizShXHBw/view?usp=drive_link)

---

## 📸 Screenshots

| Listagem de clientes | Cadastro de cliente |
|:---:|:---:|
<img width="1920" height="644" alt="image" src="https://github.com/user-attachments/assets/750ecb6f-8fdc-4213-baf8-2eec6e65e8cf" />
<img width="1920" height="715" alt="image" src="https://github.com/user-attachments/assets/b57bfa89-31f7-4a6c-ac79-cb02b9faacdc" />




| Listagem de categorias | Cadastro de categoria |
|:---:|:---:|
<img width="1920" height="635" alt="image" src="https://github.com/user-attachments/assets/792e07b5-8b27-4762-99ec-9ec9f41753b0" />
<img width="1920" height="743" alt="image" src="https://github.com/user-attachments/assets/197eae5b-8486-445b-ae59-057c36bb2708" />



---

## ✅ Status do projeto

| Módulo | Status |
|---|:---:|
| Clientes (CRUD completo) | ✅ Concluído |
| Categorias (CRUD completo) | ✅ Concluído |
| Ordens de Serviço | 🚧 Em desenvolvimento (entidade `OrdemServico` e enum `StatusOrdem` já modelados) |
| Home / Dashboard | 🚧 Planejado |

---

## ✨ Funcionalidades

### Clientes
- Cadastro, listagem, edição, detalhes e exclusão
- Validação de dados no formulário (client-side e server-side)
- Interface responsiva com Bootstrap

### Categorias
- Cadastro, listagem, edição, detalhes e exclusão
- Organização das categorias que serão usadas nas ordens de serviço

---

## 🧰 Tecnologias

- **Back-end:** C#, ASP.NET Core
- **ORM:** Entity Framework Core (Code First + Migrations)
- **Banco de dados:** PostgreSQL (provider Npgsql)
- **Front-end:** Razor Views, HTML, CSS, Bootstrap
- **Versionamento:** Git e GitHub

---

## 🏗️ Arquitetura

O projeto segue o padrão **MVC** do ASP.NET Core:

```
📦 GestorOS
 ┣ 📂 Controllers
 ┃ ┣ 📄 CategoriaServicoController.cs
 ┃ ┣ 📄 ClienteController.cs
 ┃ ┗ 📄 HomeController.cs
 ┣ 📂 Models
 ┃ ┣ 📄 Cliente.cs
 ┃ ┣ 📄 CategoriaServicos.cs
 ┃ ┣ 📄 OrdemServico.cs
 ┃ ┣ 📄 StatusOrdem.cs
 ┃ ┗ 📄 ErrorViewModel.cs
 ┣ 📂 Data
 ┃ ┗ 📄 ApplicationDbContext.cs      → DbContext do EF Core
 ┣ 📂 Helpers
 ┃ ┗ 📄 StatusExtensions.cs          → extensões para o status da OS
 ┣ 📂 Migrations                     → histórico de alterações do banco
 ┣ 📂 Views
 ┃ ┣ 📂 CategoriaServico
 ┃ ┣ 📂 Cliente
 ┃ ┣ 📂 Home
 ┃ ┗ 📂 Shared                       → layout e partials
 ┣ 📂 wwwroot                        → arquivos estáticos (css, js, imagens)
 ┣ 📄 appsettings.json               → configurações e connection string
 ┗ 📄 Program.cs                     → configuração da aplicação e injeção de dependência
```

---

## 🚀 Como executar

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (versão: `10`)
- [PostgreSQL](https://www.postgresql.org/download/) instalado e em execução
- Ferramenta do EF Core:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Passo a passo

```bash
# 1. Clone o repositório
git clone https://github.com/SEU_USUARIO/GestorOS.git
cd GestorOS

# 2. Configure a connection string (veja abaixo)

# 3. Aplique as migrations para criar o banco
dotnet ef database update

# 4. Execute a aplicação
dotnet run
```

### Connection string

No arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=nome_do_banco;Username=seu_usuario;Password=sua_senha"
  }
}
```

A aplicação ficará disponível em `https://localhost:5001` (ou na porta exibida no terminal).

---

## 🗺️ Roadmap

1. Finalizar o módulo de Ordens de Serviço com relacionamento entre cliente e categoria
2. Construir a Home com dashboard
3. Adicionar paginação, busca e filtros
4. Implementar autenticação
5. Escrever testes automatizados
6. Publicar a aplicação (deploy)

---

## 📚 Aprendizados

Este projeto está sendo usado para praticar:
- Modelagem de dados e relacionamentos com **EF Core**
- Uso de **migrations** para versionar o banco
- Padrão **MVC** e organização em camadas
- Integração entre **ASP.NET Core** e **PostgreSQL**
- Construção de interfaces responsivas com **Bootstrap**

---

## 👨‍💻 Autor

**Hércules de Jesus Machado Lima**

- Instagram: [@hercules.codes](https://instagram.com/hercules.codes)
- LinkedIn: [COLE_SEU_LINK](https://linkedin.com/in/SEU_PERFIL)
- GitHub: [SEU_USUARIO](https://github.com/SEU_USUARIO)
