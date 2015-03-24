using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oef03_Bankrekening_Abstract
{
    class GoldenRekening : Bankrekening
    {
        double rente = 0.0;

        public GoldenRekening()
        {

        }

        public override void BerekenRente()
        {
            rente = this.saldo * 0.10;
        }

        public override Double GetRente()
        {
            return this.rente;
        }
    }
}
