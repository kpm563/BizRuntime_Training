using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteDotNetApp
{
    class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public Account(int id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }


        public override String ToString()
        {
            return string.Format("{0} [id={1}, balance={2}]", typeof(Account).Name, Id, Balance);
        }
    }
}
