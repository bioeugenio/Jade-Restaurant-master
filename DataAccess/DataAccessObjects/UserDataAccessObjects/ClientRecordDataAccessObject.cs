﻿using Data.UserInfo;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DataAccessObjects.UserDataAccessObjects
{
    class ClientRecordDataAccessObject
    {
        private RestaurantContext _context;

        public ClientRecordDataAccessObject()
        {
            _context = new RestaurantContext();

        }

        #region C

        public void Create(ClientRecord client)
        {
            _context.ClientRecords.Add(client);
            _context.SaveChanges();

        }

        public async Task CreateAsync(ClientRecord client)
        {
            await _context.ClientRecords.AddAsync(client);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public ClientRecord Read(Guid id)
        {
            return _context.ClientRecords.FirstOrDefault(x => x.Id == id);

        }

        public async Task<ClientRecord> ReadAsync(Guid id)
        {
            return await
                new Task<ClientRecord>(() => _context.ClientRecords.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(ClientRecord client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(ClientRecord client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(ClientRecord client)
        {
            client.IsDeleted = true;
            Update(client);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(ClientRecord client)
        {
            client.IsDeleted = true;
            await UpdateAsync(client);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion
        //dasdasd
    }

}
