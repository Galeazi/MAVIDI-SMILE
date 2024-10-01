# Projeto OdontoPrev - Gamificação da Higiene Bucal

## Definição do Projeto

Este projeto visa a criação de uma aplicação gamificada para promover e incentivar a melhoria dos hábitos de higiene bucal entre os usuários da OdontoPrev. A aplicação oferece desafios diários, recompensas por progresso e uma integração social que incentiva a interação entre amigos. Utilizando a arquitetura Clean Architecture, a solução busca ser escalável, modular e de fácil manutenção.

## Objetivo do Projeto

O principal objetivo do projeto é reduzir a quantidade de sinistros relacionados a tratamentos odontológicos caros, incentivando hábitos preventivos de saúde bucal. Ao transformar o autocuidado bucal em um jogo divertido e interativo, o projeto visa aumentar o engajamento dos usuários e reduzir os custos com tratamentos corretivos, promovendo uma melhoria geral na saúde bucal dos clientes da OdontoPrev.

## Escopo

O projeto inclui o desenvolvimento de uma aplicação mobile que terá as seguintes funcionalidades principais:

- **Registro de Progresso**: Os usuários poderão registrar sua rotina de escovação e uso de fio dental diariamente.
- **Desafios e Recompensas**: Os usuários serão incentivados com desafios diários e prêmios à medida que progridem em suas rotinas de higiene.
- **Integração Social**: Os usuários poderão adicionar amigos, competir em rankings e compartilhar seu progresso.
- **Notificações Personalizadas**: O sistema enviará notificações para lembrar os usuários de escovar os dentes, usar fio dental e completar desafios.
- **Validação de Hábitos com IA**: Utilização de Machine Learning para validar a rotina de escovação com base em imagens fornecidas pelos usuários.

## Requisitos Funcionais e Não Funcionais

### Requisitos Funcionais
1. O usuário deve poder se registrar e autenticar no sistema.
2. O sistema deve permitir ao usuário registrar sua rotina de higiene bucal.
3. O usuário deve receber prêmios ao atingir metas e completar desafios.
4. O sistema deve enviar notificações sobre hábitos diários.
5. Os usuários devem poder adicionar amigos e acompanhar o progresso dos mesmos.
6. A aplicação deve validar as imagens enviadas para conferir a execução correta dos hábitos de higiene.
   
### Requisitos Não Funcionais
1. A aplicação deve ser responsiva e funcionar em dispositivos móveis Android e iOS.
2. O sistema deve ser escalável para suportar um grande número de usuários.
3. A aplicação deve garantir a segurança dos dados do usuário.
4. O tempo de resposta da aplicação deve ser inferior a 2 segundos em operações de rotina.
5. A aplicação deve ser de fácil manutenção e expansão, utilizando Clean Architecture.

---

## Desenho da Arquitetura

### Clean Architecture

Este projeto segue os princípios da Clean Architecture para garantir a separação clara de responsabilidades e manter o código desacoplado, modular e fácil de manter. A Clean Architecture divide o sistema em camadas distintas, onde cada uma delas tem uma responsabilidade única e bem definida.

### Camadas da Aplicação

#### 1. Apresentação

Responsável pela interface com o usuário e pela interação com a aplicação. Nesta camada, vamos lidar com:

- APIs de controle para integração com o front-end.
- Exposição de endpoints para os serviços de autenticação, registro de progressos, desafios, e interações sociais.

#### 2. Aplicação

Nesta camada ficam os serviços e casos de uso da aplicação. Aqui será implementada a lógica que orquestra o comportamento do sistema. Alguns exemplos de responsabilidades desta camada:

- Validação de regras de negócio antes de acessar os dados.
- Execução dos casos de uso, como adicionar amigos, processar prêmios e desafios.
- Integração com a camada de Domínio para aplicação das regras de negócio.

#### 3. Domínio

O coração da aplicação, contendo os modelos de dados e regras de negócio. Esta camada não deve depender de outras camadas, garantindo assim a inversão de dependência. As principais responsabilidades incluem:

- Definir entidades, como **Cliente**, **Progresso**, **Nível**, **Prêmio** e **Amigos**.
- Regras de negócio relacionadas à progressão de níveis, validação de prêmios, e interações sociais.
- Lógica para cálculo de pontos e validação de metas.

#### 4. Infraestrutura

Esta camada é responsável pelo acesso aos dados e pela comunicação com sistemas externos, como APIs e bancos de dados. Suas principais responsabilidades incluem:

- Implementação dos repositórios para acesso aos dados de clientes, progressos e prêmios.
- Integração com serviços externos, como APIs para notificação push e validação de imagens através de IA.
- Persistência de dados e comunicação com bancos de dados relacionais ou não relacionais.

---

## Estrutura Inicial do Projeto

plaintext
/Projeto-OdontoPrev
  ├── /Apresentacao
  │     └── Controllers/
  ├── /Aplicacao
  │     └── Services/
  ├── /Dominio
  │     └── Entities/
  │     └── RegrasDeNegocio/
  ├── /Infraestrutura
        └── Repositories/
        └── Integrations/
