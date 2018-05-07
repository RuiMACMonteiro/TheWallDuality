# TheWallDuality
This is a UAb project for UC of Lab. Desenv. Software by Rui Monteiro

Pre-requisitos:

Não é necessário fazer o download do editor Duality para executar o jogo, pois o mesmo encontra-se embutido na estrutura de ficheiros deste repositorio.

Notas importantes:

O "design-pattern" utilizado foi o MVC. Desta forma a separação lógica da arquitetura "Model-View-Controller" foi implementada (da forma possível) de acordo com o design da API Duality.

Os objetos do tipo "GameObjects" são o conteudo das Scenes definidas.
Estes objetos agrupam varios componentes a qual definem o comportamento dos mesmos na "Scene" criada. Estes objetos apenas definem as propriedades gráficas (implicatamente implementa o "Viewer") e a lógica do jogo está definida nas classes Controller e Model na pasta "TheWall\Source\Code\CorePlugin\" 

- A classe Viewer foi criada por uma questão da lógica da arquitetura MVC, pois não consegui forma de definir as propriedades gráficas e de design dos GameOgjects. Contudo
ela existe e declara recursos do jogo definidos no Editor apenas simbolicamente, pois tal como disse esta API é dependente de toda uma estrutura base automaticamente adicionada pela mesma.
- A classe Controller implementa o tratamento dos eventos do Viewer como o input do utilizador e dos estados do jogo   
- A classe Model implementa a lógica do jogo propriamente dita, as regras do jogo, respondendo aos pedidos do Controller

Para executar o jogo (implementado pelo design do Duality) executar o ficheiro DualityLauncher.exe.
A estrutura do Dualitor é automaticamente adicionada/implementada junto com o codigo definido nas classes.

Pendentes:
- De momento a parede foi apenas impementada com um "bloco" (default block). Fica pendente aplicar a parede com multiplos blocos
- Conseguir (de alguma forma) a separação da Viewer na classe definida para o efeito. Por enquanto não me foi possível fazer esta separaração




 
