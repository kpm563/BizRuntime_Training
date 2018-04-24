package consumer;

import io.openmessaging.Message;
import io.openmessaging.MessageHeader;
import io.openmessaging.MessagingAccessPoint;
import io.openmessaging.MessagingAccessPointFactory;
import io.openmessaging.OMS;
import io.openmessaging.PullConsumer;
import io.openmessaging.rocketmq.domain.NonStandardKeys;

public class OpenMessagingConsumer {

	 public static void main(String[] args) {
	        final MessagingAccessPoint messagingAccessPoint = MessagingAccessPointFactory
	            .getMessagingAccessPoint("openmessaging:rocketmq://192.168.1.111:9876,192.168.1.112:9876/namespace");

	        final PullConsumer consumer = messagingAccessPoint.createPullConsumer("OMS_HELLO_TOPIC",
	            OMS.newKeyValue().put(NonStandardKeys.CONSUMER_GROUP, "OMS_CONSUMER"));

	        messagingAccessPoint.startup();
	        System.out.printf("MessagingAccessPoint startup OK%n");
	        
	        consumer.startup();
	        System.out.printf("Consumer startup OK%n");

	        Message message = consumer.poll();
	        if (message != null) {
	            String msgId = message.headers().getString(MessageHeader.MESSAGE_ID);
	            System.out.printf("Received one message: %s%n", msgId);
	            consumer.ack(msgId);
	        }

	        consumer.shutdown();
	        messagingAccessPoint.shutdown();
	    }
}
