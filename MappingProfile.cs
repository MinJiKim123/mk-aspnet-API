using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseLibrary;
using KimMinAPI.Models;

namespace KimMinAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, ExpenseDto>().ReverseMap();
            CreateMap<ExpenseToUpdateDto, Expense>();
        }
    }
}