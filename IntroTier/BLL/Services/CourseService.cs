using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>();
                cfg.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
        public static void Create(CourseDTO c) {
            new CourseRepo().Create(GetMapper().Map<Course>(c));
        }
        public static List<CourseDTO> Get() {
            return GetMapper().Map<List<CourseDTO>>(new CourseRepo().Get());
        }
    }
}
