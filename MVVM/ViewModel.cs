using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    class ViewModel
    {
        public ObservableCollection<Hotel> ListHotels { get; set; }

        public ViewModel()
        {
            ListHotels = new ObservableCollection<Hotel>();
            Persistency.HotelPersistency P = new Persistency.HotelPersistency();

            List<Hotel> Hotels = P.Read();

            foreach(var ho in Hotels)
            {
                ListHotels.Add(ho);
            }

        }

    }
}
