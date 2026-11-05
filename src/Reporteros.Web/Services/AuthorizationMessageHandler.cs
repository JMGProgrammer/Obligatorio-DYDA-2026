using System.Net.Http.Headers;

namespace Reporteros.Web.Services;

public sealed class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly TokenStorage _storage;

    public AuthorizationMessageHandler(TokenStorage storage)
    {
        _storage = storage;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(_storage.Token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _storage.Token);
        }
        return base.SendAsync(request, cancellationToken);
    }
}
