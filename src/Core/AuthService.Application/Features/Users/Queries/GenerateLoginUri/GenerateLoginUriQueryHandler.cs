using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.Models;
using MediatR;

namespace AuthService.Application.Features.Users.Queries.GenerateLoginUri
{

    public class GenerateLoginUriQueryHandler : IRequestHandler<GenerateLoginUriQuery, string>
    {
        private static readonly char[] _chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private const int STATE_LENGTH = 8;
        private const string _baseUri = "https://github.com/login/oauth/authorize?";
        private const string _scope = "user:email";
        private readonly OAuthOptions _options;
        public GenerateLoginUriQueryHandler(OAuthOptions options)
        {
            _options = options;

        }

        public async Task<string> Handle(GenerateLoginUriQuery request, CancellationToken cancellationToken)
        {
            StringBuilder result = new();
            result.Append(_baseUri);
            result.Append("client_id=" + _options.ClientId);
            result.Append('&');
            result.Append("redirect_uri=" + _options.RedirectUri);
            result.Append('&');
            result.Append("scope=" + _scope);
            result.Append('&');
            result.Append("state=" + GetUniqueState(STATE_LENGTH));
            return await Task.FromResult(result.ToString());
        }

        private static string GetUniqueState(int size)
        {
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % _chars.Length;

                result.Append(_chars[idx]);
            }

            return result.ToString();
        }
    }
}