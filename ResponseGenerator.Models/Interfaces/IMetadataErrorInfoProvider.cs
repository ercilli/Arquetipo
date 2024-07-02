namespace ResponseGenerator.Models.Interfaces
{
    public interface IMetadataErrorInfoProvider
    {
        object GetMetadata();
        IEnumerable<string> GetErrors();
    }
}