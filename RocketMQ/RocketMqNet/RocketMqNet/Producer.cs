using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using org.apache.rocketmq.client.producer;
using org.apache.rocketmq.common.message;

namespace RocketMqNet
{
    class Producer
    {
        public void ProducerMethod()
        {
            DefaultMQProducer producer = new DefaultMQProducer("ProducerGroup");

            //producer.setNamesrvAddr(" 192.168.100.3:9876 ");

            producer.start();


            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Message msg = new Message("TopicTest", "TagA", Encoding.Default.GetBytes("Hello world"));
                    SendResult sendResult = producer.send(msg);
                    Console.WriteLine("%s%n" + sendResult);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(1000);
                }
            }
            producer.shutdown();
        }

    }
}
