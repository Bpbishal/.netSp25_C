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
    public class CategoryService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
        public static List<CategoryDTO> Get() {
            var catRepo = new CategoryRepo();
            var data= catRepo.Get();
            var mapper = GetMapper();
            var mappeddata = mapper.Map<List<CategoryDTO>>(data);
            return mappeddata;

        }
        public static CategoryDTO Get(int id) {
            var data = new CategoryRepo().Get(id);
            return GetMapper().Map<CategoryDTO>(data);
        }
        public static void Create(CategoryDTO ct) {
            var mapper = GetMapper();
            var data = mapper.Map<Category>(ct);
            var repo = new CategoryRepo();
            repo.Create(data);
        }
       
    }
}
