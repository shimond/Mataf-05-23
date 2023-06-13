namespace FirstWebApi.Model;
public record Product
{
    public  int Id { get; init; } = 12;
    public string? Name { get; init; }
    public double? Price { get; init; }
}
