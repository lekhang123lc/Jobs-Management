using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Jobs_Management
{
    public class JobsModel
    {
        private Database db;

        private string table = "jobs";

        public static JobsModel instance = null;

        public JobsModel()
        {
            db    = Database.getInstance();
        }

        public static JobsModel getInstance()
        {
            if (instance == null)
                instance = new JobsModel();
            return instance;
        }

        public List<Job> getJobs(string search = "")
        {
            string sql = "SELECT * from " + "`"+table+"`";
            MySqlDataReader reader = db.select(sql);
            List<Job> jobs = new List<Job>();

            while (reader.Read())
            {
                Job item = new Job(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));

                jobs.Add(item);
            }
            reader.Close();
            return jobs;
        }

        public Job getJob(int id)
        {
            string sql = "SELECT * from " + "`" + table + "`" + "WHERE id=" + Convert.ToString(id);
            MySqlDataReader reader = db.select(sql);
            List<Job> jobs = new List<Job>();

            while (reader.Read())
            {
                Job item = new Job(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));

                jobs.Add(item);
            }
            reader.Close();
            return jobs[0];
        }

        public void addJob()
        {

        }

        public void updateJob()
        {

        }

        public void deleteJob()
        {

        }
    }
}
