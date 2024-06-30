using Arquetipo.Paas.Enums;
using Cors.Configuration.Extensions;
using ErrorHandling.Middleware;
using Healthcheck.Configuration.Extensions;
using Logging.Filter.Middlewares;
using ResponseGenerator.Middlewares;

namespace Arquetipo.Paas.MiddlewareRegistration;

public class MiddlewareRegistry
{
    private List<(Type MiddlewareType, int Position)> _middlewares = new List<(Type, int)>();
    private int _baseMiddlewareCount = 0; // Contador para middlewares base del PaaS

    public MiddlewareRegistry()
    {
        RegisterBaseMiddlewaresFromEnum();
    }

    private void RegisterBaseMiddleware(Type middlewareType)
    {
        _middlewares.Add((middlewareType, _baseMiddlewareCount++));
    }

    public void RegisterMiddlewareAtPosition1(Type middlewareType, int position)
    {
        if (position < 0 || position > _baseMiddlewareCount)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "La posición está fuera del rango permitido.");
        }
        _middlewares.Add((middlewareType, position));
    }

    public void RegisterMiddlewareAtPosition(Type middlewareType, int position)
    {
        if (position < 0 || position > _middlewares.Count) // Permitir posición al final de la lista
        {
            throw new ArgumentOutOfRangeException(nameof(position), "La posición está fuera del rango permitido.");
        }

        // Aumentar la posición de los middlewares existentes que están en la posición de inserción o después
        for (int i = 0; i < _middlewares.Count; i++)
        {
            if (_middlewares[i].Position >= position)
            {
                _middlewares[i] = (_middlewares[i].MiddlewareType, _middlewares[i].Position + 1);
            }
        }

        // Insertar el nuevo middleware en la posición deseada
        _middlewares.Add((middlewareType, position));
        _middlewares = _middlewares.OrderBy(m => m.Position).ToList(); // Reordenar la lista
    }


    public IEnumerable<Type> GetOrderedMiddlewareTypes()
    {
        return _middlewares.OrderBy(m => m.Position).Select(m => m.MiddlewareType);
    }

    private void RegisterBaseMiddlewaresFromEnum()
    {
        foreach (BaseMiddleware middleware in Enum.GetValues(typeof(BaseMiddleware)))
        {
            Type middlewareType = middleware switch
            {
                BaseMiddleware.RequestInspection => typeof(RequestInspectionMiddleware),
                BaseMiddleware.RequestLogger => typeof(RequestLoggerMiddleware),
                BaseMiddleware.ResponseLogger => typeof(ResponseLoggerMiddleware),
                BaseMiddleware.ResponseGenerator => typeof(ResponseGeneratorMiddleware),
                BaseMiddleware.ErrorHandling => typeof(ErrorHandlingMiddleware),
                BaseMiddleware.ResponseInspection => typeof(ResponseInspectionMiddleware),
                _ => throw new ArgumentException("Unknown middleware")
            };

            RegisterBaseMiddleware(middlewareType);
        }
    }
}
