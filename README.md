# Notas:
## EntityFrameWork Core
EF Core pode servir como um mapeador relacional de objeto (O/RM), que: Permite que os desenvolvedores do . NET trabalhem com um banco de dados usando objetos .

## EntityFrameWork Core Migrations
Oferece uma maneira de atualizar de forma incremental o esquema de banco de dados usado, mantendo-o em sincronia com o modelo de dados do aplicativo e preservando os dados existentes.
- Atualizar o banco de dados
- Personalizar o código de migração
- Remover uma migração
- Reverter uma migração
- Gerar scripts SQL
- Aplicar migrações em tempo de execução
Pode ser usado em projetos:
- ASP .NET Core MVC
- APS .NET Core WEB API
- Mobile
- Desktop
Então, utilizando o EF Core Migrations, é necessário definir o modelo de domínio, criar o contexto do banco de dados, que herda de DBContext, definir as configurações da string de conexão, e adicionar uma migração (no console, `Add-migration nome_migracao`) e após os passos, executar (no console, `Update-Database`).
OBS: Essa forma de utilizar é conhecida como Code-First.

## Como utilizar o EF Core Migrations para criar e conectar a um banco de dados. Passo a Passo detalhado:
## Passo 1: Criando o projeto e instalando os pacotes necessários
Primeiramente é necessário criar o projeto, e logo após instalar os pacotes necessários, que são: EntityFrameWorkCore, EntityFrameWorkCore tools, EntityFrameWorkCore SqlServer (esta varia de acordo com o banco de dados que será usado, pode ser o MySql, SqlLite...)
## Passo 2: Criando os Models
Se não houver a pasta 'models', cria-la, e dentro dela criar o(s) primeiro(s) modelo(s), adicionando seus atributos (são, normalmente, as entidades que terão tabelas no banco de dados).
## Passo 3: Configurando o contexto
Ainda dentro da pasta 'models', criar a classe que será responsável pelo contexto (normalmente chamada de AppDbContext, ou somente DbContext), essa classe necessariamente herda de DbContext. No construtor da classe é registrado o contexto `public nomeContexto(DbContextOptions<nomeContexto> options) : base(options) {}`. Logo após, é necessário definir o DbSet, para mapear a entidade modelo, que futuramente terá uma tabela no banco de dados `public DbSet<nomeEntidade> 'nome' {get; set;}`.
## Passo 4: Configurando a conexão com o banco de dados
No arquivo 'appsettings.json' é necessário definir a string de conexão criando a diretiva "ConnectionStrings" e dentro dela o "DefaultConnection" (ou nome da preferência), este, contendo a string de conexão. 
*Nota:* A string de conexão pode ser encontrada após se conectar com o banco de dados no visual studio no caminho: Exibir -> Server Explorer -> Conexões de Dados, se já estiver conectado no banco de dados aparecerá o mesmo e ao clicar, na parte inferior direita aparecerá a cadeia de conexão. Não esquecer de alterar o nome da opção 'Catalog', pois este será o nome do banco de dados que será criado.
## Passo 5: Incluindo o contexto
*OBS:* Essa etapa possui diferentes formas para ser feita, neste caso está sendo descrita para uma aplicação APS .NET Core WEB API, mas são poucas as modificações para outros tipos de projetos.
Na classe 'Program', incluir o contexto, para que quando executado, possa se conectar ao banco de dados e passar o contexto, para isso é necessário inserir `builder.Services.AddDbContext<nomeDaClasseContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection" ou o nome definido na appsettings.json)));`
## Passo 6: Aplicando o Migrations
No 'Console do Gerenciador de Pacotes', inserir o código `Add-Migration nomeDesejadoDaMigracao` para adicionar a migration inicial, se não houver dado nenhum erro, inserir `Update-Database`, este código criará o banco de dados e gerará a(s) tabela(s) (entidades do models).
## Fim

## Definições importantes:
### Model
O model é basicamente o coração do projeto, pois nele está inserido as regras de negócio, as entidades, etc.

### Controller
Um controlador é responsável por controlar a maneira como um usuário interage com um aplicativo MVC. Um controlador contém a lógica de controle de fluxo para um aplicativo e determina qual resposta enviar de volta a um usuário quando um usuário faz uma solicitação de navegador.

## Repository
Repositories destinam-se a criar uma camada de abstração entre a camada de acesso a dados e a camada de lógica de negócios de um aplicativo, armazena a parte lógica do projeto, encapsulando a lógica das consultas no repositório.
