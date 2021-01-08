using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Management
{
    public class Job
    {
        public int id;

        public string name;

        public string description;

        public string color;

        public int status;

        public DateTime start_time;

        public DateTime end_time;

        public DateTime created_time;

        public DateTime modified_time;

        public Job()
        {
            id = 0;
            name = "";
            description = "";
            color = "rgb(255,255,255)";
            status = 2;
        }

        public Job(int _id, string _name, string _desc, string _color, int _status, string _created_time = "now", string _modified_time = "now", string _start_time = "null", string _end_time = "null")
        {
            id = _id;
            name = _name;
            description = _desc;
            color = _color;
            status = _status;

            if (_start_time == "null")
            {
                start_time = DateTime.Parse("31/12/2099");
            }
            else
            {
                start_time = DateTime.Parse(_start_time);
            }

            if (_end_time == "null")
            {
                end_time = DateTime.Parse("31/12/2099");
            }
            else
            {
                end_time = DateTime.Parse(_end_time);
            }

            if (_created_time == "now")
            {
                created_time = DateTime.Now;
            }
            else
            {
                created_time = DateTime.Parse(_created_time);
            }

            if (_modified_time == "now")
            {
                modified_time = DateTime.Now;
            }
            else
            {
                modified_time = DateTime.Parse(_modified_time);
            }

        }
    }
}
