using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using OwinInterface = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
namespace WebApiOwin
{
    public class WebApiModule
    {
        private readonly OwinInterface _next;
 
        public WebApiModule(OwinInterface next)
        {
            if (next == null)
                throw new ArgumentNullException("next");
 
            this._next = next;
        }
 
        public Task Invoke(IDictionary<string, object> env)
        {
            try {
                var request = new OwinRequest(env);
                var path = request.Path.Value.TrimEnd(new[] { '/' });
 
                if (path.Equals("/contacts", StringComparison.OrdinalIgnoreCase)) {
                    var response = new OwinResponse(env);
                    return response.WriteAsync("My email: myemail@gmail.com, contact phone: +380507776655");
                }
            }
            catch (Exception ex) {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                return tcs.Task;
            }
 
            return this._next(env);
        }
    }
}