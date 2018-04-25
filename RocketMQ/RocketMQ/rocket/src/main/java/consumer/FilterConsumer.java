package consumer;

import java.io.File;
import java.util.List;

import org.apache.rocketmq.client.consumer.DefaultMQPushConsumer;
import org.apache.rocketmq.client.consumer.listener.ConsumeConcurrentlyContext;
import org.apache.rocketmq.client.consumer.listener.ConsumeConcurrentlyStatus;
import org.apache.rocketmq.client.consumer.listener.MessageListenerConcurrently;
import org.apache.rocketmq.common.MixAll;
import org.apache.rocketmq.common.message.MessageExt;

public class FilterConsumer {

	public static void main(String[] args) throws Exception{
		// TODO Auto-generated method stub
		
		//DefaultMQProducer consumer  = new DefaultMQProducer("FilterConsumerGroup");
		DefaultMQPushConsumer consumer = new DefaultMQPushConsumer("FilterConsumerGroup");
		
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		File classFile = new File(classLoader.getResource("MessageFilterImpl.java").getFile());
		
		String filterCode = MixAll.file2String(classFile);
		consumer.subscribe("TopicFilter", "consumer.MessageFilterImpl", filterCode);
		
		consumer.registerMessageListener(new MessageListenerConcurrently() {
			
			@Override
			public ConsumeConcurrentlyStatus consumeMessage(List<MessageExt> msgs, ConsumeConcurrentlyContext context) {
				// TODO Auto-generated method stub
				//return null;
				
				System.out.printf("%s Receive New Messages: %s %n", Thread.currentThread().getName(), msgs);
				return ConsumeConcurrentlyStatus.CONSUME_SUCCESS;
			}
		});
		
		consumer.start();
		System.out.println("Consumer Started....");
	}

}
