package Ignite.Ignite;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class FirstIgnite {

	Connection conn = null;
	
	public void Getconnection() {
		// Register JDBC driver
		try {
			Class.forName("org.apache.ignite.IgniteJdbcThinDriver");
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		// Open JDBC connection
		try {
			conn = DriverManager.getConnection(
			    "jdbc:ignite:thin://127.0.0.1/");
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	public void CreateTable() {
		
		// Create database tables
		
		try (Statement stmt = conn.createStatement()) {

		    // Create table based on REPLICATED template
		    stmt.executeUpdate("CREATE TABLE City (" + 
		    " id LONG PRIMARY KEY, name VARCHAR) " +
		    " WITH \"template=replicated\"");

		    // Create table based on PARTITIONED template with one backup
		    stmt.executeUpdate("CREATE TABLE Person (" +
		    " id LONG, name VARCHAR, city_id LONG, " +
		    " PRIMARY KEY (id, city_id)) " +
		    " WITH \"backups=1, affinityKey=city_id\"");
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	public void CreateIndexs() {
		// Create indexes
		try (Statement stmt = conn.createStatement()) {

		    // Create an index on the City table
		    stmt.executeUpdate("CREATE INDEX idx_city_name ON City (name)");

		    // Create an index on the Person table
		    stmt.executeUpdate("CREATE INDEX idx_person_name ON Person (name)");
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	public void InsertData() {
		// Populate City table
		try (PreparedStatement stmt =
		conn.prepareStatement("INSERT INTO City (id, name) VALUES (?, ?)")) {

		    stmt.setLong(1, 1L);
		    stmt.setString(2, "Forest Hill");
		    stmt.executeUpdate();

		    stmt.setLong(1, 2L);
		    stmt.setString(2, "Denver");
		    stmt.executeUpdate();

		    stmt.setLong(1, 3L);
		    stmt.setString(2, "St. Petersburg");
		    stmt.executeUpdate();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		// Populate Person table
		try (PreparedStatement stmt =
		conn.prepareStatement("INSERT INTO Person (id, name, city_id) VALUES (?, ?, ?)")) {

		    stmt.setLong(1, 1L);
		    stmt.setString(2, "John Doe");
		    stmt.setLong(3, 3L);
		    stmt.executeUpdate();

		    stmt.setLong(1, 2L);
		    stmt.setString(2, "Jane Roe");
		    stmt.setLong(3, 2L);
		    stmt.executeUpdate();

		    stmt.setLong(1, 3L);
		    stmt.setString(2, "Mary Major");
		    stmt.setLong(3, 1L);
		    stmt.executeUpdate();

		    stmt.setLong(1, 4L);
		    stmt.setString(2, "Richard Miles");
		    stmt.setLong(3, 2L);
		    stmt.executeUpdate();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	public void ShowData() {
		// Get data using an SQL join sample.
		try (Statement stmt = conn.createStatement()) {
		    try (ResultSet rs =
		    stmt.executeQuery("SELECT p.name, c.name " +
		    " FROM Person p, City c " +
		    " WHERE p.city_id = c.id")) {

		      System.out.println("Query result:");

		      while (rs.next())
		         System.out.println(">>>    " + rs.getString(1) +
		            ", " + rs.getString(2));
		    }
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	public void UpdateData() {
		// Update
		try (Statement stmt = conn.createStatement()) {

		    // Update City
		    stmt.executeUpdate("UPDATE City SET name = 'Foster City' WHERE id = 2");
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	
	public void RemoveData() {
		// Delete
		try (Statement stmt = conn.createStatement()) {

		    // Delete from Person
		    stmt.executeUpdate("DELETE FROM Person WHERE name = 'John Doe'");
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
		
	
	
	
	
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		FirstIgnite object = new FirstIgnite();
		object.Getconnection();
		object.CreateTable();
		object.CreateIndexs();
		object.InsertData();
		object.ShowData();
		//object.UpdateData();
		//object.RemoveData();
	}
}
