using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Tutorial13.Entities
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Client> Customer { get; set; }
        public DbSet<ClientOrder> Order { get; set; }
        public DbSet<Confectionery> Confectionery { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Confectionery_ClientOrder> Confectionery_Order { get; set; }

        public CustomerDbContext()
        {

        }

        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);
                entity.Property(e => e.IdClient).ValueGeneratedOnAdd();

                entity.HasMany(d => d.Orders).WithOne(p => p.Client).HasForeignKey(p => p.IdClient).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmpl);
                entity.Property(e => e.IdEmpl).ValueGeneratedOnAdd();

                entity.HasMany(d => d.Orders).WithOne(p => p.Employee).HasForeignKey(p => p.IdEmpl).IsRequired();
            });

            modelBuilder.Entity<Confectionery>(entity =>
            {
                entity.HasKey(e => e.IdConectionery);
                entity.Property(e => e.IdConectionery).ValueGeneratedOnAdd();

                entity.HasMany(d => d.Conf_orders).WithOne(p => p.Conf).HasForeignKey(p => p.IdConfection).IsRequired();
            });

            modelBuilder.Entity<ClientOrder>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.Property(e => e.IdOrder).ValueGeneratedOnAdd();

                entity.HasMany(d => d.Сonf_orders).WithOne(p => p.Order).HasForeignKey(p => p.IdOrder).IsRequired();
            });

            modelBuilder.Entity<Confectionery_ClientOrder>(entity =>
            {
                entity.HasKey(e => new {e.IdOrder, e.IdConfection });
            });

            Client customer = new Client { IdClient = 1, Name = "John", Surname = "Doe" };
            Employee employee = new Employee { IdEmpl = 1, FirstName = "Jonny", LastName = "Dough" };
            ClientOrder order = new ClientOrder { IdOrder = 1, DateAccepted = new DateTime(2020, 03, 23), DateFinished = new DateTime(2020, 03, 27), Notes = "gibberish", IdClient = customer.IdClient, IdEmpl = employee.IdEmpl };
            Confectionery conf = new Confectionery { IdConectionery = 1, Name = "whatever", PricePerItem = 2.34, Type = "gud"};
            modelBuilder.Entity<Client>().HasData(customer );
            modelBuilder.Entity<Employee>().HasData(employee);
            modelBuilder.Entity<ClientOrder>().HasData(order);
            modelBuilder.Entity<Confectionery>().HasData(conf);
            modelBuilder.Entity<Confectionery_ClientOrder>().HasData(new Confectionery_ClientOrder {IdConfection = 1, IdOrder = 1,  Quantity = 3, Notes = "noted"});

            Client customer1 = new Client { IdClient = 2, Name = "Steve", Surname = "Do" };
            Employee employee1 = new Employee { IdEmpl = 2, FirstName = "Steven", LastName = "Dou" };
            ClientOrder order1 = new ClientOrder { IdOrder = 2, DateAccepted = new DateTime(2020, 05, 13), DateFinished = new DateTime(2020, 05, 17), Notes = "NotesHere", IdClient = customer1.IdClient, IdEmpl = employee1.IdEmpl };
            Confectionery conf1 = new Confectionery { IdConectionery = 2, Name = "nme", PricePerItem = 2.56, Type = "okei" };
            modelBuilder.Entity<Client>().HasData(customer1);
            modelBuilder.Entity<Employee>().HasData(employee1);
            modelBuilder.Entity<ClientOrder>().HasData(order1);
            modelBuilder.Entity<Confectionery>().HasData(conf1);
            modelBuilder.Entity<Confectionery_ClientOrder>().HasData(new Confectionery_ClientOrder { IdConfection = 2, IdOrder = 2, Quantity = 4, Notes = "NOTED" });
        }
    }
}
