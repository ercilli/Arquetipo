// MetadataErrorInfoProvider.cs
using System.Collections.Generic;
using ResponseGenerator.Models.Interfaces;

namespace ResponseGenerator.Models
{
    public class MetadataErrorInfoProvider : IMetadataErrorInfoProvider
    {
        public object GetMetadata()
        {
            // Implementación para obtener metadatos
            return new { /* datos de metadatos */ };
        }

        public IEnumerable<string> GetErrors()
        {
            // Implementación para obtener detalles de errores
            return new List<string> { /* lista de errores */ };
        }
    }
}