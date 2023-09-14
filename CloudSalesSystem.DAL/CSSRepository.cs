﻿using CloudSalesSystem.DAL.DTOs;
using CloudSalesSystem.DAL.Interfaces;
using CloudSalesSystem.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.DAL
{
    public class CSSRepository : ICSSRepository
    {
        private readonly CSSContext _context;

        public CSSRepository(CSSContext context)
        {
            _context = context;
        }

        public async Task<Software> CancelAccountSoftwareAsync(string accountId, string softwareId)
        {
            try
            {
                var software = await _context.Software.FirstOrDefaultAsync(x => x.AccountRefId == accountId && x.SoftwareId == softwareId);
                software.IsCancelled = false;
                var updatedEntry = _context.Software.Attach(software).Entity;
                _context.Entry(software).State = EntityState.Modified;
                Save();

                return new Software(
                            software.SoftwareId,
                            software.SoftwareName,
                            software.Quantity,
                            software.Price,
                            software.EndDate,
                            software.IsCancelled);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Software> ExtendSoftwareLicenceDateAsync(string accountId, Software software, DateTime newEndDate)
        {
            try
            {
                var currentSoftware = await _context.Software.FirstOrDefaultAsync(x => x.AccountRefId == accountId && x.SoftwareId == software.SoftwareId);

                currentSoftware.EndDate = newEndDate;
                var updatedEntry = _context.Software.Attach(currentSoftware).Entity;
                _context.Entry(currentSoftware).State = EntityState.Modified;
                Save();

                return new Software(
                            currentSoftware.SoftwareId,
                            currentSoftware.SoftwareName,
                            currentSoftware.Quantity,
                            currentSoftware.Price,
                            currentSoftware.EndDate,
                            currentSoftware.IsCancelled);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Account> GetAccountByIdAsync(string accountId)
        {
            try
            {
                var account = await _context.Account.FirstOrDefaultAsync(x => x.AccountId == accountId);

                return new Account(account.AccountId, account.AccountName);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            var accounts = await _context.Account.ToListAsync();
            var listToReturn = new List<Account>();

            if (accounts.Any())
            {
                foreach (var account in accounts)
                {
                    listToReturn.Add(new Account(account.AccountId, account.AccountName));
                }
            }

            return listToReturn;
        }

        public async Task<IEnumerable<Software>> GetAllAccountSoftwaresAsync(string accountId)
        {
            var softwares = await _context.Software.Where(x => x.AccountRefId == accountId).ToListAsync();

            var softwaresToReturn = new List<Software>();

            if (softwares.Any())
            {
                foreach (var software in softwares)
                {
                    softwaresToReturn.Add(
                        new Software(
                            software.SoftwareId,
                            software.SoftwareName,
                            software.Quantity,
                            software.Price,
                            software.EndDate,
                            software.IsCancelled
                            ));
                }
            }

            return softwaresToReturn;
        }

        public async Task<Account> InsertNewAccountAsync(string accountName)
        {
            var isAccountNameTaken = await _context.Account.AnyAsync(x => x.AccountName == accountName);
            if (!isAccountNameTaken) 
            {
                var account = new Account(Guid.NewGuid().ToString(), accountName);
                var accountDto = new AccountDto(account.AccountId, account.AccountName);
                _context.Account.Add(accountDto);
                Save();
                return account;
            }
            else
            {
                throw new Exception("Account with the same name already exists");
            }
        }

        public async Task<Software> InsertNewAccountSoftwareAsync(string accountId, Software software)
        {
            var softwareDto = new SoftwareDto(
                    software.SoftwareId,
                    software.SoftwareName,
                    software.Quantity,
                    software.Price,
                    software.EndDate,
                    software.IsCancelled,
                    accountId
                    );
            _context.Software.Add(softwareDto);
            Save();

            return await Task.FromResult(software);
        }

        public async Task SavePurchasedSoftwareByAccountAsync(string accountId, Software software)
        {
            var account = await _context.Account.FirstOrDefaultAsync(x => x.AccountId == accountId);

            if (account != null)
            {
                var softwareToInsert = new SoftwareDto(
                    software.SoftwareId,
                    software.SoftwareName,
                    software.Quantity,
                    software.Price,
                    software.EndDate,
                    software.IsCancelled,
                    accountId
                    );

                _context.Software.Add(softwareToInsert);
                Save();
            }
        }

        public async Task<Software> UpdateServiceQuantityAsync(string softwareId, string accountId, int quantity)
        {
            try
            {
                var software = await _context.Software.FirstOrDefaultAsync(x => x.SoftwareId == softwareId);

                software.Quantity = quantity;
                var updatedEntry = _context.Software.Attach(software).Entity;
                _context.Entry(software).State = EntityState.Modified;
                Save();

                return new Software(
                                software.SoftwareId,
                                software.SoftwareName,
                                software.Quantity,
                                software.Price,
                                software.EndDate,
                                software.IsCancelled);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
