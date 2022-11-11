using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.Enums;
namespace RealtimeDatabase
{
    class Program

    { 
        static void Main(string[] args)
        {
           
            using (var tbDenpendency = new SqlTableDependency<Person>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RealTime;Integrated Security=True"))
            {
                tbDenpendency.OnChanged += TbDenpendency_OnChanged;
                tbDenpendency.Start();
                Console.ReadKey();
               
            }

               
        }

        private static void TbDenpendency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Person> e)
        {
            if(e.ChangeType != ChangeType.None)
            {
                var entry = e.Entity;
                Console.WriteLine("Type:" + e.ChangeType);
                Console.WriteLine("ID: " + entry.Id + "Name: " + entry.Name + "Gender: " + entry.Gender);
                
            }
        }
    }
}
