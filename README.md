# Projeto R.O.B.O. (Robô Operacional Binariamente Orientado)

![image](https://github.com/phdguigui/robo-becomex/assets/90238683/99278745-edf1-4b2d-ba6e-0678ef539d92)


Bem-vindo ao repositório do projeto R.O.B.O. Este projeto consiste em uma interface para controlar e visualizar os estados atuais do Robô Operacional Binariamente Orientado através de uma API Web Restful. O backend foi desenvolvido em C# e o frontend em Vue.js. Além disso é possível manipular e observar os estados do robô através de API.

## Visão Geral

O objetivo deste projeto é fornecer uma interface gráfica, e uma API para visualizar os estados atuais do R.O.B.O. e enviar comandos para controlá-lo. O projeto é composto por duas partes principais:
1. **Backend**: Uma API Web Restful desenvolvida em C#.
2. **Frontend**: Uma interface gráfica desenvolvida em Vue.js.

## Estrutura do Projeto

- `/R.O.B.O.`: Contém o código-fonte da API Web Restful em C#.
- `/robo-front`: Contém o código-fonte da aplicação Vue.js.

## Requisitos

### Backend

- Visual Studio 17.10.0
- Carga de Trabalho do ASP.NET instalada no Visual Studio
![image](https://github.com/phdguigui/robo-becomex/assets/90238683/22ba4efb-c414-4e08-888d-2b144c7dc8c9)
- .NET Core 8.0 ou superior

### Frontend

- Node 16.0.0 ou superior

## Configuração do Ambiente

### Backend

1. Clone ou baixe o repositório
   
2. Navegue até o diretório do backend:
   
![image](https://github.com/phdguigui/robo-becomex/assets/90238683/85a6a16f-879f-4a20-8eec-c7d92e501dcd)

3. Abra a Solução R.O.B.O..sln no Visual Studio:
   
![image](https://github.com/phdguigui/robo-becomex/assets/90238683/9ce07c88-b519-4451-ab2a-ca8a55d7f627)

4. Com o projeto aberto no Visual Studio, compile-o:
   
![image](https://github.com/phdguigui/robo-becomex/assets/90238683/b611d99c-521b-47b7-b946-e891c728df65)

5. Feita a compilação, basta executar:
   
![image](https://github.com/phdguigui/robo-becomex/assets/90238683/6ae1c8a0-756a-4bc4-ae2c-334f84f779d8)

A API estará disponível em `https://localhost:7237/`.

O Swagger com todos os endpoint disponíveis estará disponível em `https://localhost:7237/swagger/index.html`
![image](https://github.com/phdguigui/robo-becomex/assets/90238683/69afd37e-8a47-439c-9f12-fcc8a8f2694c)

### Frontend

1. Abrir a pasta robo-front no Visual Studio Code:
![image](https://github.com/phdguigui/robo-becomex/assets/90238683/57eba996-6759-4a01-85e3-13e0aa7d3924)

2. Instale as dependências do projeto:
    ```bash
    npm install
    npm install -g @quasar/cli
    ```
Lembrando da necessidade do Node 16.0.0 ou superior na máquina para que tudo funcione conforme o esperado.

3. Inicie a aplicação Quasar/Vue.js:
    ```bash
    quasar dev
    ```
A aplicação estará disponível em `http://localhost:9000/`.

## Funcionalidades

- **Visualização de Estado**: Permite visualizar o estado atual do R.O.B.O. na interface gráfica e via API.
- **Envio de Comandos**: Permite enviar comandos ao R.O.B.O. através da interface e via API.

## Testes Unitários

Na solução disponibilizada, juntamente com o projeto ASP.NET existe também um projeto de testes MSTest, responsável pelos testes unitários dos métodos desenvolvidos para o robô, tanto para busca de informações quanto para manipulação do robô.

Além do projeto de teste MSTest nativo da Microsoft, foi utilizado também o pacote FluentAssertions, para garantir o funcionamento e retorno correto dos métodos do projeto.

![image](https://github.com/phdguigui/robo-becomex/assets/90238683/76f36515-e011-4f5d-918a-d7719f95131e)

## Contato

Se você tiver alguma dúvida ou sugestão, sinta-se à vontade para entrar em contato.

[E-Mail](guiricardo@.live.com)

---

Desenvolvido por [Guilherme Siedschlag](https://github.com/phdguigui).
