namespace Logging.Interceptor.Pom;

public class LoggingInterceptorHandlerPom : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Añadir lógica específica de POM, por ejemplo, añadir un encabezado específico
        request.Headers.Add("X-Pom-Specific-Header", "ValorEspecifico");

        // Llamar al handler base (que podría ser LoggingHandler de PaaS)
        return await base.SendAsync(request, cancellationToken);
    }
}

