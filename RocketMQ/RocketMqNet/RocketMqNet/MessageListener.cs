using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.util;
using org.apache.rocketmq.client.consumer.listener;


namespace RocketMqNet
{
    class MessageListener : MessageListenerConcurrently
    {
        public ConsumeConcurrentlyStatus consumeMessage(List list, ConsumeConcurrentlyContext consume)
        {
            //throw new NotImplementedException();
            //for (int i = 0; i < list.size(); i++)
            //{

            //}
            return ConsumeConcurrentlyStatus.CONSUME_SUCCESS;
        }
    }
}
