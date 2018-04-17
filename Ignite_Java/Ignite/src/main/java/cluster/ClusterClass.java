package cluster;

import java.util.Collection;

import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCluster;
import org.apache.ignite.IgniteCompute;
import org.apache.ignite.Ignition;
import org.apache.ignite.cluster.ClusterGroup;
import org.apache.ignite.cluster.ClusterMetrics;
import org.apache.ignite.cluster.ClusterNode;
import org.apache.ignite.lang.IgniteRunnable;

public class ClusterClass {
			
	static Ignite ignite;
	
	public void ClusterActive() {
		ignite = Ignition.ignite();		
		IgniteCluster cluster = ignite.cluster();			  
	   ignite.cluster().active(true);
	}
		
	
	public void Attributes() {
		ignite = Ignition.ignite();
		ClusterGroup workers = ignite.cluster().forAttribute("ROLE", "worker");

		Collection<ClusterNode> nodes = workers.nodes();
	}
	
	
	
	public void ClusterNodes() {
		
		ignite = Ignition.ignite();
		IgniteCluster cluster = ignite.cluster();
		// Local Ignite node.
		ClusterNode localNode = cluster.localNode();

		// Node metrics.
		ClusterMetrics metrics = localNode.metrics();

		// Get some metric values.
		double cpuLoad = metrics.getCurrentCpuLoad();
		long usedHeap = metrics.getHeapMemoryUsed();
		int numberOfCores = metrics.getTotalCpus();
		int activeJobs = metrics.getCurrentActiveJobs();
		
		System.out.println("CPU Load :: " + cpuLoad);
		System.out.println("User Heap :: " + usedHeap);
		System.out.println("No of cores :: " + numberOfCores);
		System.out.println("Active jobs :: " + activeJobs);
		
		System.out.println("Local Node :: " + localNode);	
		
	}
	
	
	public void Broadcast() {		

		IgniteCluster cluster = ignite.cluster();

		// Get compute instance which will only execute
		// over remote nodes, i.e. not this node.
		IgniteCompute compute = ignite.compute(cluster.forRemotes());

		// Broadcast closure only to remote nodes.
		compute.broadcast(new IgniteRunnable() {
		    @Override public void run() {
		        // Print ID of the node on which this runnable is executing.
		        System.out.println(">>> Hello Node: " + ignite.cluster().localNode().id());
		    }
		});
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ignite = Ignition.start();
		
		ClusterClass object = new ClusterClass();
		object.ClusterActive();
		object.Attributes();
		object.ClusterNodes();
		object.Broadcast();
		
	}

}
