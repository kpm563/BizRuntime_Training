using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.apache.rocketmq.client.consumer;
using org.apache.rocketmq.common.consumer;

namespace Consume
{
    class Consumer
    {
        public void ConsumerMethod()
        {
            DefaultMQPushConsumer consumer = new DefaultMQPushConsumer("ConsumerGroup");
            consumer.setConsumeFromWhere(ConsumeFromWhere.CONSUME_FROM_FIRST_OFFSET);
            consumer.subscribe("TopicTest", "TagA");


            consumer.registerMessageListener(new MessageListener());
            consumer.start();
            Console.WriteLine("Consumer started ......");
        }
    }
}
