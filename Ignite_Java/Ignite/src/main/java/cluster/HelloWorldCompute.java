package cluster;

import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCache;
import org.apache.ignite.Ignition;
import org.apache.ignite.cache.CacheAtomicityMode;
import org.apache.ignite.configuration.CacheConfiguration;
import org.apache.ignite.transactions.Transaction;

public class HelloWorldCompute {

	public void helloWorldCompute() throws InterruptedException{
		try(Ignite ignite = Ignition.start()){
			ignite.compute().broadcast(()-> System.out.println("Hello World!!!"));
		}
	}
	
	public void helloWorldCache() {
		
		try(Ignite ignite = Ignition.start()){
		IgniteCache<String, String> cache = ignite.getOrCreateCache("cache");
		
		String key = "key";
		String val = "Hello";
		
		cache.put(key, cache.get(key) + " World!!!");
		
		
		System.out.println(cache.get(key));
		}
	}
	
	public void cacheTransaction() {
		try(Ignite ignite = Ignition.start()){
			CacheConfiguration<String, String> config = new CacheConfiguration<>();
			config.setAtomicityMode(CacheAtomicityMode.TRANSACTIONAL);
			IgniteCache<String, String> cache = ignite.getOrCreateCache(config);
			
			String key = "key";
			String val = "Hello";
			cache.put(key, val);
			
			try(Transaction tx  = ignite.transactions().txStart()){
				cache.put(key, cache.get(key)+" World!!!");
				tx.commit();
			}
			
			System.out.println(cache.get(key));
		}
	}
		
	
	public static void main(String[] args) throws InterruptedException {
		HelloWorldCompute object = new HelloWorldCompute();
		object.helloWorldCompute();
		object.helloWorldCache();
		object.cacheTransaction();
	}
}

