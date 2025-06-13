## INSTALA��O DO AMBIENTE
- Tecnologias:
- Microsoft ASP.NET Core
- Swagger (para documenta��o da API)
- Oracle Entity FrameWork
- Microsoft EntityFramework Design

### Introdu��o:
Orienta��o � objetos veio com uma proposta de tangibilizar o que estamos 
desenvolvendo com as caracter�sticas do mundo real. Quando estamos 
desenvolvendo algo com a programa��o estruturada, n�s acabamos seguindo 
um fluxo �nico (seja ele: uma rotina �nica ou com sub-rotinas) onde caso 
precisemos replicar um c�digo para um outro trecho do fluxo, basta copiar e colar 
onde n�s desejarmos. 

- Girando em torno de Classes e Objetos.

-----------------------
### Encapsulamento:
C# refere-se � pr�tica de ocultar os detalhes internos de uma classe e expor apenas o que � necess�rio para o uso externo.
- Para modificadores de acesso usamos public, 
private e protected.
- Quando o objeto possui um Private, ele controlar� os acessos pelos m�todos Get e Set.

### Heran�a em C#:
permite que uma classe herde caracter�sticas (membros e comportamentos) de outra classe.
- A classe base � chamada de superclasse.
- A classe que herda dela � chamada de subclasse.
Exemplo:
```
public class Animal { ... }
```
```
public class Cachorro : Animal { ... }
```

### Polimorfismo em C#:
Refere-se � capacidade de uma classe base ser referenciada como sua classe derivada. 
Existem dois tipos principais de polimorfismo: 
- polimorfismo de tempo de compila��o (ou est�tico)
- polimorfismo de tempo de execu��o (din�mico).

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
Na classe Exemplo, o uso do polimorfismo ocorre quando ao criarmos uma inst�ncia de �Cachorro� e atribu�-la a uma vari�vel do 
tipo �Animal�, podemos chamar o m�todo �EmitirSom� da classe derivada 
(�Cachorro�) atrav�s da refer�ncia da classe base (�Animal�). Isso � 
polimorfismo de tempo de compila��o.