using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http.Features;
using static PeanutButter.RandomGenerators.RandomValueGen;

namespace MockHttpContextHelpers
{
    public class FakeHttpContext : HttpContext
    {
        public FakeHttpContext(
            HttpRequest httpRequest, 
            HttpResponse httpResponse,
            ConnectionInfo connectionInfo,
            ClaimsPrincipal claimsPrincipal,
            FeatureCollection featureCollection,
            WebSocketManager webSocketManager,
            IDictionary<object, object?> items,
            IServiceProvider requestServices,
            CancellationToken requestAborted,
            string traceIdentifier,
            ISession session,
            AuthenticationManager authenticationManager)
        {
            Request = httpRequest;
            Response = httpResponse;
            Features = featureCollection;
            User = claimsPrincipal;
            Connection = connectionInfo;
            WebSockets = webSocketManager;
            Items = items;
            RequestServices = requestServices;
            RequestAborted = requestAborted;
            TraceIdentifier = traceIdentifier;
            Session = session;
            Authentication = authenticationManager;
        }
        
        public override void Abort()
        {
            throw new Exception("fake http context has been aborted...");
        }

        public override IFeatureCollection Features { get; }
        public override HttpRequest Request { get; }
        public override HttpResponse Response { get; }
        public override ConnectionInfo Connection { get; }
        public override WebSocketManager WebSockets { get; }
        public override AuthenticationManager Authentication { get; }
        public override ClaimsPrincipal User { get; set; }
        public override IDictionary<object, object?> Items { get; set; }
        public override IServiceProvider RequestServices { get; set; }
        public override CancellationToken RequestAborted { get; set; }
        public override string TraceIdentifier { get; set; }
        public override ISession Session { get; set; }
    }
}