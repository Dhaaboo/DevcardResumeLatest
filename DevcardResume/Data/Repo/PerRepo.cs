using DevcardResume.Data.Models;
using DevcardResume.Data.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;

namespace DevcardResume.Data.Repo
{
    public class PerRepo : IPerRepo
    {
        private readonly APPDBC _db;
        private readonly IDataProtector _dbPro;
        public PerRepo(APPDBC db, IDataProtectionProvider provider,PeopleDataPro _dtPro )
        {
            _db = db;
            _dbPro = provider.CreateProtector(_dtPro.PeopleInfo);
        }

        public async Task<IEnumerable<People>> GetPersonAsync()
        {
            return await(from P in _db._Peoples
                         select new People
                         {
                             PID = P.PID,
                             FirstName = P.FirstName,
                             LastName = P.LastName,
                             City = P.City,
                             EncyptPID = _dbPro.Protect(P.PID.ToString())

                         }
                          ).ToListAsync();
        }
    }
}
