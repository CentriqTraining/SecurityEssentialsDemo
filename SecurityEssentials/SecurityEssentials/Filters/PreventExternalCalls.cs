using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SecurityEssentials.Filters
{
    public class PreventExternalCalls : FilterAttribute, IAuthorizationFilter
    {
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            string form = string.Empty;
            string cookie = string.Empty;

            IEnumerable<string> headers;
            if (actionContext.Request.Headers.TryGetValues("AntiForgeryToken", out headers))
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
            return continuation();
        }
    }
}