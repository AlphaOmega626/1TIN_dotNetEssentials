using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Oef05
{
    public interface IMyList
    {
        void Insert(String tempString);
        int Search(String tempString);
        void Delete(String tempString);
        ObservableCollection<String> GetList();
    }
}
