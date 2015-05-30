using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Oef05
{
    public class StringList : IMyList
    {
        ObservableCollection<String> mainList = new ObservableCollection<String>();

        public StringList()
        {

        }

        public void Insert(String tempString)
        {
            mainList.Add(tempString);
        }

        public int Search(String tempString)
        {
            return mainList.IndexOf(tempString);
        }

        public void Delete(String tempString)
        {
            mainList.Remove(tempString);
        }

        public ObservableCollection<String> GetList()
        {
            return mainList;
        }

    }
}
