using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.lang;
using java.util;
using java.util.concurrent.atomic;
using org.apache.rocketmq.client.consumer.listener;

namespace Consume
{
    class OrderedListener : MessageListenerOrderly
    {
        AtomicLong consumeTimes = new AtomicLong(0);

        public ConsumeOrderlyStatus consumeMessage(List list, ConsumeOrderlyContext context)
        {
            //throw new NotImplementedException();

            context.setAutoCommit(false);
            Console.WriteLine(Thread.currentThread().getName() + " Receive new messages :: " + list + " \n");
            this.consumeTimes.incrementAndGet();
            if ((this.consumeTimes.get() % 2) == 0)
            {
                return ConsumeOrderlyStatus.SUCCESS;
            }
            else if ((this.consumeTimes.get() % 3) == 0)
            {
                return ConsumeOrderlyStatus.ROLLBACK;
            }
            else if ((this.consumeTimes.get() % 4) == 0)
            {
                return ConsumeOrderlyStatus.COMMIT;
            }
            else if ((this.consumeTimes.get() % 5) == 0)
            {
                context.setSuspendCurrentQueueTimeMillis(3000);
                return ConsumeOrderlyStatus.SUSPEND_CURRENT_QUEUE_A_MOMENT;
            }
            return ConsumeOrderlyStatus.SUCCESS;
        }
    }
}
