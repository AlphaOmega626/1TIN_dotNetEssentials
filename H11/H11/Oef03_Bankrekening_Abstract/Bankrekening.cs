using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oef03_Bankrekening_Abstract
{
    abstract class Bankrekening
        
    {
        protected double saldo;
        public double huidigSaldo
        {
            get
            {
                return saldo;
            }
        }

        public void debetSaldo(double bedrag)
        {
            this.saldo += bedrag;
        }

        public abstract void BerekenRente();
        public abstract Double GetRente();
    }
}
