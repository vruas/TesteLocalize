

---

````markdown
# 📦 LocalizaEmpresas API

API para cadastro, consulta e autenticação de empresas e usuários, com integração à ReceitaWS.

---

## ✅ Pré-requisitos

Certifique-se de ter instalado em sua máquina:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [Postman](https://www.postman.com/) (recomendado para testes)

---

## 🚀 Como rodar o projeto

1. **Clone o repositório**

```bash
git clone https://github.com/vruas/TesteLocalize.git
cd LocalizaEmpresas
````

2. **Configure a `connection string` no `appsettings.json`**

```json
Ex:
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=LocalizaEmpresasDb;user=root;password=sua_senha"
}
```

3. **Crie o banco de dados**

Crie o banco manualmente ou rode:

```bash
dotnet ef database update --project LocalizaEmpresas
```

4. **Rode a aplicação**

```bash
dotnet run --project LocalizaEmpresas
```

A API será iniciada em:

```
Ex: 
    https://localhost:5001
    ou
    http://localhost:5000
```

---

## 📚 Acessar a documentação Swagger

Abra no navegador:

```
Ex: https://localhost:5001/swagger
```

Você poderá:

* Explorar os endpoints
* Ver exemplos de requisições/respostas
* Testar diretamente no navegador

---

## 🔐 Testar endpoints protegidos com JWT

### 1. Cadastrar um usuário

```
POST /usuario/cadastro
```

```json
{
    "UserName": "Vitor",
    "Email": "vetoor@email.com",
    "Password": "SenhaSegura123@",
    "ConfirmPassword": "SenhaSegura123@"
}
```

### 2. Fazer login

```
POST /usuario/login
```

```json
{
  "username": "Vitor",
  "senha": "SenhaSegura123@"
}
```

Você receberá um `token JWT`.

### 3. Autenticar no Swagger

Clique em **Authorize** no Swagger e insira:

```
Bearer SEU_TOKEN_AQUI
```

Agora os endpoints com `[Authorize]` estarão liberados.

---

## 📬 Testando a API no Postman

### 🔸 Passo 1: Criar uma nova requisição

* **Método:** `POST`
* **URL:** `https://localhost:5001/usuario/login`
* **Body (raw, JSON):**

```json
{
  "username": "Vitor",
  "senha": "SenhaSegura123@"
}
```

### 🔸 Passo 2: Copiar o token JWT da resposta

Copie apenas o token (sem `Bearer`).

### 🔸 Passo 3: Adicionar o token no cabeçalho das requisições protegidas

* Vá na aba **Headers**
* Adicione:

```
Key: Authorization
Value: Bearer SEU_TOKEN_AQUI
```

Agora você pode acessar endpoints como:

* `GET /empresa`
* `POST /empresa`
* `GET /acesso`

### 🔸 Dica: Use coleções

Você pode salvar os endpoints em uma **coleção Postman**, facilitando os testes e reuso do token.

---

## 🛠️ Principais Endpoints

### Usuário

| Verbo | Rota                      | Descrição                |
| ----- | ------------------------- | ------------------------ |
| POST  | `/usuario/cadastro`       | Cadastro de novo usuário |
| POST  | `/usuario/login`          | Login do usuário         |
| GET   | `/usuario/listarUsuarios` | Lista todos os usuários  |

### Empresa

| Verbo | Rota                   | Descrição                             |
| ----- | ---------------------- | ------------------------------------- |
| POST  | `/empresa`             | Cadastra empresa via CNPJ (ReceitaWS) |
| GET   | `/empresa`             | Lista empresas do usuário autenticado |
| GET   | `/empresa/{idUsuario}` | Lista empresas por ID de usuário      |

### Acesso

| Verbo | Rota      | Descrição                    |
| ----- | --------- | ---------------------------- |
| GET   | `/acesso` | Testa se o token está válido |

---

## ✍️ Autor

* Vitor Ruas
* [LinkedIn](https://www.linkedin.com/in/vitorsruas/) | [GitHub](https://github.com/vruas)

---
