using PersonalVault.Data;
using PersonalVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalVault.Services
{
    public class VaultService
    {
        private readonly EncryptionService _encryptionService;
        private readonly VaultDbContext _dbContext;

        public VaultService(VaultDbContext dbContext, string encryptionKey)
        {
            _dbContext = dbContext;
            _encryptionService = new EncryptionService(encryptionKey);
        }

        public void SaveCredential(string service, string username, string password, string comment)
        {
            var encryptedPassword = _encryptionService.Encrypt(password);
            var credential = new Credential
            {
                Service = service,
                Username = username,
                Password = encryptedPassword,
                Comment = comment
            };

            _dbContext.Credentials.Add(credential);
            _dbContext.SaveChanges();
        }

        public Credential GetCredential(string service, string username)
        {
            var getCred = _dbContext.Credentials
                .Where(c => c.Service == service && c.Username == username)
                .Select(c => new Credential
                {
                    Id = c.Id,
                    Service = c.Service,
                    Username = c.Username,
                    Password = c.Password,
                    Comment = c.Comment,
                    CreatedAt = c.CreatedAt
                })
                .FirstOrDefault();

            if (getCred != null)
            {
                return getCred;
            }
            else
            {
                return new Credential();
            }
        }

        public List<Credential> GetAllCredentials()
        {
            var allCred = _dbContext.Credentials
                .OrderBy(c => c.Service)
                .ToList();

            if (allCred != null)
            {
                return allCred;
            }else
            {
                return new List<Credential>();
            }
        }

        public void DeleteCredential(int id)
        {
            var credential = _dbContext.Credentials.Find(id);
            if (credential != null)
            {
                _dbContext.Credentials.Remove(credential);
                _dbContext.SaveChanges();
            }
        }

        public string DecryptPassword(string encryptedPassword)
        {
            return _encryptionService.Decrypt(encryptedPassword);
        }
    }
}
