namespace Aprendizado.Domains
{
    public class Cantor
    {
        public string Id { get; set; }
        private string Nome { get; set; } = string.Empty; // este metodo ao final faz com que ele saia do construtor sem um valor nulo
        private string Banda { get; set; } = string.Empty;
        private string Musica { get; set; } = string.Empty;
        public Cantor()
        {
            Id = Guid.NewGuid().ToString(); // Id gerado assim que o objeto é criado
            //Gera automaticamente um ID único (GUID) como string e atribui à propriedade Id.
        }
    }
}
// As propriedades Nome, Banda e Musica são privadas, ou seja, não podem ser acessadas de fora da classe diretamente.
// A propriedade Id é pública e será sempre criada com um valor novo (um GUID convertido para string), a cada vez que new Cantor() for chamado.
// Todas essas propriedades privadas são inicializadas com string.Empty, o que evita valores nulos