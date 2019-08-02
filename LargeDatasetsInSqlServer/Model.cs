using Microsoft.EntityFrameworkCore;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LargeDatasetsInSqlServer
{
    public class UrlClickContext : DbContext
    {
        public DbSet<UrlClicks> urlClicks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //local localdb SQL Database
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=Criteo10GB_EF;Integrated Security=True;Pooling=False";

            //Azure SQL DB (General Purpose: Serverless, Gen5, 4 vCores)   

            //This is using Criteo10GB_EF database with the UrlClickId column ID needed by EF.
            string connectionString = @"Server=tcp:mlnetdatasetsserverless.database.windows.net,1433; Initial Catalog = Criteo10GB_EF; Persist Security Info = False; User ID = YOUR_USER; Password = YOUR_PASSWORD; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            //NO retries
            //optionsBuilder.UseSqlServer(connectionString);

            //Using EF retries with exponential backoff
            //
            optionsBuilder.UseSqlServer(connectionString,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            });
        }
    }
    public class UrlClicks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UrlClickId { get; set; }
        public string Label { get; set; }
        public string Feat01 { get; set; }
        public string Feat02 { get; set; }
        public string Feat03 { get; set; }
        public string Feat04 { get; set; }
        public string Feat05 { get; set; }
        public string Feat06 { get; set; }
        public string Feat07 { get; set; }
        public string Feat08 { get; set; }
        public string Feat09 { get; set; }
        public string Feat10 { get; set; }
        public string Feat11 { get; set; }
        public string Feat12 { get; set; }
        public string Feat13 { get; set; }
        public string Cat14 { get; set; }
        public string Cat15 { get; set; }
        public string Cat16 { get; set; }
        public string Cat17 { get; set; }
        public string Cat18 { get; set; }
        public string Cat19 { get; set; }
        public string Cat20 { get; set; }
        public string Cat21 { get; set; }
        public string Cat22 { get; set; }
        public string Cat23 { get; set; }
        public string Cat24 { get; set; }
        public string Cat25 { get; set; }
        public string Cat26 { get; set; }
        public string Cat27 { get; set; }
        public string Cat28 { get; set; }
        public string Cat29 { get; set; }
        public string Cat30 { get; set; }
        public string Cat31 { get; set; }
        public string Cat32 { get; set; }
        public string Cat33 { get; set; }
        public string Cat34 { get; set; }
        public string Cat35 { get; set; }
        public string Cat36 { get; set; }
        public string Cat37 { get; set; }
        public string Cat38 { get; set; }
        public string Cat39 { get; set; }
    }



}
