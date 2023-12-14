using Microsoft.EntityFrameworkCore;
using Sea_Battle;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace MyDB.Scheme
{
    public class DBWorker
    {
        public void AddLines(Info info)
        {
            using (MyDB.Scheme.ApplicationContext db = new MyDB.Scheme.ApplicationContext())
            {

                SeaBattleDBs line = new SeaBattleDBs()
                {
                    DateTimeGameStart = Convert.ToString(info.Start),
                    DateTimeGameEnd = Convert.ToString(info.End),
                    Winner = info.IsPlayerVictory ? "Player" : "Computer",
                    PlayerMovesCount = info.PlayerMovesCount,
                    ComputerMovesCount = info.ComputerMovesCount,
                    FirstMove = info.isPlayerFirstMove ? "Player" : "Computer",
                    PlayerHitsCount = info.PlayerHitsCount,
                    ComputerHitsCount = info.ComputerHitsCount,
                    DidPlayerGiveUp = info.DidPlayerGiveUp ? "Yes" : "No",
                    AlgorithmDifficulty = info.AlgorithmDifficulty
                };
                db.SeaBattleDB.Add(line);
                db.SaveChanges();
            }
        }
        public int FindMaxFreeID()
        {
            int i = 1;
            using (MyDB.Scheme.ApplicationContext db = new MyDB.Scheme.ApplicationContext())
            {
                bool tempb = false;
                while (!tempb)
                {
                    if (db.SeaBattleDB.Find(i) != null)
                    {
                        i++;
                    }
                    else
                    {
                        tempb = true;
                    }
                }
            }
            return i;
        }
    }

    public class SeaBattleDBs
    {
        public int Id { get; set; }
        public string DateTimeGameStart { get; set; }
        public string DateTimeGameEnd { get; set; }
        public string Winner { get; set; }
        public int PlayerMovesCount { get; set; }
        public int ComputerMovesCount { get; set; }
        public string FirstMove { get; set; }
        public int PlayerHitsCount { get; set; }
        public int ComputerHitsCount { get; set; }
        public string DidPlayerGiveUp { get; set; }
        public string AlgorithmDifficulty { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<SeaBattleDBs> SeaBattleDB { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KP_db;Trusted_Connection=true;");
        }
    }
}