using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentEmail.Models;

namespace UserManagmentEmail.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message message);

    }
}
