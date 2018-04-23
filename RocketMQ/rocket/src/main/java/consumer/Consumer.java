package consumer;

import java.util.List;

import org.apache.rocketmq.client.consumer.DefaultMQPushConsumer;
import org.apache.rocketmq.client.consumer.listener.ConsumeConcurrentlyContext;
import org.apache.rocketmq.client.consumer.listener.ConsumeConcurrentlyStatus;
import org.apache.rocketmq.client.consumer.listener.MessageListenerConcurrently;
import org.apache.rocketmq.client.exception.MQClientException;
import org.apache.rocketmq.common.consumer.ConsumeFromWhere;
import org.apache.rocketmq.common.message.MessageExt;

public class Consumer {

	public static void main(String[] args) throws MQClientException {
		// TODO Auto-generated method stub
		
		DefaultMQPushConsumer consumer = new DefaultMQPushConsumer("ProducerGroup");
		
		consumer.setConsumeFromWhere(ConsumeFromWhere.CONSUME_FROM_FIRST_OFFSET);
		
		consumer.subscribe("TopicTest", "*");
		
		consumer.registerMessageListener(new MessageListenerConcurrently() {
			
			public ConsumeConcurrentlyStatus consumeMessage(List<MessageExt> msgs, ConsumeConcurrentlyContext context) {
				// TODO Auto-generated method stub
				return ConsumeConcurrentlyStatus.CONSUME_SUCCESS;
			}
		});
		
		consumer.start();
		System.out.printf("Consumer started.%n");
	}

}
