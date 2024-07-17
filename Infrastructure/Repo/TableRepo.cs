using Core.Entities;
using Core.Interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class TableRepo : ITableRepo, IScoped
    {
        private DataContext context;
        public TableRepo(DataContext context)
        {
            this.context = context;
        }

        public Table AddTable(Table table)
        {
            context.Tables.Add(table);
            return table;
        }

        public void DeleteTableById(int id)
        {
            var foundTable = context.Tables.FirstOrDefault(table => table.Id == id);
            if(foundTable != null)
            {
                foundTable.IsDeleted = true;
                foundTable.LastUpdatedDateTime = DateTime.Now;
            }
        }

        public List<Table> GetAllTables()
        {
            return context.Tables.ToList();
        }

        public Table GetTableById(int id)
        {
            return context.Tables.FirstOrDefault(table => table.Id == id);
        }

        public void UpdateTable(Table table)
        {
            if (table.Id <= 0)
                return;

            var foundTable = context.Tables.FirstOrDefault(x => x.Id == table.Id);
            if (foundTable != null)
            {
                foundTable = table;
            }
        }
    }
}
