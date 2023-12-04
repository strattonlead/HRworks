using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HRworks.Api
{
    public partial class HRworksClient
    {
        public DateTime? TokenValidUntilUtc { get; private set; }
        public bool HasValidToken => TokenValidUntilUtc.HasValue && TokenValidUntilUtc.Value >= DateTime.UtcNow;

        public HRworksClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Token> CreateTokenAsync(string accessKey, string secretAccessKey, CancellationToken cancellationToken)
        {
            var token = await CreateTokenAsync(new Credentials()
            {
                AccessKey = accessKey,
                SecretAccessKey = secretAccessKey
            }, cancellationToken);

            TokenValidUntilUtc = DateTime.UtcNow.AddMinutes(15);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token1);
            return token;
        }

    }
}
