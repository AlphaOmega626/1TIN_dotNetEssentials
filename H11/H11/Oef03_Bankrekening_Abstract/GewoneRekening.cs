using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oef03_Bankrekening_Abstract
{
    class GewoneRekening : Bankrekening
    {
        double rente = 0.0;
        public GewoneRekening()
        {

        }

        public override void BerekenRente()
        {

            if (this.saldo > 100)
            {
                rente = (this.saldo - 100) * 0.01;
            }
            
        }

        public override double GetRente()
        {
            return this.rente;
        }
    }
}
