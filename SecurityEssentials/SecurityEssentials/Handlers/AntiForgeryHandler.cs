using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace SecurityEssentials.Handlers
{
    public class AntiForgeryHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string form = string.Empty;
            string cookie = string.Empty;

            IEnumerable<string> headers;
            if (request.Headers.TryGetValues("AntiForgeryToken", out headers))
            {
                var tokens = headers.First().Split(':');
                if (tokens.Length == 2)
                {
                    cookie = tokens[0];
                    form = tokens[1];
                }
            }
            try
            {
                AntiForgery.Validate(cookie, form);
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Cross-site request denied")
                };
                return Task.FromResult(response);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}