using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oef03_Bankrekening
{
    class Bankrekening
    {
        private double saldo;

        public Bankrekening()
        {
            this.saldo = 0.0;
        }

        public double getSaldo()
        {
                return this.saldo;
        }

        public void transaction(double amount)
        {
            if (amount < 0)
            {
                this.saldo -= Math.Abs(amount);
            }
            else
            {
                this.saldo += Math.Abs(amount);
            }
            
        }
    }
}
