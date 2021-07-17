using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagement.CommonUtills
{
    public sealed class AppSettings
    {
        private static AppSettings _instance = null;
        private static readonly object padlock = new object();
        public readonly string _connectionString = string.Empty;
        public readonly SymmetricSecurityKey _symmetricKey;
        public readonly int _validDays = 0;

        private AppSettings()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
                .Build();

            _connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            _symmetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtAuth:SecretKey").Value));
            _validDays = Convert.ToInt32(configuration.GetSection("JwtAuth:ValidDays").Value);
        }

        public static AppSettings Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new AppSettings();
                    }
                    return _instance;
                }
            }
        }

        public string ConnectionString
        {
            get => _connectionString;
        }
        public SymmetricSecurityKey symmetricKey
        {
            get => _symmetricKey;
        }
        public int validDays
        {
            get => _validDays;
        }
    }
}
