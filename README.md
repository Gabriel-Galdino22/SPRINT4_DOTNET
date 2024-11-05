## 📖 Descrição do Projeto
A API ArgosNet é uma solução de gerenciamento de produtos e clientes, que utiliza inteligência artificial para recomendação de produtos e implementa práticas modernas de desenvolvimento, como testes automatizados, Clean Code e princípios SOLID. O projeto foi desenvolvido com foco em oferecer uma API robusta e eficiente para operações de CRUD (Create, Read, Update, Delete), autenticação segura e funcionalidades avançadas de IA.

🔍 A API ArgosNet integra ML.NET para implementar recomendações personalizadas de produtos, gerando sugestões relevantes com base em dados históricos e categorias de produtos. Além disso, todos os endpoints críticos estão protegidos por autenticação JWT, garantindo uma camada de segurança robusta.

## 🔑 Funcionalidades Principais
# 1. CRUD de Produtos e Clientes
  A API ArgosNet permite a criação, leitura, atualização e exclusão de produtos e clientes. Esses endpoints garantem a flexibilidade necessária para o gerenciamento completo de dados.

# 2. Autenticação JWT
  Para segurança dos dados, a API implementa autenticação JWT, exigindo que os usuários forneçam um token válido para acessar endpoints protegidos. A autenticação é realizada através do endpoint /api/Auth/login, que gera o token JWT para usuários autenticados.

# 3. Recomendação de Produtos com ML.NET
   Com a integração de ML.NET, a API gera recomendações personalizadas de produtos. Utilizando técnicas de filtragem colaborativa, o sistema analisa o histórico de produtos e categoriza as sugestões de acordo com a similaridade, oferecendo recomendações relevantes e personalizadas.

## 🌟 Exemplo Prático:
  Imagine que um cliente está navegando em uma loja online de eletrônicos e visualiza um smartphone. A API ArgosNet, com o modelo de recomendação, pode sugerir acessórios, como capinhas e fones de ouvido, que são populares entre outros compradores do mesmo produto. Esse sistema de recomendação ajuda a impulsionar as vendas e melhorar a experiência do usuário com sugestões adequadas ao contexto de compra.

## 🎯 Objetivo
  O objetivo da API ArgosNet é fornecer uma solução completa para o gerenciamento de produtos e clientes, com funcionalidades avançadas de recomendação de produtos e autenticação segura. A API oferece uma experiência de compra personalizada, agregando valor com sugestões relevantes e protegendo o acesso aos dados sensíveis.

## ⚙️ Requisitos Implementados
# 1. Integração com Serviço Externo
   A API utiliza autenticação JWT para proteger os endpoints. O serviço de autenticação gera tokens JWT para os usuários, que são obrigatórios para acessar os endpoints protegidos, garantindo uma camada extra de segurança.

## Implementação:

  Endpoint /api/Auth/login para geração de tokens JWT.
  Middleware que verifica a autenticidade dos tokens em todos os endpoints com [Authorize].

# 2. Testes com xUnit
  Foram implementados testes unitários e de integração com xUnit para garantir a confiabilidade e a precisão dos endpoints e serviços. O pacote Moq foi utilizado para simular dependências e testar a API sem precisar acessar o banco de dados real.

## Detalhes dos Testes:

  Testes Unitários: Validam métodos individuais, garantindo a integridade da lógica interna.
  Testes de Integração: Realizam validações de endpoints e fluxos completos, simulando requisições HTTP e verificando respostas.
  
# 3. Práticas de Clean Code e SOLID
  A API foi construída seguindo princípios de Clean Code e SOLID para assegurar que o código seja legível, escalável e de fácil manutenção.

## Práticas de Clean Code Aplicadas:

  Nomenclatura Descritiva: Métodos e classes possuem nomes que explicam claramente suas funções.
  Funções Simples e Concisas: Funções pequenas e de responsabilidade única.
  Comentários Esclarecedores: Documentação concisa onde necessário.


## Princípios SOLID:

  Single Responsibility Principle (SRP): Cada classe tem uma única responsabilidade.
  
  Open/Closed Principle (OCP): A API é projetada para ser extensível sem precisar modificar o código base.
  
  Liskov Substitution Principle (LSP): As classes derivadas substituem as classes base sem alterar o comportamento.
  
  Interface Segregation Principle (ISP): Interfaces específicas para cada serviço e repositório.
  
  Dependency Inversion Principle (DIP): Uso de injeção de dependência para promover o desacoplamento entre as classes.
  
# 4. Integração de ML.NET para IA Generativa
  A API integra ML.NET para gerar recomendações de produtos com base em dados históricos, proporcionando uma experiência de compra personalizada. O modelo de filtragem colaborativa é treinado para sugerir produtos relacionados, com base em categorias e avaliações.

## Funcionalidade de IA:
  Recomendação de Produtos: O endpoint /api/Produtos/{id}/recomendados fornece uma lista de produtos recomendados para o produto solicitado, gerando sugestões contextuais.








## 📝 Como Executar o Projeto
# Pré-Requisitos
  .NET 6 SDK - Baixar .NET SDK
  
  Banco de Dados Oracle - Configure a string de conexão para o banco de dados Oracle.
  
  Visual Studio 2022 - Para desenvolvimento e execução local.
  
  Passos para Configuração

# Clone o Repositório:
    git clone [https://github.com/SeuUsuario/ArgosNetAPI.git]
    cd ArgosNetAPI
    
# Configuração do Banco de Dados:
Configure a string de conexão no appsettings.json para conectar ao banco de dados Oracle.

# Instalar Dependências:
    dotnet restore

# Executar a API:
    dotnet run --project ArgosNetAPI
    
# Testar a API:
    Navegue para https://localhost:7137 para acessar o Swagger e testar os endpoints.
    Autentique-se no /api/Auth/login e use o token JWT para acessar os endpoints protegidos.
    
# Execute todos os testes:
    dotnet test
    
## 📂 Estrutura do Projeto
  Controllers: Controladores para Produtos, Clientes e Autenticação.
  
  Models: Definem as entidades Produto e Cliente.
  
  Repositories: Interface e implementação para acesso ao banco de dados.
  
  Services: Lógica de negócios e integração com ML.NET.
  
  ML: Contém o modelo de recomendação de produtos.
