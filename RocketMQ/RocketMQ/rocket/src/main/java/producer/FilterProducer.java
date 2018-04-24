package producer;

import org.apache.rocketmq.client.producer.DefaultMQProducer;
import org.apache.rocketmq.client.producer.SendResult;
import org.apache.rocketmq.common.message.Message;
import org.apache.rocketmq.remoting.common.RemotingHelper;

public class FilterProducer {

	public static void main(String[] args) throws Exception {
		// TODO Auto-generated method stub

		DefaultMQProducer producer = new DefaultMQProducer("FilterGroup");
		producer.start();
		
		try {
			for (int i = 0; i < 6000000; i++) {
                Message msg = new Message("TopicFilter7",
                    "TagA",
                    "OrderID001",
                    "Hello world".getBytes(RemotingHelper.DEFAULT_CHARSET));

                msg.putUserProperty("SequenceId", String.valueOf(i));
                SendResult sendResult = producer.send(msg);
                System.out.printf("%s%n", sendResult);			
				} 	
			}
			catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		producer.shutdown();
	}
}
