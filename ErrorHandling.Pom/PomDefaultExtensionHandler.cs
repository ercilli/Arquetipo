using System;
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
                Console.WriteLine("Ingreso a PomDefaultExtensionHandler");

                _model.Errors = new BaseErrorPomModel() { spects = "esto es el errorHandling del pom"};

                _model.Errors.description = "Error del pom";

                Console.WriteLine("Salgo de PomDefaultExtensionHandler");


            }
            catch (Exception exe)
            {
                Console.WriteLine(exe);
            }

        }
        protected override Task FillErrorAditionalAsync(Exception ex, HttpContext httpContext)
        {
            throw new NotImplementedException();
        }
    }
}

