using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(config);
            return mapper;
           
        }
        public static List<StudentDTO> Get() {
            var repo = DataAccess.StudentData();
            var data = repo.Get();
            var ret = GetMapper().Map<List<StudentDTO>>(data);
            return ret;

        }
        public static void Create(StudentDTO s) {
            //convert to EF model
            
            var ret = GetMapper().Map<Student>(s);
            var repo = DataAccess.StudentData();
            repo.Add(ret);
        }
    }
}
