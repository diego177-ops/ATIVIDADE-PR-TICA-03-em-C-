# 🚚 RotaPrime

## Sistema de Gestão de Transportadora

O **RotaPrime** é um sistema desenvolvido em C# para auxiliar no controle e organização das atividades de uma transportadora.

O projeto foi desenvolvido como uma atividade prática do curso Técnico em Desenvolvimento de Sistemas do **SENAI São Paulo**, com o objetivo de aplicar conceitos de **Programação Orientada a Objetos (POO)** em uma situação próxima da realidade de uma empresa.

---

## 📋 Sobre o projeto

Uma transportadora precisa controlar diversas informações durante suas atividades, como clientes, motoristas, veículos, cargas e entregas.

Quando essas informações são controladas manualmente, podem ocorrer problemas como perda de dados, dificuldade para localizar informações e falta de controle sobre o andamento das entregas.

O RotaPrime foi criado para centralizar essas informações e facilitar o gerenciamento das entregas.

---

## 🎯 Objetivo

O sistema tem como objetivo facilitar o controle das principais informações de uma transportadora, permitindo:

- Cadastrar clientes;
- Cadastrar motoristas;
- Cadastrar veículos;
- Cadastrar cargas;
- Cadastrar entregas;
- Listar informações cadastradas;
- Consultar entregas;
- Alterar o status das entregas;
- Excluir entregas;
- Visualizar o histórico das entregas;
- Identificar entregas atrasadas;
- Gerar um relatório das entregas;
- Salvar os dados em JSON;
- Carregar os dados salvos.

---

## ⚙️ Funcionalidades

### 👤 Cadastro de clientes

Permite cadastrar os clientes da transportadora.

Informações:

- ID;
- Nome;
- Telefone;
- Endereço.

### 👨‍💼 Cadastro de motoristas

Permite cadastrar os motoristas responsáveis pelas entregas.

Informações:

- ID;
- Nome;
- Telefone;
- CNH.

### 🚛 Cadastro de veículos

Permite cadastrar os veículos utilizados no transporte.

Informações:

- ID;
- Placa;
- Modelo;
- Marca;
- Ano.

### 📦 Cadastro de cargas

Permite cadastrar as mercadorias que serão transportadas.

Informações:

- ID;
- Descrição;
- Peso;
- Valor da carga.

### 🚚 Cadastro de entregas

Permite registrar uma entrega relacionando:

- Cliente;
- Motorista;
- Veículo;
- Carga;
- Origem;
- Destino;
- Data prevista;
- Status;
- Valor do frete.

---

## 📊 Status das entregas

Uma entrega pode possuir três status:

```text
Pendente
Em transporte
Entregue
