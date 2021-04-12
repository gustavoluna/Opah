using System;
using System.Collections.Generic;
using System.Text;

namespace Opah.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
