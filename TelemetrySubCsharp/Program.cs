using System;
using System.Text;
using NATS.Client;


string natsUrl = Environment.GetEnvironmentVariable("NATS_URL");
if (natsUrl == null)
{
    natsUrl = "nats://127.0.0.1:4222";
}


Options opts = ConnectionFactory.GetDefaultOptions();
opts.Url = natsUrl;


ConnectionFactory cf = new ConnectionFactory();
IConnection c = cf.CreateConnection(opts);



EventHandler<MsgHandlerEventArgs> handler = (sender, args) =>
{
    Msg m = args.Message;
    string text = Encoding.UTF8.GetString(m.Data);
    Console.WriteLine($"Async handler received the message '{text}' from subject '{m.Subject}'");
    Thread.Sleep(1000);
};

IAsyncSubscription subAsync = c.SubscribeAsync("foo", handler);
int urmom = 69
while (true){
    urmom = 69;
}