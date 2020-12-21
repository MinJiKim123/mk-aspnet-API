using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using ExpenseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KimMinAPI.Service
{
    public class ExpenseRepository : IExpenseRepository
    {
        private IAmazonDynamoDB dynamoDBClient { get; set; }
        private IDynamoDBContext context;
        public ExpenseRepository(IAmazonDynamoDB dynamoDBClient)
        {
            this.dynamoDBClient = dynamoDBClient;
            context = new DynamoDBContext(dynamoDBClient);
        }
        public async Task<Expense> InsertExpense(Expense exp)
        {
            exp.Id = System.Guid.NewGuid().ToString();
            await context.SaveAsync(exp, default(System.Threading.CancellationToken));
            return exp;
        }

        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            ScanFilter scanFilter = new ScanFilter();
            scanFilter.AddCondition("Id", ScanOperator.NotEqual, 0);

            ScanOperationConfig soc = new ScanOperationConfig()
            {
                Filter = scanFilter
            };
            AsyncSearch<Expense> search = context.FromScanAsync<Expense>(soc, null);
            List<Expense> documentList = new List<Expense>();
            do
            {
                documentList = await search.GetNextSetAsync(default(System.Threading.CancellationToken));
            } while (!search.IsDone);

            return documentList;
        }
        public async Task<Expense> GetExpenseById(string expId)
        {
            Expense gexp = await context.LoadAsync<Expense>(expId, default(System.Threading.CancellationToken));
            return gexp;
        }

        public async Task<Expense> Update(Expense exp)
        {

            await context.SaveAsync<Expense>(exp);
            return exp;
        }

        public async Task Remove(string expId)
        {
            await context.DeleteAsync<Expense>(expId);
        }

    }
}
