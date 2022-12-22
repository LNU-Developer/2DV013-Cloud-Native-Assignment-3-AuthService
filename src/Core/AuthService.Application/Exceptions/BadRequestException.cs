using System;

namespace AuthService.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}