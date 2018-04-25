using java.lang;
using java.util;
using org.apache.rocketmq.client.consumer;
using org.apache.rocketmq.client.consumer.listener;
using org.apache.rocketmq.common.protocol.heartbeat;
using System;

namespace Consume
{
    class Broadcast
    {
        public void Consumer()
        {
            DefaultMQPushConsumer consumer = new DefaultMQPushConsumer("BroadcastConsumer");

            consumer.setMessageModel(MessageModel.BROADCASTING);

            consumer.subscribe("TopicBroadcast", "*");

            consumer.registerMessageListener(new MessageListener());

            consumer.start();
            Console.WriteLine("Consumer started .....");
        }

    }
   
}
