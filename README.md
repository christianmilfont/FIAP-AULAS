# Disciplina Java: API's Rest, boas práticas e segurança.
## Dicas e Referências para Implementações em Java:
### Livro: Design Patterns com Java - Casa do Codigo (Eduardo Guerra), Projeto orientado a objetos guiado por padrões
- Este livro afirma que muitas vezes, apenas por seguir as regras de uma determinada API, sem saber você já utilizando um determinado padrão. A flexibilidade que aquele framework consegue para ser instanciado na sua aplicação, muitas vezes é conseguido justamente pelo uso do padrão.
- Esse livro também cita diversas classes de APIs padrão da linguagem Java e de frameworks amplamente utilizados pela comunidade de desenvolvimento. Isso vai permitir que o desenvolvedor possa compreender melhor aquela solução inteligente utilizada naquele contexto, e trazer a mesma ideia para questões do seu próprio código.

### Entendendo padrões de projeto:
- CONCEITOS DA ORIENTAÇÃO A OBJETOS: Visando o início da programação a qual não possuia nenhum padrão de organização  e separação dos elementos do codigo. Isso, tornava o codigo muito ilegivel e mal estruturado surgindo ate mesmo o termo *“código macarrônico”*.
- Para isso, formou-se a Programação Estruturada, separando os elementos por métodos/funções (armazenando a lógica) permitindo sua modularização, comandos condicionais (if/else) e comandos interativos (while/for).
- Conforme melhorias e necessidades, surgiu a Programação Orientada a Obejtos.
### Classes e Objetos:
- Na programação orientada a objetos são definidos novos tipos através da criação de classes, e esses tipos podem ser instanciados criando objetos. A ideia é que um objeto represente uma entidade concreta enquanto sua classe representa uma abstração dos seus conceitos.
- A classe possui estado e comportamento, que são representados respectivamente pelos atributos e métodos definidos. Enquanto uma classe possui uma característica, um objeto possui um valor para aquela característica.
- Projetar um sistema orientado a objetos consiste em definir suas classes e como elas colaboram para conseguir implementar os requisitos de uma aplicação.

### Herança:
- Se uma aplicação precisa de um conjunto de objetos, devem haver classes que abstraiam esses conceitos.
- Esses  objetos podem precisar ser tratados em partes diferentes do software a partir de diferentes níveis de abstração.
- A *herança* é uma característica do paradigma orientado a objetos que permite que abstrações possam ser definidas em diversos níveis.
#### "Quando uma classe estende outra, ela não só herda a estrutura de dados e o comportamento da superclasse, mas também o contrato que ela mantém com os seus clientes."

## INTERFACE OU CLASSE ABSTRATA?
- Tanto as classes abstratas quanto as interfaces podem definir métodos abstratos que precisam ser implementados pelas classes que respectivamente a estende ou implementa.
- Apenas as classes abstratas podem possuir métodos concretos e atributos.

#### "Quando a abstração que precisar ser criada for um conceito, ou seja, algo que possa ser refinado e espacializado, deve-se utilizar uma classe abstrata. Quando a abstração é um comportamento, ou seja, algo que uma classe deve saber fazer, então a melhor solução é a criação de uma interface."
- Para entender melhor:
1. imaginando um jogo no qual existem naves que se movem.
2. Se sua abstração representa uma nave, então você está representando um conceito e deve utilizar uma classe abstrata.
3. Se sua abstração representa algo que se move, então o que está sendo abstraído é um comportamento e a melhor solução é usar uma interface.

### Ambiente e suas Tecnologias:
- Java SDK 17
- Spring Boot
- VS Code
- Auth0 para autenticação
- Beans Validations
  
### Arquitetura e funcionalidades:
- Os projetos até então precisam ter as seguintes funcionalidades/recursos:
- CRUD com persistência
- Dados complexos
- Relacionamentos de entidades
- Autenticação

- diagrama de classes
O diagrama representa as classes e os relacionamentos entre elas. 

- Pacote Model, serve para a criação dos objetos e classes para relacionamento, exemplo seria a classe carta e jogador com seus respectivos objetos e relacionamentos.
- Pacote Exception, geração mais detalhada dos logs informando os erros.
- Pacote controller, serve para controlarmos os End Points das nossas API's.
- Pacote Service, serve para adicionarmos nossos métodos referentes as regras de negócio ou referentes aos controladores.

### API Rest:
![image](https://github.com/user-attachments/assets/b6a1c463-36e8-4c57-a6a3-4f75cc2087e1)

#### Recursos e verbos:
```
Nome |   Path     |     Verbo   |   Ação
Index    /setups        GET       Listar todos os setups
Create   /setups        POST      Criar um novo setup
Show     /setups/{id}   GET       Mostra dados de um setup
Update   /setups/{id}   PUT       Atualiza um setup
Destroy   /setups/{id}  DELETE    Apaga um setup
```

#### Erros (http status code):
 1xx = information
 2xx = success
 3xx = redirection
 4xx = client error
 5xx = server error


### spring data jpa
- Controle e acesso ao banco de dados
- Para isso usamos a seguinte solução:
![image](https://github.com/user-attachments/assets/529e2bf1-c8ed-44fe-b4b8-7904a65ff118)
- Problemas do JDBC (muito verboso e uma dependencia muito forte ao SGBD)

- Utilizamos o ORM (Object-Relational Mapping) em nossos pacotes. 
*used to map objects in your Java application to relational database tables*
- Sempre por Field (Id, preco, nome...) e Types (VARCHAR255, int, string...)

### Especificação vs implementação:
- Hibernate
- EclipseLink
- OpenJPA

- Para conectarmos ao nosso ambiente de BD, utilizamos variaveis de ambiente dentro de application.properties, para configurarmos as conexões.

### Spring Data JPA:
- < < interface > > xRepository
-  JPARepository: /findAll() / save() / deleteById() / count()
-  EntityManager: /persist() / remove() / find() / contains()
![image](https://github.com/user-attachments/assets/438add75-baef-4062-b593-8617436e69cc)

### Bean Validations:
#### Bean Validation é um padrão Java (JSR 380 / 303) usado para validar atributos de classes (geralmente DTOs ou entidades), utilizando anotações como @NotBlank, @Email, @Min ...
![image](https://github.com/user-attachments/assets/36a87a1a-a9ee-4583-9cd2-feb7b7317d50)

1. Adicionar o Bean Validation no Starter
2. Anotar as regras no model
3. Anotar parâmetro com @Valid

```
@NotNull | @Size (min=3, max=30) | @Pattern(regexp = "")
```
```
import jakarta.validation.constraints.*; // Import das nossas anotations beans

public class UsuarioDTO {

    @NotBlank(message = "Nome é obrigatório") 
    private String nome;

    @Email(message = "Email inválido")
    @NotBlank(message = "Email é obrigatório")
    private String email;

    @Min(value = 18, message = "Idade mínima é 18")
    private int idade;

    // Getters e Setters...
}

```

#### Representação dos dados validados
- O que é:
Quando você envia dados para um endpoint, o Spring pode:

- Validar os dados automaticamente com @Valid
- Retornar um erro formatado com os campos e mensagens. Ou, se válido, continuar o fluxo normal
```
@PostMapping
public ResponseEntity<?> criarUsuario(@RequestBody @Valid UsuarioDTO dto, BindingResult result) {
    if (result.hasErrors()) {
        Map<String, String> erros = new HashMap<>();
        result.getFieldErrors().forEach(erro -> {
            erros.put(erro.getField(), erro.getDefaultMessage());
        });
        return ResponseEntity.badRequest().body(erros);
    }

    return ResponseEntity.ok(Map.of(
        "mensagem", "Usuário criado com sucesso!",
        "usuario", dto
    ));
}
```
Exception Handler (Centralizado) @RestControllerAdvice serve para tratar erros globalmente com @ExceptionHandler	em uma classe separada.

- O que é: Um método global para capturar erros de validação, exceções de negócio, erros 404, etc., e padronizar as respostas da sua API.
Importando:
```
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;
import org.springframework.http.ResponseEntity;
```

```
@RestControllerAdvice
public class GlobalExceptionHandler {

    @ExceptionHandler(MethodArgumentNotValidException.class)
    public ResponseEntity<Map<String, String>> handleValidationErrors(MethodArgumentNotValidException ex) {
        Map<String, String> erros = new HashMap<>();

        ex.getBindingResult().getFieldErrors().forEach(erro -> {
            erros.put(erro.getField(), erro.getDefaultMessage());
        });

        return ResponseEntity.badRequest().body(erros);
    }
}
```

ResponseStatusException (para lançar erros com status HTTP manualmente) serve para lançar erro HTTP com status e mensagem	de qualquer lugar (controller/service).
- O que é: Classe de exceção do Spring para retornar um erro HTTP com status específico e mensagem.
  
Importando:
```
import org.springframework.web.server.ResponseStatusException;
import org.springframework.http.HttpStatus;
```

```
@GetMapping("/{id}")
public UsuarioDTO buscarPorId(@PathVariable Long id) {
    return usuarioService.buscar(id)
        .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Usuário não encontrado"));
}
```


- 
