using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.lang;
using java.util;
using org.apache.rocketmq.client.producer;
using org.apache.rocketmq.common.message;


namespace Produce
{
    class QueueSelector : MessageQueueSelector
    {
        public MessageQueue @select(List list, Message msg, object obj)
        {
            //throw new NotImplementedException();

            int id = Convert.ToInt32(obj);
            int size = list.size();

            int index = id % size;

            return (MessageQueue) list.get(index);
        }
    }
}
