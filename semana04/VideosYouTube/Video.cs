using System.Collections.Generic;

public class Video
{
    private string _titulo;
    private string _autor;
    private int _duracaoSegundos;
    private List<Comentario> _comentarios = new List<Comentario>();

    public Video(string titulo, string autor, int duracaoSegundos)
    {
        _titulo = titulo;
        _autor = autor;
        _duracaoSegundos = duracaoSegundos;
    }

    public string ObterTitulo() => _titulo;
    public string ObterAutor() => _autor;
    public int ObterDuracaoSegundos() => _duracaoSegundos;
    public void AdicionarComentario(Comentario comentario) => _comentarios.Add(comentario);
    public int ObterQuantidadeComentarios() => _comentarios.Count;
    public List<Comentario> ObterComentarios() => new List<Comentario>(_comentarios);
}
