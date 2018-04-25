using org.apache.rocketmq.client.producer;
using org.apache.rocketmq.common.message;
using System;
using System.Text;

namespace Produce
{
    class Broadcast
    {
        public void Producer()
        {
            DefaultMQProducer producer = new DefaultMQProducer("Broadcast");
            producer.start();


            //string[] tags = new string[]{ "TagA", "TagB", "TagC", "TagD" }; 
            for (int i = 0; i < 100; i++)
            {
                Message message = new Message("TopicBroadcast", /* tags[i%tags.Length], */ "OrderID188", Encoding.Default.GetBytes("Hello world"));

                SendResult sendResult = producer.send(message);
                Console.WriteLine(sendResult);
            }
            producer.shutdown();
        }
    }
}
