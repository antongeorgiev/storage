﻿using Microsoft.Azure.ServiceBus;

namespace Storage.Net.Microsoft.Azure.ServiceBus.Messaging
{
   /// <summary>
   /// Implements message receiver on Azure Service Bus Queues
   /// </summary>
   class AzureServiceBusTopicReceiver : AzureServiceBusReceiver
   {
      //https://github.com/Azure/azure-service-bus/blob/master/samples/DotNet/Microsoft.Azure.ServiceBus/ReceiveSample/readme.md

      public AzureServiceBusTopicReceiver(string connectionString, string topicName, string subscriptionName, bool peekLock = true, MessageHandlerOptions handlerOptions = null)
         : base(CreateClient(connectionString, topicName, subscriptionName, peekLock), peekLock, handlerOptions)
      {
      }

      private static SubscriptionClient CreateClient(string connectionString, string topicName, string subscriptionName, bool peekLock)
      {
         return new SubscriptionClient(connectionString, topicName, subscriptionName, peekLock ? ReceiveMode.PeekLock : ReceiveMode.ReceiveAndDelete);
      }
   }
}
