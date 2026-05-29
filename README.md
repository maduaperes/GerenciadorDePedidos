# AppPadaria

## Visão Geral
O **AppPadaria** é uma aplicação desktop desenvolvida em Java para o gerenciamento integrado de panificadoras e comércios locais. O sistema adota uma arquitetura em camadas combinada com o padrão **DAO (Data Access Object)**, garantindo a separação rígida entre as regras de negócio, a persistência de dados em banco relacional e a interface de usuário.

---

## Funcionalidades Principais
* **Controle de Estoque e Produtos:** Cadastro, atualização e monitoramento de mercadorias e insumos.
* **Gestão de Clientes e Fornecedores:** Mapeamento completo de parceiros comerciais, incluindo vínculos de endereços estruturados.
* **Módulo de Vendas e Pedidos:** Emissão de pedidos complexos com suporte a múltiplos itens e associação dinâmica de dados.
* **Operações CRUD Completas:** Persistência robusta para todas as entidades principais do sistema através do banco de dados.
* **Interface Gráfica Customizada:** Ambiente visual amigável com navegação lateral por menus e componentes reutilizáveis.

---

## Tecnologias e Conceitos Utilizados
* **Linguagem:** Java
* **Interface Gráfica:** Java Swing
* **Persistência de Dados:** JDBC (Java Database Connectivity)
* **Arquitetura:** Camadas (Model-View-Controller adaptado) e Padrão DAO
* **Ambiente de Desenvolvimento:** IntelliJ IDEA

---

## Estrutura do Projeto
Organização dos pacotes e diretórios do sistema:

```text
AppPadaria/
├── libraries/           # Drivers de conexão (.jar) e dependências externas
├── src/
│   ├── model/           # Entidades de negócio (Cliente, Produto, Pedido, etc.)
│   ├── dao/             # Classes de persistência e comandos SQL (CRUD)
│   ├── util/            # Utilitários de sistema e gerenciamento de Conexao
│   └── view/            # Telas da interface gráfica, Sidebar e componentes Swing
└── img/                 # Ativos visuais, ícones e recursos de identidade visual

```

> **Nota:** Arquivos de configuração de IDE (.idea, *.iml) e artefatos de compilação local foram configurados no .gitignore para preservar a integridade e a leveza do repositório remoto.

---

## Divisão Arquitetural

### Model

Define a estrutura de dados e as entidades fundamentais do domínio da aplicação, como Clientes, Fornecedores, Endereços, Produtos, Pedidos e Itens de Pedido.

### DAO (Data Access Object)

Centraliza toda a lógica de comunicação com o banco de dados. Isola as instruções SQL (Insert, Update, Delete, Select) do restante da aplicação, promovendo o desacoplamento.

### Util

Contém classes de suporte de infraestrutura, destacando-se o gerenciador de conexões que inicializa e mantém os túneis de comunicação via JDBC.

### View

Camada de apresentação desenvolvida em Java Swing. Inclui a tela principal (Home), os formulários de cadastro e componentes visuais personalizados para otimizar a experiência do operador.

---

## Como Executar o Projeto

1. **Clonar o repositório:**
```bash
git clone [https://github.com/maduaperes/AppPadaria.git](https://github.com/maduaperes/AppPadaria.git)

```


2. **Configurar as Dependências:**
Certifique-se de que o driver JDBC correspondente ao seu banco de dados está devidamente importado na pasta `libraries/` e referenciado no caminho de build (Build Path) do seu projeto.
3. **Configurar o Banco de Dados:**
Ajuste as credenciais de acesso (URL, usuário e senha) no arquivo `src/util/Conexao.java`.
4. **Executar a aplicação:**
Execute a classe de ponto de entrada localizada dentro do pacote `src/view/` para iniciar a interface gráfica.

---

## Objetivo Educacional

Este sistema foi desenvolvido como projeto prático de portfólio com a finalidade de consolidar conhecimentos em:

* Integração de aplicações Java com bancos de dados relacionais via JDBC.
* Construção de interfaces desktop ricas utilizando componentes nativos Swing.
* Aplicação prática de padrões de projeto para isolamento de camadas de persistência.
