using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Squares_server.Data;
using Squares_server.Dtos;
using Squares_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squares_server.Services
{
    public class NamedListService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        public NamedListService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ViewNamedList>> GetNamedListsAsync()
        {
            List<NamedList> allNamedLists = await _context.NamedLists.ToListAsync();
            List<ViewNamedList> viewNamedLists = _mapper.Map<List<ViewNamedList>>(allNamedLists);
            return viewNamedLists;
        }

        public async Task<ViewNamedList> GetNamedListAsync(int id)
        {
            NamedList namedLists = await _context.NamedLists.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (namedLists == null)
            {
                throw new ArgumentException($"List {id} not found");
            }
            ViewNamedList viewNamedLists = _mapper.Map<ViewNamedList>(namedLists);
            return viewNamedLists;
        }

        public async Task<int> CreateNamedListAsync(CreateNamedList createNamedLists)
        {
            var checkName = await _context.NamedLists.Where(i => i.Name == createNamedLists.Name).FirstOrDefaultAsync();
            NamedList namedList = _mapper.Map<NamedList>(createNamedLists);
            if (checkName != null) // overwrite existing one 
            {
                await DeleteNamedListAsync(checkName.Id);
            }
            _context.NamedLists.Add(namedList);
            await _context.SaveChangesAsync();
            return namedList.Id;
        }

        public async Task<int> DeleteNamedListAsync(int id)
        {
            var namedList = await _context.NamedLists.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (namedList == null)
            {
                throw new ArgumentException($"NamedLists id {id} not found");
            }
            _context.NamedLists.Remove(namedList);
            await _context.SaveChangesAsync();
            return id;
        }

        //public async Task<int> UpdateNamedListAsync(int id, CreateNamedList createNamedLists)
        //{
        //    var namedList = await _context.NamedLists.Where(i => i.Id == id).FirstOrDefaultAsync();
        //    if (namedList == null)
        //    {
        //        throw new ArgumentException($"NamedList id {id} not found");
        //    }
        //    namedList.Name = createNamedLists.Name;
        //    _context.Update(namedList);
        //    await _context.SaveChangesAsync();
        //    return namedList.Id;
        //}
    }
}
