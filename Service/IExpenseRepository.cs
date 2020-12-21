using ExpenseLibrary;
using KimMinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KimMinAPI.Service
{
    interface IExpenseRepository
    {
        Task<Expense> InsertExpense(Expense expense);
        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> GetExpenseById(string expId);
        Task Remove(string expId);

        Task<Expense> Update(Expense exp);
        //Task<IEnumerable<Expense>> GetExpensesByDate(string startDate, string endDate);
      
    }
}

