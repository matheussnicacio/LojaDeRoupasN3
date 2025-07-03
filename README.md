# Sistema de Controle de Estoque de Roupas

## 📌 Contexto

Este projeto foi desenvolvido como parte da disciplina de **Programação Orientada a Objetos (POO)** na faculdade. Trata-se de um sistema de banco de dados voltado para o gerenciamento de estoque de uma loja de roupas.

O sistema permite o controle de roupas considerando seus **tipos**, **tamanhos** e **cores**, além de gerenciar os **fornecedores** e registrar as **vendas** realizadas. Cada roupa pode participar de várias vendas, e cada venda pode conter várias roupas.

---

## 🧩 Funcionalidades

- Cadastro de roupas com tipo, tamanho, cor e preço base.
- Registro de fornecedores que fornecem as roupas.
- Controle de estoque com quantidade disponível por combinação de roupa, tamanho e cor.
- Registro de vendas contendo múltiplas roupas e suas quantidades.
- Histórico de vendas com data e valor total.

---

## 🗃️ Estrutura de Dados (Tabelas Sugeridas)

- **Roupas**: Armazena as informações das roupas (nome, tipo, modelo, preço base, fornecedor).
- **Tamanhos**: Descrição e sigla dos tamanhos (ex: P, M, G).
- **Cores**: Nome ou descrição da cor da roupa.
- **Estoque**: Quantidade disponível para uma roupa específica, com seu tamanho e cor.
- **Fornecedores**: Nome, CNPJ ou outras informações do fornecedor da roupa.
- **Vendas**: Data e valor total de uma venda.
- **Itens de Venda**: Relação entre roupas e vendas, com quantidade vendida por item.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem**: C#
- **Paradigma**: Programação Orientada a Objetos
- **IDE Recomendada**: VS Code, Visual Studio Community ou Rider da Jetbrains
---

## 📂 Organização do Projeto

```plaintext
/LojaDeRoupasN3
│
├── Models/          # Classes que representam as entidades (Roupas, Tamanho, Cor, etc)
├── Services/        # Regras de negócio e manipulação de dados
└──  Program.cs      # Ponto de entrada do programa
