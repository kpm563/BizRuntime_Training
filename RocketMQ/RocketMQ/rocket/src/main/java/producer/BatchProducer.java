package producer;

import java.util.ArrayList;
import java.util.List;

import org.apache.rocketmq.client.producer.DefaultMQProducer;
import org.apache.rocketmq.common.message.Message;

public class BatchProducer {

	public static void main(String[] args) throws Exception{
		// TODO Auto-generated method stub

		DefaultMQProducer producer = new DefaultMQProducer("BatchProducerGroup");
		producer.start();
		
		String topic = "BatchTest";
		List<Message> messages = new ArrayList<>(); //Message
		
		messages.add(new Message(topic, "TagA", "OrderID001", "Hello world 0".getBytes()));
		messages.add(new Message(topic, "TagA", "OrderID002", "Hello world 1".getBytes()));
		messages.add(new Message(topic, "TagA", "OrderID003", "Hello world 2".getBytes()));
		
		try {
			producer.send(messages);			
		}
		catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
			//Thread.sleep(1000);
		}
		producer.shutdown();
	}

}
