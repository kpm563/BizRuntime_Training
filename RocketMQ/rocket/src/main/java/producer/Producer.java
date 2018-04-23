package producer;

import org.apache.rocketmq.client.exception.MQClientException;
import org.apache.rocketmq.client.producer.DefaultMQProducer;
import org.apache.rocketmq.client.producer.SendResult;
import org.apache.rocketmq.common.message.Message;
import org.apache.rocketmq.remoting.common.RemotingHelper;

public class Producer {

	public static void main(String[] args) throws MQClientException, InterruptedException {
		// TODO Auto-generated method stub
		
		DefaultMQProducer producer = new DefaultMQProducer("ProducerGroup");
		
		
		producer.start();
		
		for (int i = 0; i < 1000; i++) {
			try {
				Message msg = new Message("TopicTest", "TagA", ("Hello RocketMQ "+i).getBytes(RemotingHelper.DEFAULT_CHARSET));
				
				SendResult sendResult = producer.send(msg);
				
				System.out.printf("%s%n", sendResult);				
			}
			catch (Exception e) {
				// TODO: handle exception
				e.printStackTrace();
				Thread.sleep(1000);
			}
		}

		producer.shutdown();
	}

}
