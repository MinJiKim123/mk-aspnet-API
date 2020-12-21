using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using ExpenseLibrary;
using KimMinAPI.Models;
using KimMinAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace KimMinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private IExpenseRepository _expenseRepository;
        private IAmazonDynamoDB _dynamoDBClient;
        private readonly IMapper _mapper;

        public ExpenseController(IAmazonDynamoDB dynamoDBClient, IMapper mapper)
        {
            _dynamoDBClient = dynamoDBClient;
            _mapper = mapper;
            _expenseRepository = new ExpenseRepository(_dynamoDBClient);
        }
        [HttpGet]
        public async Task<ActionResult<Expense>> GetExpenses()
        {
            var expenses = await _expenseRepository.GetExpenses();
            var res = _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
            return Ok(res);
        }

        [HttpGet("{expId}")]
        public async Task<ActionResult<Expense>> GetExpenseById(string expId)
        {
            var expense = await _expenseRepository.GetExpenseById(expId);
            var expense2Expose = _mapper.Map<ExpenseDto>(expense);

            return Ok(expense2Expose);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Expense expense)
        {
            var expensenew = await _expenseRepository.InsertExpense(expense);
            var personDynamoDb = _mapper.Map<ExpenseDto>(expense);

            return Ok(personDynamoDb);

        }

        [HttpDelete]
        [Route("{expId}")]
        public async Task<ActionResult> Delete(string expId)
        {
            await _expenseRepository.Remove(expId);
            return Ok();
        }

        [HttpPut]
        [Route("{expId}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Expense>> Edit(string expId,[FromBody] ExpenseToUpdateDto updatedExp)
        {
            Expense exp = await _expenseRepository.GetExpenseById(expId);
            var updated = _mapper.Map<ExpenseToUpdateDto,Expense>(updatedExp, exp);
            Expense final = await _expenseRepository.Update(updated);
                return Ok(final);

        }

    }

}