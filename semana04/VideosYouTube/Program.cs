using System;
using System.Collections.Generic;

List<Video> videos = new List<Video>();

Video video1 = new Video("Introducao ao C#", "Canal Aprender", 420);
video1.AdicionarComentario(new Comentario("Ana", "Explicacao muito clara!"));
video1.AdicionarComentario(new Comentario("Bruno", "Gostei dos exemplos."));
video1.AdicionarComentario(new Comentario("Carla", "Ajudou nos meus estudos."));
videos.Add(video1);

Video video2 = new Video("Classes e Objetos", "Programacao Facil", 615);
video2.AdicionarComentario(new Comentario("Diego", "Agora entendi classes."));
video2.AdicionarComentario(new Comentario("Elisa", "Pode fazer mais aulas?"));
video2.AdicionarComentario(new Comentario("Fabio", "Muito bom!"));
videos.Add(video2);

Video video3 = new Video("Encapsulamento em C#", "Canal Aprender", 540);
video3.AdicionarComentario(new Comentario("Gabriela", "Gostei da organizacao."));
video3.AdicionarComentario(new Comentario("Henrique", "Exemplo pratico excelente."));
video3.AdicionarComentario(new Comentario("Isabela", "Obrigado pela aula!"));
videos.Add(video3);

foreach (Video video in videos)
{
    Console.WriteLine("========================================");
    Console.WriteLine($"Titulo: {video.ObterTitulo()}");
    Console.WriteLine($"Autor: {video.ObterAutor()}");
    Console.WriteLine($"Duracao: {video.ObterDuracaoSegundos()} segundos");
    Console.WriteLine($"Numero de comentarios: {video.ObterQuantidadeComentarios()}");
    Console.WriteLine("Comentarios:");
    foreach (Comentario comentario in video.ObterComentarios())
    {
        Console.WriteLine($"- {comentario.ObterNome()}: {comentario.ObterTexto()}");
    }
}
Console.WriteLine("========================================");
