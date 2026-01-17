
# 🧙 Sobre o Projeto Lúdico

O programa de extensão Lúdico tem como público-alvo os alunos da UTFPR e a comunidade externa, abrangendo principalmente Londrina, Cornélio e regiões metropolitanas. O objetivo do programa é promover o desenvolvimento de análise crítica, raciocínio lógico, relações interpessoais e atuar como ferramenta de inserção cultural, e faz isso por meio de suas 3 atividades principais, as quais
serão melhor desenvolvidas nos tópicos abaixo, elas são: o Board Games, o RPG e o Escape Room. O ambiente do lúdico é gerenciado pelo coordenador e alunos bolsistas que auxiliam na gestão das atividades, atualmente é realizado mensalmente um evento público em que são praticadas as atividades listadas anteriormente.


# 📋 Requisitos e Regras de Negócios da Aplicação

A proposta do projeto é desenvolver uma nova aplicação desktop voltada para registro de pessoas, jogos, empréstimos, eventos e campanhas/seções referentes ao projeto do lúdico.
A nova solução será projetada com foco na usabilidade a partir de funções pedidas pelo coordenador do projeto de extensão e facilitar o lançamento de informações para a nuvem.
O sistema terá impacto direto na organização do Lúdico e registro de campanhas, oferendo uma ferramenta de registro mais prática, eficiente e aberta futuramente para melhorias futuras.

| ID    | Funcionalidade| Prioridade |
|-------|----------------------------------------------------------------------------------------------------------------------------------------------------------|------------|
| RF-1  | O sistema ter uma tela de visualização de jogos registrados | Essencial  |
| RF-2  | O sistema ter uma tela de registro de jogos | Essencial  |
| RF-3  | O sistema disponibilizar a pesquisa de jogos registrados | Importante  |
| RF-4  | O sistema disponibilizar a edição de jogos registrados | Desejável |
| RF-5  | O sistema disponibilizar a exclusão de jogos registrados | Desejável |
| RF-6  | O sistema ter uma tela de visualização de participantes registrados | Essencial |
| RF-7  | O sistema ter uma tela de registro de participantes | Essencial |
| RF-8  | O sistema disponibilizar a pesquisa de participantes registrados | Importante |
| RF-9  | O sistema disponibilizar a edição de participantes registrados | Desejável  |
| RF-10 | O sistema disponibilizar a exclusão de participantes registrados | Desejável  |
| RF-11 | O sistema ter uma tela de visualização de instituições registradas | Importante  |
| RF-12 | O sistema ter uma tela de registro de instituições | Desejável |
| RF-13 | O sistema disponibilizar a pesquisa de instituições registradas | Desejável  |
| RF-14 | O sistema disponibilizar a edição de instituições registradas | Desejável |
| RF-15 | O sistema disponibilizar a exclusão de instituições registradas  | Desejável  |
| RF-16 | O sistema ter uma tela de visualização de eventos registrados | Essencial  |
| RF-17 | O sistema ter uma tela de registro de eventos | Essencial  |
| RF-18 | O sistema disponibilizar a pesquisa de eventos registrados | Importante  |
| RF-19 | O sistema disponibilizar a edição de eventos registrados | Desejável  |
| RF-20 | O sistema disponibilizar a exclusão de eventos registrados  | Desejável  |
| RF-21 | Durante o gerenciamento do evento, o sistema poder registrar presença de um novo ou participante já existente | Importante  |
| RF-22 | Durante o gerenciamento do evento, o sistema poder registrar os jogos disponíveis  | Importante  |
| RF-23 | Durante o gerenciamento do evento, o sistema poder emprestar jogos disponíveis para um participante do evento | Importante  |
| RF-24 | Durante o gerenciamento do evento, disponibilizar os jogos emprestados no evento e o seu tempo de entrada e saída do empréstimo | Desejável  |
| RF-25 | O sistema ter uma tela de registro de Escape Room  | Importante  |
| RF-26 | O sistema disponibilizar a pesquisa de Escape Room registrados  | Importante  |
| RF-27 | O sistema disponibilizar a edição de Escape Room registrados  | Desejável  |
| RF-28 | O sistema disponibilizar a exclusão de Escape Room registrados  | Desejável  |
| RF-29 | Durante o gerenciamento do Escape Room, ser possível o registro de participantes  | Desejável  |
| RF-30 | O sistema ter uma tela de registro de RPG | Importante  |
| RF-31 | O sistema disponibilizar a pesquisa de RPG registrados  | Importante  |
| RF-32 | O sistema disponibilizar a edição de RPG registrados  | Desejável  |
| RF-33 | O sistema disponibilizar a exclusão de RPG registrados  | Desejável  |
| RF-34 | O sistema ter uma tela de campanhas de RPG no gerenciamento de RPG  | Importante  |
| RF-35 | O sistema possibilitar a pesquisa de campanhas de RPG no gerenciamento de RPG  | Desejável  |
| RF-36 | O sistema possibilitar a edição de campanhas de RPG no gerenciamento de RPG  | Desejável  |
| RF-37 | O sistema possibilitar a exclusão de campanhas de RPG no gerenciamento de RPG  | Desejável  |
| RF-38 | Dentro da tela de campanhas de RPG, possibilitar o registro de integrantes da campanha  | Desejável  |
| RF-39 | Dentro da tela de campanhas de RPG, possibilitar a exclusão de integrantes da campanha  | Desejável  |

# 📐 Arquitetura do Projeto e Tecnologias

Para o desenvolvimento do projeto, foram utilizadas as seguintes tecnologias:

1. 🗄️ **Banco de Dados**
- SQLite

2. 🎨 **Front-End**
- Windows Forms

3. ⚙️ **Back-End**
- C# (.NET Framework 4.8)

4. 💻 **IDEs**
- Visual Studio 2022

5. 🔄 **Versionamento**
- Git & GitHub

Com a definição das tecnologias e ferramentas utilizadas no projeto, foi possível estruturar a arquitetura do sistema de forma organizada. O diagrama a seguir ilustra a interação do cliente com o sistema: 
![Diagrama da Arquitetura](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/Arquitetura%20do%20Sistema.png)

# 🔨 Outras Ferramentas, Diagramas ou Informações
- [Diagrama de Atividades](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/Diagrama%20de%20Atividades.png)
- [Diagrama de Caso de Uso](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/Diagrama%20de%20Caso%20de%20Uso.png)
- [Diagrama de Classes](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/Diagrama%20de%20Classes.png)
- [Diagrama de Banco de Dados](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/Diagrama%20de%20Banco%20de%20Dados.png)
- [Protótipo do Figma](https://www.figma.com/design/oLX83B4F4ExAX4WHWGTP0c/Untitled?node-id=0-1&p=f)
- [Visualizar Documentação do Projeto](https://github.com/Jackoki/projeto-ludico/blob/master/readme_images/Documenta%C3%A7%C3%A3o%20do%20Projeto.pdf)

# 🚀 Como Executar o Projeto para Editar

Para rodar o sistema em sua máquina Windows, é necessário ter instalado:

- .NET Framework 4.8  
- Visual Studio 2022 ou Maior

Com isso instalado, basta abrir o arquivo projeto-ludico.sln no Visual Studio

# 🔷 Como Executar o Projeto para Usar

Para rodar o sistema em sua máquina Windows, é necessário ter instalado:
- .NET Framework 4.8 ou Windows 10+

Com isso, é necessário baixar o arquivo compactado do projeto no seguinte link: [Link da Pasta Compactada](https://github.com/Jackoki/projeto-ludico/blob/master/readme_images/Sistema%20de%20Gerenciamento%20-%20L%C3%BAdico.zip). Ao concluir o download, descompacte a pasta, abra e então execute o arquivo para usar o software.
![Implantação do Software](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/Implanta%C3%A7%C3%A3o.png)

# 👀 Telas do Sistema
![Tela 1](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/1.png)
![Tela 2](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/2.png)
![Tela 3](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/3.png)
![Tela 4](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/4.png)
![Tela 5](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/5.png)
![Tela 6](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/6.png)
![Tela 7](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/7.png)
![Tela 8](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/8.png)
![Tela 9](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/9.png)
![Tela 10](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/10.png)
![Tela 11](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/11.png)
![Tela 12](https://raw.githubusercontent.com/Jackoki/projeto-ludico/refs/heads/master/readme_images/12.png)
