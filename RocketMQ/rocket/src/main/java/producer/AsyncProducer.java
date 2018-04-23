package producer;

import org.apache.rocketmq.client.producer.DefaultMQProducer;
import org.apache.rocketmq.client.producer.SendCallback;
import org.apache.rocketmq.client.producer.SendResult;
import org.apache.rocketmq.common.message.Message;
import org.apache.rocketmq.remoting.common.RemotingHelper;

public class AsyncProducer {

	public static void main(String[] args) throws Exception{
		// TODO Auto-generated method stub

		
		DefaultMQProducer producer = new DefaultMQProducer("AsyncProducerGroup");
		
		producer.start();
		
		producer.setRetryTimesWhenSendAsyncFailed(0);
		
		for (int i = 0; i < 100; i++) {
			final int index = i;
			
			Message msg = new Message("TopicTest", "TagA", "OrderID188", "Hello world".getBytes(RemotingHelper.DEFAULT_CHARSET));
			
			producer.send(msg, new SendCallback() {
				public void onSuccess(SendResult sendResult) {
					// TODO Auto-generated method stub
					
					System.out.printf("%-10d OK %s %n", index,
                            sendResult.getMsgId());					
				}
				
				public void onException(Throwable e) {
					// TODO Auto-generated method stub
					 System.out.printf("%-10d Exception %s %n", index, e);
                     e.printStackTrace();
					
				}
			});			
		}
		producer.shutdown();		
	}

}
