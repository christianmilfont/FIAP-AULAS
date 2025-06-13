## INSTALAÇÃO DO AMBIENTE
- Tecnologias:
- Microsoft ASP.NET Core
- Swagger (para documentação da API)
- Oracle Entity FrameWork
- Microsoft EntityFramework Design

### Introdução:
Orientação à objetos veio com uma proposta de tangibilizar o que estamos 
desenvolvendo com as características do mundo real. Quando estamos 
desenvolvendo algo com a programação estruturada, nós acabamos seguindo 
um fluxo único (seja ele: uma rotina única ou com sub-rotinas) onde caso 
precisemos replicar um código para um outro trecho do fluxo, basta copiar e colar 
onde nós desejarmos. 

- Girando em torno de Classes e Objetos.

-----------------------
### Encapsulamento:
C# refere-se à prática de ocultar os detalhes internos de uma classe e expor apenas o que é necessário para o uso externo.
- Para modificadores de acesso usamos public, 
private e protected.
- Quando o objeto possui um Private, ele controlará os acessos pelos métodos Get e Set.

### Herança em C#:
permite que uma classe herde características (membros e comportamentos) de outra classe.
- A classe base é chamada de superclasse.
- A classe que herda dela é chamada de subclasse.
Exemplo:
```
public class Animal { ... }
```
```
public class Cachorro : Animal { ... }
```

### Polimorfismo em C#:
Refere-se à capacidade de uma classe base ser referenciada como sua classe derivada. 
Existem dois tipos principais de polimorfismo: 
- polimorfismo de tempo de compilação (ou estático)
- polimorfismo de tempo de execução (dinâmico).

  Exemplo:
```
public class Animal {
    public virtual void emitirSom()
  }
}
```
```
public class Cachorro : Animal {
    public override void emitirSom()
  }
}
```
```
public class Exemplo {
    public void Teste(){
      Animal meuAnimal = new Cachorro();
      meuAnimal.emitirSom();
    }
  }

```
Na classe Exemplo, o uso do polimorfismo ocorre quando ao criarmos uma instância de “Cachorro” e atribuí-la a uma variável do 
tipo “Animal”, podemos chamar o método “EmitirSom” da classe derivada 
(“Cachorro”) através da referência da classe base (“Animal”). Isso é 
polimorfismo de tempo de compilação.



## Configurando o EntityFramework
O Entity Framework é um framework ORM (Object-Relational Mapping) desenvolvido 
pela Microsoft. Ele permite que os desenvolvedores interajam com bancos de dados relacionais 
usando objetos e consultas em linguagens de programação, como C#

Pacotes Necessários:
- Microsoft.EntityFrameworkCore 
- Microsoft.EntityFrameworkCore.Tools 
- Microsoft.EntityFrameworkCore.Design 
- Oracle.EntityFrameworkCore 

### Criando um DBContext 
O DbContext é uma classe central no Entity Framework (EF) e Entity Framework Core 
(EF Core), atuando como um canal entre o código C# de sua aplicação e o banco de dados. É 
parte do namespace Microsoft.EntityFrameworkCore e serve para configurar o modelo de 
dados, realizar consultas, e salvar alterações no banco de dados. O DbContext encapsula uma 
sessão com o banco de dados, oferecendo uma API simplificada para executar operações CRUD 
(Criar, Ler, Atualizar, Deletar) nas entidades mapeadas.

- Consulta de Dados: O DbSet<T> oferece suporte a operações de consulta LINQ. 
Permitindo que desenvolvedores escrevam consultas de forma expressiva e em alto nível, que são traduzidas pelo EF Core para SQL.
- Rastreamento de Entidades: Quando uma entidade é obtida através de um DbSet, o EF Core por padrão rastreia suas alterações.
- Operações CRUD: Além das consultas, o DbSet<T> facilita a criação, atualização e exclusão de entidades.
- Carregamento de Relacionamentos: O DbSet<T> suporta operações para carregar explicitamente relacionamentos entre entidades.

### Configurações para conectar ao banco Oracle:
No desenvolvimento de aplicações .NET e .NET Core, o gerenciamento de configurações é um aspecto crucial que permite definir e acessar variáveis de configuração de maneira flexível e segura.

#### appsettings.json :
- Este arquivo é utilizado para definir configurações que são comuns a todos os ambientes de execução da aplicação
- Porém, para não expor conteudos sensiveis, uitlizamos o appsettings.development.json, que subscreve o arquivo appsettings.json mas não altera o codigo.
```
"ConnectionStrings": { 
"OracleConnection": "Data 
Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=<HOST>)(P
 ORT=<PORT>)))(CONNECT_DATA=(SERVICE_NAME=< SERVICE_NAME >)));User 
ID=<USERID>;Password=<PASSWORD>;" 
}
```
### Mapeando o DbContext:
- Antes do var app adicionamos em Program.cs nossa mapagem para nossa string de conexão:
```
builder.Services.AddDbContext<OracleDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
});
```