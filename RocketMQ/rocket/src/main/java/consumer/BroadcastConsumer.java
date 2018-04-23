package consumer;

import java.util.List;

import org.apache.rocketmq.client.consumer.DefaultMQPushConsumer;
import org.apache.rocketmq.client.consumer.listener.ConsumeConcurrentlyContext;
import org.apache.rocketmq.client.consumer.listener.ConsumeConcurrentlyStatus;
import org.apache.rocketmq.client.consumer.listener.MessageListenerConcurrently;
import org.apache.rocketmq.common.message.MessageExt;
import org.apache.rocketmq.common.protocol.heartbeat.MessageModel;

public class BroadcastConsumer {

	public static void main(String[] args) throws Exception {
		// TODO Auto-generated method stub

		DefaultMQPushConsumer consumer = new DefaultMQPushConsumer("BroadcastGroup");
		
		consumer.setMessageModel(MessageModel.BROADCASTING);
		
		consumer.subscribe("TopicTest", "TagA || TagC || TagD");
		
		consumer.registerMessageListener(new MessageListenerConcurrently() {
			
			public ConsumeConcurrentlyStatus consumeMessage(List<MessageExt> msgs, ConsumeConcurrentlyContext context) {
				// TODO Auto-generated method stub
				//return null;
				
				System.out.printf(Thread.currentThread().getName() + " Receive New Messages: " + msgs + "%n");
                return ConsumeConcurrentlyStatus.CONSUME_SUCCESS;
			}		
		});
		consumer.start();
		System.out.printf("Broadcast Consumer Started.%n");
	}

}
