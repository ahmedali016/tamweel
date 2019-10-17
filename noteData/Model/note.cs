namespace noteData.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class note : DbContext
    {
        // Your context has been configured to use a 'note' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'noteData.Model.note' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'note' 
        // connection string in the application configuration file.
        public note()
            : base("name=note")
        {
           
        }
        public DbSet<clients> Client { set; get; }
        public DbSet<clientPhone> ClientPhones { set; get; }
        public DbSet<clientAddress> ClientAddresses { set; get; }
        public DbSet<department> departments { set; get; }
        public DbSet<jobTitle> jobTitles { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}