/* 
 *  Author: Fikri Aydemir
 *  Date  :	10/04/2020 15:14
 *  
 *  Released under MIT License
 *
 */
using APIGateway.Thrift.Generated.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;
using Serilog.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using Thrift;
using Thrift.Processor;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using Thrift.Transport.Server;

namespace Server.APIGateway.Thrift
{
    /// <summary>
    /// Class providing the execution logic of Thrift Server
    /// </summary> 
    public class Startup
    {
        private const string STR_ThriftServerDefaultPort = "ThriftServerDefaultPort";
        private const string STR_AppName = "ThriftServer";
        private const string STR_QuitText = "Press q to stop the server...";

        /// <summary>
        /// Public Ctor
        /// </summary> 
        public Startup()
        {
        }

        public void StartServer()
        {
            try
            {
                var configuration = GetConfiguration();
                Log.Logger = CreateSerilogLogger(configuration);                
                IHost host = CreateHostBuilder(configuration, Log.Logger);               
                int serverPort = configuration.GetValue<int>(STR_ThriftServerDefaultPort);

                Log.Information("Starting {0} at port {1}", STR_AppName, serverPort);

                //Prepare the thrift server processor
                ThriftGatewayServerImpl serverHandler = new ThriftGatewayServerImpl();
                var processor = new ThriftAPIGatewayService.AsyncProcessor(serverHandler);

                var protocolFactory = new TBinaryProtocol.Factory();
                var thriftConfiguration = new TConfiguration();
                var serverTransport = new TServerSocketTransport(serverPort, thriftConfiguration);
                var transportFactory = new TBufferedTransport.Factory();
                var threadConfiguration = new TThreadPoolAsyncServer.Configuration();
                var loggerFactory = new SerilogLoggerFactory(Log.Logger);

                var server = new TThreadPoolAsyncServer(
                    processorFactory: new TSingletonProcessorFactory(processor),
                    serverTransport: serverTransport,
                    inputTransportFactory: transportFactory,
                    outputTransportFactory: transportFactory,
                    inputProtocolFactory: protocolFactory,
                    outputProtocolFactory: protocolFactory,
                    threadConfig: threadConfiguration,
                    loggerFactory.CreateLogger<Startup>());

                Log.Information("Starting {0} at port {1}", STR_AppName, serverPort);
                Log.Information(STR_QuitText);

                var source = new CancellationTokenSource();
                server.ServeAsync(CancellationToken.None).GetAwaiter().GetResult();
                Console.ReadLine();
                source.Cancel();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Startup terminated unexpectedly ({ApplicationContext})!", STR_AppName);
            }
        }


        private static IHost CreateHostBuilder(IConfiguration configuration, Serilog.ILogger logger)
        {
            var builder = Host.CreateDefaultBuilder()
                              .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
                              .UseSerilog(logger, configuration)
                              .UseContentRoot(Directory.GetCurrentDirectory());

            return builder.Build();
        }

        /// <summary>
        /// Factory method for logger generation
        /// </summary> 
        private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                                  .WriteTo.Console()
                                  .WriteTo.File("D:\\Logs\\ThriftAPIGateway\\log-.txt", rollingInterval: RollingInterval.Hour)
                                  .CreateLogger();

            return Log.Logger;
        }

        /// <summary>
        /// Accesssor for configuration
        /// </summary>
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            return builder.Build();
        }


    }

    public static class SerilogHostBuilderExtensions
    {
        public static IHostBuilder UseSerilog(this IHostBuilder builder,
            Serilog.ILogger logger = null, IConfiguration configuration = null, bool dispose = false)
        {
            builder.ConfigureServices((context, collection) =>
                collection.Configure<IConfiguration>(configuration).AddSingleton<ILoggerFactory>(services => new SerilogLoggerFactory(logger, dispose)));
            return builder;
        }
    }

    public class SerilogLoggerFactory : ILoggerFactory
    {
        private readonly SerilogLoggerProvider _provider;

        public SerilogLoggerFactory(Serilog.ILogger logger = null, bool dispose = false)
        {
            _provider = new SerilogLoggerProvider(logger, dispose);
        }

        public void Dispose() => _provider.Dispose();

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return _provider.CreateLogger(categoryName);
        }

        public void AddProvider(ILoggerProvider provider)
        {
            // Only Serilog provider is allowed!
            SelfLog.WriteLine("Ignoring added logger provider {0}", provider);
        }
    }
}
