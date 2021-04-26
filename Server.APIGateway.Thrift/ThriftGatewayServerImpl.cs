/* 
 *  Author: Fikri Aydemir
 *  Date  :	10/04/2020 15:14
 *  
 *  Released under MIT License
 *
 */


using APIGateway.Thrift.Generated.KafkaTypes;
using APIGateway.Thrift.Generated.NotificationTypes;
using APIGateway.Thrift.Generated.Services;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server.APIGateway.Thrift
{
    /// <summary>
    /// Claz GrpcGatewayServerImpl  
    /// </summary> 
    public class ThriftGatewayServerImpl : ThriftAPIGatewayService.IAsync
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<ThriftGatewayServerImpl>();

        /// <summary>
        /// Ctor for Class GrpcGatewayServerImpl 
        /// </summary>  
        public ThriftGatewayServerImpl()
        {
        }

        /// <summary>
        /// Inserts message to kafka
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="cancellationToken">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client 
        public async Task<KafkaInsertResponse> InsertFromKafkaAsync(KafkaInsertRequest request, CancellationToken cancellationToken = default)
        {
            var kafkaInsertResponse = new KafkaInsertResponse();
            DoFibonacci();
            Log.Information("Insert Kafka is successful!");
            kafkaInsertResponse.Success = true;
            kafkaInsertResponse.Value = 0;
            return kafkaInsertResponse;
        }

        /// <summary>
        /// Sends Notification
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="cancellationToken">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public async Task<NotificationQueueResponse> SendNotificationAsync(NotificationQueueRequest request, CancellationToken cancellationToken = default)
        {
            var notificationQueueResponse = new NotificationQueueResponse();
            DoFibonacci();
            Log.Information("Send Notfication is successful!");
            notificationQueueResponse.Success = true;
            notificationQueueResponse.Value = 0;
            return notificationQueueResponse;
        }

        private void DoFibonacci()
        {
            Random random = new Random();
            int n1 = 0, n2 = 1, n3, i, number;
            number = random.Next(0, 1000000);
            for (i = 2; i < number; ++i)
            {
                n3 = n1 + n2;
                n1 = n2;
                n2 = n3;
            }
        }
    }
}
