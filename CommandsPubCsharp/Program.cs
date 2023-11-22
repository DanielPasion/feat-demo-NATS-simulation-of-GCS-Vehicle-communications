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
};


while (true){
    Console.WriteLine("Enter prompt:");

    string prompt = Console.ReadLine();
    c.Publish("foo", Encoding.UTF8.GetBytes(prompt));
}



c.Drain();