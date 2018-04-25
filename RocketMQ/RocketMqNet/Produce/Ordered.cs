using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ikvm.extensions;
using org.apache.rocketmq.client.producer;
using org.apache.rocketmq.common.message;
using org.apache.rocketmq.remoting.common;

namespace Produce
{
    class Ordered
    {
        public void Producer()
        {
            MQProducer producer = new DefaultMQProducer("OrderedGroup");
            //Launch the instance.
            producer.start();
            String[] tags = new String[] { "TagA", "TagB", "TagC", "TagD", "TagE" };
            for (int i = 0; i < 100; i++)
            {
                int orderId = i % 10;
                //Create a message instance, specifying topic, tag and message body.
                Message msg = new Message("TopicTest", tags[i % tags.Length], "KEY" + i,
                    ("Hello RocketMQ " + i).getBytes(RemotingHelper.DEFAULT_CHARSET));


                SendResult sendResult = producer.send(msg,new QueueSelector(),orderId);

                Console.WriteLine(sendResult);
            }
            //server shutdown
            producer.shutdown();
        }
    }
}
