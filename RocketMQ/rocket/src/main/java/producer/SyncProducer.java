package producer;

import org.apache.rocketmq.client.producer.DefaultMQProducer;
import org.apache.rocketmq.client.producer.SendResult;
import org.apache.rocketmq.common.message.Message;
import org.apache.rocketmq.remoting.common.RemotingHelper;

public class SyncProducer {

	public static void main(String[] args) throws Exception  {
		// TODO Auto-generated method stub

		
		DefaultMQProducer producer  = new DefaultMQProducer("rocketmq_group");
		
		producer.start();
		
		for (int i = 0; i < 100; i++) {
			Message msg = new Message("TopicTest", "TagA", ("Hello RocketMQ "+i).getBytes(RemotingHelper.DEFAULT_CHARSET));
			
			SendResult sendResult = producer.send(msg);
			System.out.printf("%s%n", sendResult);
		}
		
		producer.shutdown();
	}

}
