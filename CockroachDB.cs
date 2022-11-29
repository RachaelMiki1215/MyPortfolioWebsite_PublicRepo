using Npgsql;

namespace MyPortfolioWebsite
{
    internal class CockroachDB
    {
        private NpgsqlConnectionStringBuilder connStrBuilder;
        public NpgsqlConnection conn;
        public CockroachDB()
        {
            connStrBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = "free-tier.gcp-us-central1.cockroachlabs.cloud",
                // Port, Username, Password and Database strings are omitted for security reasons
                Port = 0000,
                Username = "***",
                Password = "***",
                Database = "***",
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };

            conn = new NpgsqlConnection(connStrBuilder.ConnectionString);
        }
    }
}
