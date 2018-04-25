package producer;

import org.apache.rocketmq.client.exception.MQClientException;
import org.apache.rocketmq.client.producer.DefaultMQProducer;
import org.apache.rocketmq.client.producer.SendResult;
import org.apache.rocketmq.common.message.Message;
import org.apache.rocketmq.remoting.common.RemotingHelper;

public class SqlProducer {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		DefaultMQProducer producer = new DefaultMQProducer("SqlProducerGroup");
		
		try {
			producer.start();
		}
		catch (MQClientException e) {
			// TODO: handle exception
			e.printStackTrace();
			return;
		}
		
		for(int i =0; i<10;i++) {
			try {
				String tag;
				int div = i%3;
				if(div==0) {
					tag="TagA";
				}
				else if (div==1) {
					tag="TagB";
				}
				else {
					tag="TagC";
				}
				Message message = new Message("TopicSqlFilter", tag, ("Hello RocketMQ " + i).getBytes(RemotingHelper.DEFAULT_CHARSET));
				message.putUserProperty("a", String.valueOf(i));
				SendResult sendResult = producer.send(message);
				System.out.println("%s%n" + sendResult);				
			}
			catch (Exception e) {
				// TODO: handle exception
				e.printStackTrace();
				try {
					Thread.sleep(1000);
				}
				catch (InterruptedException e1) {
					// TODO: handle exception
					e1.printStackTrace();
				}
			}
		}
		producer.shutdown();
	}
}
