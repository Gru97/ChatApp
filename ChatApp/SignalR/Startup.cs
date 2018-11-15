using Owin;
[assembly:Microsoft.Owin.OwinStartup(typeof(ChatApp.SignalR.Startup),methodName:"Configuration")]

namespace ChatApp.SignalR
{
    public class Startup : object
    {
        public Startup() :base()
        {

        }
        public void Configuration(Owin.IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}