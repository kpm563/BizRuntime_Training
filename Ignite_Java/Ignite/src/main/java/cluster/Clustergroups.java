package cluster;

import java.util.Collection;
import java.util.Collections;
import java.util.Map;

import org.apache.ignite.DataRegionMetrics;
import org.apache.ignite.DataStorageMetrics;
import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCluster;
import org.apache.ignite.Ignition;
import org.apache.ignite.cluster.ClusterGroup;
import org.apache.ignite.cluster.ClusterMetrics;
import org.apache.ignite.cluster.ClusterNode;
import org.apache.ignite.configuration.IgniteConfiguration;
//import org.apache.ignite.internal.client.GridClientNode;
import org.apache.ignite.lang.IgnitePredicate;

public class Clustergroups {
	
	static Ignite ignite;
	
	public void RemoteNodes() {
				
		IgniteCluster cluster = ignite.cluster();

		// Cluster group with remote nodes, i.e. other than this node.
		ClusterGroup remoteGroup = cluster.forRemotes();
		
		System.out.println("remote node object :: "+ remoteGroup);
	}
	
	
	public void CacheNodes() {
		//Ignite ignite = Ignition.start();
		IgniteCluster cluster = ignite.cluster();

		// All nodes on which cache with name "myCache" is deployed,
		// either in client or server mode.
		ClusterGroup cacheGroup = cluster.forCacheNodes("myCache");
		System.out.println("Cache Group object :: " + cacheGroup);

		// All data nodes responsible for caching data for "myCache".
		ClusterGroup dataGroup = cluster.forDataNodes("myCache");
		System.out.println("Data Group object :: " + dataGroup);

		// All client nodes that access "myCache".
		ClusterGroup clientGroup = cluster.forClientNodes("myCache");
		System.out.println("Client Group object :: " + clientGroup);
	}
	
	
	public void WithNodeAttributes() {
		IgniteConfiguration cfg = new IgniteConfiguration();

		Map<String, String> attrs = Collections.singletonMap("ROLE", "worker");

		cfg.setUserAttributes(attrs);

		// Start Ignite node.
		Ignite ignite = Ignition.start(cfg);		
		IgniteCluster cluster = ignite.cluster();
		ClusterGroup workerGroup = cluster.forAttribute("ROLE", "worker");
		Collection<ClusterNode> workerNodes = workerGroup.nodes();
		
		System.out.println("Workgroup Current CPU Load :: "+ workerGroup.metrics().getCurrentCpuLoad());
		System.out.println(workerNodes);
	}
	
	
	public void CustomGroup() {
		IgniteCluster cluster = ignite.cluster();

		// Nodes with less than 50% CPU load.
		ClusterGroup readyNodes = cluster.forPredicate(
		    new IgnitePredicate<ClusterNode>() {
		        @Override public boolean apply(ClusterNode node) {
		            return node.metrics().getCurrentCpuLoad() < 0.5;
		        }
		    }
		);
		
		System.out.println("Cluster Group Object :: " +readyNodes);
	}
	
	
	public void ClusterGroupMetrics() {
		// Cluster group with remote nodes, i.e. other than this node.
		ClusterGroup remoteGroup = ignite.cluster().forRemotes();

		// Cluster group metrics.
		ClusterMetrics metrics = remoteGroup.metrics();

		// Get some metric values.
		double cpuLoad = metrics.getCurrentCpuLoad();
		long usedHeap = metrics.getHeapMemoryUsed();
		int numberOfCores = metrics.getTotalCpus();
		int activeJobs = metrics.getCurrentActiveJobs();
		
		
		System.out.println("CPU Load :: " + cpuLoad);
		System.out.println("Used Heap :: " + usedHeap);
		System.out.println("Number of Cores :: " + numberOfCores);
		System.out.println("Active Jobs :: " + activeJobs);
		
	}
	
	
	public void MemoryMetrics() {
		// Get the metrics of all the data regions configured on a node.
		Collection<DataRegionMetrics> regionsMetrics = ignite.dataRegionMetrics();
		            
		// Print out some of the metrics.
		for (DataRegionMetrics metrics : regionsMetrics) {
		    System.out.println(">>> Memory Region Name: " + metrics.getName());
		    System.out.println(">>> Allocation Rate: " + metrics.getAllocationRate());
		    System.out.println(">>> Fill Factor: " + metrics.getPagesFillFactor());
		    System.out.println(">>> Allocated Size: " + metrics.getTotalAllocatedSize());
		    System.out.println(">>> Physical Memory Size: " + metrics.getPhysicalMemorySize());
		}
	}
	
	
	public void GetMemoryMetrics() {
		// Getting metrics.
		DataStorageMetrics pm = ignite.dataStorageMetrics();

		System.out.println("Fsync duration: " + pm.getLastCheckpointFsyncDuration());

		System.out.println("Data pages: " + pm.getLastCheckpointDataPagesNumber());

		System.out.println("Checkpoint duration:" + pm.getLastCheckpointDuration());
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ignite = Ignition.start();
		
		Clustergroups object = new Clustergroups();
		//object.RemoteNodes();
		//object.CacheNodes();
		//object.CustomGroup();
		//object.WithNodeAttributes();
		//object.ClusterGroupMetrics();
		object.MemoryMetrics();
		//object.GetMemoryMetrics();
		
	}

}
