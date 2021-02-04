using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace MesPremiersTestsAvecEntitiesCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //1-Construction
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json");

            var config = builder.Build();


            //2-Récupération connectionString
            string connectionString = config.GetConnectionString("DefaultContext");

            //3-On définit l'OptionsBuilder
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);

            using (DefaultContext context = new DefaultContext(optionsBuilder.Options))
            {
                var query = from droide in context.Droides select droide;

                foreach (var item in query.ToList())
                {
                    Console.WriteLine(item.Matricule);
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
