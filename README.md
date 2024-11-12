# Projeto acadêmico desenvolvido com o intuito de praticar conceitos de desenvolvimento backend em C# e ASP.NET Core

API REST construída para cadastro de personagens fictícios com as seguintes funcionalidades:

- Listar todos os personagens cadastrados
- Buscar um personagem específico por ID
- Adicionar novos personagens
- Atualizar dados de um personagem existente
- Deletar um personagem pelo ID
- Filtrar personagens por localização

## Tecnologias Utilizadas

- ASP.NET Core
- C#

## Endpoints Principais

GET /api/personagens - Lista todos os personagens
GET /api/personagens/{id} - Retorna um personagem específico por ID
POST /api/personagens - Adiciona um novo personagem
PUT /api/personagens/{id} - Atualiza as informações de um personagem existente
DELETE /api/personagens/{id} - Remove um personagem pelo ID
GET /api/personagens/local/{locale} - Filtra personagens por localização
