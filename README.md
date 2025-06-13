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