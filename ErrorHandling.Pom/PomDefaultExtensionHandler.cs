using System;
using System.Threading.Tasks;
using ErrorHandling.Abstracts;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;
using System.Collections.Generic; // Necesario para trabajar con List<T>

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
                Console.WriteLine("Ingreso a PomDefaultExtensionHandler");

                // Crear y configurar el nuevo error
                var error = new BaseErrorPomModel()
                {
                    spects = "esto es el errorHandling del pom",
                    description = "Error del pom"
                };

                // Agregar el nuevo error a la lista
                _model.ListErrors.Add(error);

                Console.WriteLine("Salgo de PomDefaultExtensionHandler");
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