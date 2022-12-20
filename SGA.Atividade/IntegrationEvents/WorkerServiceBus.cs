using Azure.Messaging.ServiceBus;
using SGA.Atividade.IntegrationEvents.Events;
using SGA.Atividade.Services;
using System.Text.Json;

namespace SGA.Atividade.IntegrationEvents
{
    public class WorkerServiceBus : IHostedService, IDisposable
    {
        private readonly IConfiguration configuration;
        private readonly IServiceScopeFactory serviceProvider;     
        private ServiceBusClient client;
        private ServiceBusProcessor processor;

        public WorkerServiceBus(IConfiguration configuration, IServiceScopeFactory service)
        {
            this.configuration = configuration;
            this.serviceProvider = service;
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            client = new ServiceBusClient("Endpoint=sb://sgadornas.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gxI8TIBMZFf3fD9lT0hVO0oFb63kuzxPtzTR2htkc1w=;EntityPath=disciplina-nome-changed");

            processor = client.CreateProcessor("disciplina-nome-changed", "S1", new ServiceBusProcessorOptions());

            // add handler to process messages
            processor.ProcessMessageAsync += MessageHandler;

            // add handler to process any errors
            processor.ProcessErrorAsync += ErrorHandler;

            // start processing 
            await processor.StartProcessingAsync();

        }

        // handle received messages
        async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            
            var @event = JsonSerializer.Deserialize<DisciplinaNomeChanged>(body);

            using (var scope = serviceProvider.CreateScope()) // this will use `IServiceScopeFactory` internally
            {
                var atividadeService = scope.ServiceProvider.GetService<IAtividadeService>();
                atividadeService.UpdateAtividadesByDisciplinaNome(@event.DisciplinaId, @event.NewNome);

            }


            // complete the message. messages is deleted from the subscription. 
            await args.CompleteMessageAsync(args.Message);
        }

        // handle any errors when receiving messages
        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }
    }
}
