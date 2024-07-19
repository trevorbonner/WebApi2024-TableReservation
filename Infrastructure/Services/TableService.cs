using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Entities;

namespace Infrastructure.Services
{
    public class TableService : ITableService, IScoped
    {
        private ITableRepo repo;
        private IMapper mapper;

        public TableService(ITableRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public TableDto AddTable(TableDto table)
        {
            var newTable = mapper.Map<Table>(table);

            repo.AddTable(newTable);

            return mapper.Map<TableDto>(newTable);
        }

        public void DeleteTableById(int id)
        {
            repo.DeleteTableById(id);
        }

        public List<TableDto> GetAllTables()
        {
            var tables = repo.GetAllTables();

            var foundTables = new List<TableDto>();

            foreach(var table in tables)
            {
                foundTables.Add(mapper.Map<TableDto>(table));
            }

            return foundTables;
        }

        public TableDto GetTableById(int id)
        {
            var foundTable = repo.GetTableById(id); 
            if(foundTable != null)
            {
                var table = new TableDto()
                {
                    TableNumber = foundTable.TableNumber,
                    MaxSeating = foundTable.Maxseating,
                    IsReserved = true
                };

                return table;
            }

            return null;
        }

        public void UpdateTable(TableDto table)
        {
            //TODO
        }
    }
}
