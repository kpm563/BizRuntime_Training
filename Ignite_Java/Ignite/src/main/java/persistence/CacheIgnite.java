package persistence;

import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCache;
import org.apache.ignite.Ignition;
import org.apache.ignite.cache.CacheAtomicityMode;
import org.apache.ignite.configuration.CacheConfiguration;

public class CacheIgnite {
	
	private static final CacheAtomicityMode TRANSACTIONAL = null;

	public void Cache() {
		Ignite ignite = Ignition.ignite();

		// Obtain instance of cache named "myCache".
		// Note that different caches may have different generics.
		IgniteCache<Integer, String> cache = ignite.cache("myCache");
		System.out.println(cache);
	}
	
	
	public void DynamicCache() {
		Ignite ignite = Ignition.ignite();

		CacheConfiguration cfg = new CacheConfiguration();

		cfg.setName("myCache");
		cfg.setAtomicityMode(TRANSACTIONAL);

		// Create cache with given name, if it does not exist.
		IgniteCache<Integer, String> cache = ignite.getOrCreateCache(cfg);
		System.out.println(cache);
	}
	
	public void PutNGet() {
		try (Ignite ignite = Ignition.start("examples/config/example-cache.xml")) {
		    IgniteCache<Integer, String> cache = ignite.cache("myCache");
		 
		    // Store keys in cache (values will end up on different cache nodes).
		    for (int i = 0; i < 10; i++)
		        cache.put(i, Integer.toString(i));
		 
		    for (int i = 0; i < 10; i++)
		        System.out.println("Got [key=" + i + ", val=" + cache.get(i) + ']');
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	public static void main(String[] args) {
		CacheIgnite object = new CacheIgnite();
		//object.Cache();
		//object.DynamicCache();
		object.PutNGet();
	}
	
}
