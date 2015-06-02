using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voetbal
{
    public class Speeldag
    {

        public int dagNummer { get; set; }
        public List<Ploeg> ploegenReeks1 { get; set; }
        public List<Ploeg> ploegenReeks2 { get; set; }
        public List<int> scoreReeks1 { get; set; }
        public List<int> scoreReeks2 { get; set; }
        public DateTime speeldagDatum { get; set; }

        public Speeldag()
        {
            ploegenReeks1 = new List<Ploeg>();
            ploegenReeks2 = new List<Ploeg>();
            scoreReeks1 = new List<int>();
            scoreReeks2 = new List<int>();
            FillZeroes();
        }

        public void FillZeroes()
        {
            for (int i = 0; i < 15; i++)
            {
                scoreReeks1.Add(0);
                scoreReeks2.Add(0);
            }
        }

        public void GenereerDatum()
        {
            DateTime day = new DateTime(DateTime.Now.Year, 7, 31);
            while (day.DayOfWeek != DayOfWeek.Saturday)
            {
                day = day.AddDays(-1);
            }
            if (!(dagNummer == 1))
            {
                int dagen = (dagNummer - 1) * 7;
                day = day.AddDays(dagen);
            }
            speeldagDatum = day;
        }

        public void ShufflePloegenReeks2() { 	
            Random random = new Random();
            if (ploegenReeks2.Count > 1) 	
            {
                for (int i = ploegenReeks2.Count - 1; i >= 0; i--) 		
                {
                    Ploeg tmp = ploegenReeks2[i];
                    int randomIndex = random.Next(i + 1);
                    ploegenReeks2[i] = ploegenReeks2[randomIndex];
                    ploegenReeks2[randomIndex] = tmp; 		
                } 	
            } 
        
        }

        public List<String> GetWedstrijdenList()
        {
            List<String> tempList = new List<String>();
            for (int i = 0; i < ploegenReeks1.Count; i++)
            {
                tempList.Add(String.Format("{0} - {1}", ploegenReeks1[i], ploegenReeks2[i]));
            }
            return tempList;
        }

        public override string ToString()
        {
            return String.Format("Speeldag {0}: {1:dd/MM/yyy}", dagNummer, speeldagDatum);
        }

       
    }
}
