using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherAPI.Models
{
    public class TeacherDatabaseSettings: ITeacherDatabaseSettings
    {
        public string TeacherCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITeacherDatabaseSettings
    {
        string TeacherCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
