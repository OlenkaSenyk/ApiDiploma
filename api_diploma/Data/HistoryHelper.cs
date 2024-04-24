using api_diploma.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace api_diploma.Data
{
    public class HistoryHelper
    {
        AppDbContext _context;

        public HistoryHelper(AppDbContext context)
        {
            _context = context;
        }

        public void ChangeHistory(string type, string oldValue, string newValue, int pId, int uId)
        {
            var history = new ChangePersonHistory()
            {
                Date = DateTime.Now,
                Type = type,
                OldValue = oldValue,
                NewValue = newValue,
                PersonId = pId,
                UserId = uId
            };

            _context.ChangePersonHistory.Add(history);
        }
    }
}
