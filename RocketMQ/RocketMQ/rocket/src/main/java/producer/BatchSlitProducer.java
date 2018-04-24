package producer;

import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.rocketmq.client.producer.DefaultMQProducer;
import org.apache.rocketmq.common.message.Message;

public class BatchSlitProducer implements Iterator<List<Message>>{
	
	private final int SIZE_LIMIT = 1000*1000;
	private final List<Message> messages;
	private int currIndex;
	DefaultMQProducer producer = new DefaultMQProducer("BatchProducerGroup");
		
	public BatchSlitProducer(List<Message> messages) {
		// TODO Auto-generated constructor stub
		this.messages=messages;
	}
	

	@Override
	public boolean hasNext() {
		// TODO Auto-generated method stub
		//return false;
		return currIndex < messages.size();
	}



	@Override
	public List<Message> next() {
		// TODO Auto-generated method stub
		//return null;
		int nextIndex = currIndex;
		int totalSize =0;
		for (; nextIndex<messages.size(); nextIndex++) {
			Message message = messages.get(nextIndex);
			int tmpSize = message.getTopic().length() + message.getBody().length;
			Map<String, String> properties  = message.getProperties();
			for(Map.Entry<String, String> entry : properties.entrySet()) {
				tmpSize += entry.getKey().length() + entry.getValue().length();
			}
			tmpSize = tmpSize+20;
			if(tmpSize>SIZE_LIMIT) {
				if(nextIndex - currIndex==0) {
					nextIndex++;
				}
				break;
			}
			if(tmpSize + totalSize > SIZE_LIMIT) {
				break;
			}
			else {
				totalSize += tmpSize;
			}
		}
		List<Message> subList  = messages.subList(currIndex, nextIndex);
		currIndex = nextIndex;
		return subList;		
	}

	public void BatchSplitMethod() {
		BatchSlitProducer splitter = new BatchSlitProducer(messages);
		while (splitter.hasNext()) {
		   try {
		       List<Message>  listItem = splitter.next();
		       producer.send(listItem);
		   } 
		   catch (Exception e) {
		       e.printStackTrace();
		   }
		}	
	}

}
