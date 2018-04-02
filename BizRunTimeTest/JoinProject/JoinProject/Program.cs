using System;
using System.Data.SqlClient;

namespace JoinProject
{
    /// <summary>
    /// This clas is having all the implementation of Inner join, left outer join, Right outer join, and full join.
    /// </summary>
    class Program
    {
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        SqlConnection connection = null;

        /// <summary>
        /// Using this method we will be able to onen connection to the DB.Then only we will be able to perform any operation
        /// </summary>
        public void OpenConnection()
        {
            try
            {
                string address = @"Data Source=.\SQLSERVER;Initial Catalog=BizRuntime;Persist Security Info=True;User ID=sa;Password=prince";
                connection = new SqlConnection(address);
                connection.Open();
                log.Info("Connected to DB!");
            }
            catch (Exception e)
            {
                log.Error("Error :: " + e.Message);
            }
        }

        /// <summary>
        /// This method will be able to perform oepration of Inner join only.
        /// </summary>
        public void InnerJoin()
        {
            string conString = @"SELECT Customers.CustomerId, Customers.CustomerName, Customers.CustomerAge, Orders.OrderId,  Orders.OrderName, Orders.Price FROM Orders INNER JOIN Customers ON Orders.CustomerId=Customers.CustomerId";

            try
            {
                SqlCommand command = new SqlCommand(conString, connection);
                SqlDataReader reader = command.ExecuteReader();

                for (int i = 1; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t ");
                }

                Console.WriteLine("\n========================================================================================");

                while (reader.Read())
                {
                    for (int i = 1; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t       ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("========================================================================================");
            }
            catch (Exception e)
            {
                log.Error("Error :: " + e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        /// <summary>
        /// This method will be able to perform operation of self join.
        /// </summary>
        public void SelfJoin()
        {
            string conString = @"SELECT A.CustomerId AS CustomerId, A.CustomerName AS CustomerA, B.CustomerName AS CustomerB, A.CustomerAddress FROM Customers A, Customers B WHERE A.CustomerId < B.CustomerId";
            try
            {
                SqlCommand command = new SqlCommand(conString, connection);
                SqlDataReader reader = command.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t ");
                }

                Console.WriteLine("\n========================================================================================");

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t       ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("========================================================================================");
            }
            catch (Exception e)
            {
                log.Error("Error :: " + e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }


        /// <summary>
        /// This method will be able to perform operation of Left outer join.
        /// </summary>
        public void LeftOuterJoin()
        {
            string conString = @"SELECT Customers.CustomerId, Customers.CustomerName, Customers.CustomerAge, Orders.OrderId,  Orders.OrderName, Orders.Price FROM Customers LEFT JOIN Orders ON Customers.CustomerId=Orders.CustomerId";
            try
            {
                SqlCommand command = new SqlCommand(conString, connection);
                SqlDataReader reader = command.ExecuteReader();

                for (int i = 1; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t ");
                }

                Console.WriteLine("\n========================================================================================");

                while (reader.Read())
                {
                    for (int i = 1; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t       ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("========================================================================================");
            }
            catch (Exception e)
            {
                log.Error("Error :: " + e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// This method will be able to perform operation of Right outer join.
        /// </summary>
        public void RightOuterJoin()
        {
            string conString = @"SELECT Customers.CustomerId, Customers.CustomerName, Customers.CustomerAge, Orders.OrderId,  Orders.OrderName, Orders.Price FROM Customers RIGHT JOIN Orders ON Customers.CustomerId=Orders.CustomerId";
            try
            {
                SqlCommand command = new SqlCommand(conString, connection);
                SqlDataReader reader = command.ExecuteReader();

                for (int i = 1; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t ");
                }

                Console.WriteLine("\n========================================================================================");

                while (reader.Read())
                {
                    for (int i = 1; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t       ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("========================================================================================");
            }
            catch (Exception e)
            {
                log.Error("Error :: " + e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// This method will be able to perform operation of Full outer join.
        /// </summary>
        public void FullOuterJoin()
        {
            string conString = @"SELECT Customers.CustomerId, Customers.CustomerName, Customers.CustomerAge, Orders.OrderId,  Orders.OrderName, Orders.Price FROM Customers FULL OUTER JOIN Orders ON Customers.CustomerId=Orders.CustomerId";
            try
            {
                SqlCommand command = new SqlCommand(conString, connection);
                SqlDataReader reader = command.ExecuteReader();

                for (int i = 1; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t ");
                }

                Console.WriteLine("\n========================================================================================");

                while (reader.Read())
                {
                    for (int i = 1; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t       ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("========================================================================================");
            }
            catch (Exception e)
            {
                log.Error("Error :: " + e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// This Main method is the entry point of the whole application.which take an argument of string type.
        /// </summary>
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            Program obj = new Program();
            obj.OpenConnection();
            //obj.InnerJoin();
            //obj.SelfJoin();
            //obj.LeftOuterJoin();
            //obj.RightOuterJoin();
            //obj.FullOuterJoin();

            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
