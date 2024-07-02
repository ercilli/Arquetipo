public class ComplexItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ComplexSubItem> SubItems { get; set; }
    public ComplexItem ParentItem { get; set; } // Relación circular
}

public class ComplexSubItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public Dictionary<string, AdditionalDetail> Details { get; set; } // Colección anidada
    public byte[] Data { get; set; } // Datos binarios
}

public class AdditionalDetail
{
    public DateTime Timestamp { get; set; } // Tipo de dato especial
    public string Information { get; set; }
}