using TeacherAPI.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TeacherAPI.Models;
using TeacherAPI.Controllers;
using System;

namespace TeacherAPI.Services
{
    public class TeacherService
    {

        private readonly IMongoCollection<Teacher> _teachers;

        public TeacherService(ITeacherDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _teachers= database.GetCollection<Teacher>(settings.TeacherCollectionName);
        }

        public List<Teacher> Get()
        {
            return _teachers.Find(s => true).ToList();
        }

        public Teacher GetById(string name)
        {
            return _teachers.Find<Teacher>(s => s._id == name).FirstOrDefault();
        }

        public Teacher Create(Teacher student)
        {
            student._id = ObjectId.GenerateNewId().ToString();
            _teachers.InsertOne(student);
            return student;
        }

        public void Update(string id, Teacher teacher)
        {
            teacher._id = id;
            _teachers.FindOneAndReplace(t => t._id == id, teacher);


        }


        public DeleteResult Remove(string name)
        {
            var delTeacher = _teachers.DeleteOne(s => s.name == name);
            return delTeacher;
        }

        
    }
}