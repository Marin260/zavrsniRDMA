using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace zavrsniRDMA
{
    public interface AuthRDMA
    {
        Task<String> LoginWithEmailAndPassword(string email, string password);
        Task<String> SignUpWithEmailAndPassword(string email, string password);    

        bool SignOut();
        bool IsSignIn();
    }
}
