using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Example.A.Controllers
{
    [Route("api/[controller]")]
    public class ComplexController : Controller
    {
        [HttpGet("GetComplexObject")]
        public ActionResult<ComplexItem> GetComplexObject()
        {
            var complexItem = new ComplexItem
            {
                Id = 1,
                Name = "Complex Item 1",
                SubItems = new List<ComplexSubItem>
                {
                    new ComplexSubItem
                    {
                        Id = 1,
                        Description = "SubItem 1",
                        Details = new Dictionary<string, AdditionalDetail>
                        {
                            { "Detail1", new AdditionalDetail { Timestamp = DateTime.Now, Information = "This is a detail" } }
                        },
                        Data = new byte[] { 0x20, 0x21 } // Ejemplo de datos binarios
                    }
                },
                // Evitar relaciones circulares en la respuesta real o manejarlas adecuadamente
                ParentItem = null // Para simplificar, en un caso real se manejaría de otra manera
            };

            return complexItem;
        }

        [HttpGet("GetListOfComplexObjects")]
        public ActionResult<List<ComplexItem>> GetListOfComplexObjects()
        {
            var complexItems = new List<ComplexItem>
            {
                new ComplexItem
                {
                    Id = 1,
                    Name = "Complex Item 1",
                    SubItems = new List<ComplexSubItem>
                    {
                        new ComplexSubItem
                        {
                            Id = 1,
                            Description = "SubItem 1",
                            Details = new Dictionary<string, AdditionalDetail>
                            {
                                { "Detail1", new AdditionalDetail { Timestamp = DateTime.Now, Information = "This is a detail" } }
                            },
                            Data = new byte[] { 0x20, 0x21 }
                        }
                    },
                    ParentItem = null
                },
                // Agregar más objetos complejos según sea necesario
            };

            return complexItems;
        }
    }
}

