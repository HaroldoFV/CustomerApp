# Sistema de Cadastro de Clientes

Este projeto é um **Sistema para Cadastro de Clientes**, desenvolvido utilizando **.NET 8**, seguindo os princípios de 
**Domain-Driven Design (DDD)** e **CQRS**. O sistema foi containerizado utilizando **Docker**, e o banco de dados
utilizado é o **Postgres**

## Tecnologias/Técnicas Utilizadas

- **.NET 8**
- **Domain-Driven Design (DDD)**
- **CQRS**
- **Postgres**
- **Docker**
- **Angular 11**: Framework de desenvolvimento para a criação de aplicações web frontend.

## Estrutura do Projeto(backend)

A aplicação segue **CQRS**, separando claramente as responsabilidades em camadas, permitindo maior flexibilidade e
facilidade de manutenção. A estrutura básica do projeto é a seguinte:

- **Domain**: Contém as entidades e objetos de valor, que representam o núcleo do domínio da aplicação.
- **Application**: Contém os comandos e queries.
- **Infrastructure**: Implementa a persistência de dados (com repositórios para o Postgres), integração com serviços
  externos, etc.
- **Presentation**: Contém as APIs ou interfaces de usuário.
- **Tests**: será implementado.

### Como rodar o projeto com Docker

1. Certifique-se de ter o **Docker** instalado.
2. Clone o repositório do projeto para sua máquina local.
3. Navegue até a pasta raiz do projeto, onde está localizado o arquivo `docker-compose.yml`.
4. Execute o seguinte comando para construir e iniciar os contêineres do serviço, do banco de dados e do frontend:

    ```bash
    docker-compose up --build
    ```

4. Após a inicialização dos containers, a aplicação(frontend, backend) estará acessível através do navegador
   ou cliente de API no seguinte endereços respectivamente:

    ```
    http://localhost:4200
    http://localhost:8080/swagger/index.html
    ```