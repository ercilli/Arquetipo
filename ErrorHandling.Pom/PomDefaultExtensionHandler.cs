using ErrorHandling.Abstracts;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;

namespace ErrorHandling.Pom
{
    public class PomDefaultExtensionHandler : BaseExceptionHandler
    {
        private readonly ResponseApi _model;

        public PomDefaultExtensionHandler(ResponseApi model) : base(model)
        {
            _model = model;
        }

        protected override void FillErrorAditional(Exception ex, HttpContext httpContext)
        {
            try
            {
                // Crear y configurar el nuevo error
                var error = new BaseErrorPomModel()
                {
                    spects = "esto es el errorHandling del pom",
                    description = "Error del pom"
                };

                // Agregar el nuevo error a la lista
                _model.ListErrors.Add(error);

            }
            catch (Exception exe)
            {
                Console.WriteLine(exe);
            }
        }

        protected override Task FillErrorAditionalAsync(Exception ex, HttpContext httpContext)
        {
            // Implementación asincrónica si es necesario
            throw new NotImplementedException();
        }
    }
}