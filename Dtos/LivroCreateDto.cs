namespace cp.Dtos;
public class LivroCreateDto
{
    public string Titulo { get; set; } = null!;
    public int AnoPublicacao { get; set; }
    public AutorDto Autor { get; set; } = null!;
}

public class AutorDto
{
    public string Nome { get; set; } = null!;
    public string Nacionalidade { get; set; } = null!;
}

public class LivroUpdateDto
{
    public string Titulo { get; set; } = null!;
    public int AnoPublicacao { get; set; }
    public AutorDto Autor { get; set; } = null!;
}
