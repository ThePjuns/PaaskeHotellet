using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM.Common;
using MVVM.Handler;

namespace MVVM
{
    class ViewModel
    {
        private ICommand iAdd;
        private ICommand iRemove;
        private ICommand iUpdate;
        private ICommand selectedItem;

        public ObservableCollection<Hotel> ListHotels { get; set; }

        public static Hotel SelectHotel { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public HotelHandler HotelHandler { get; set; }

        public ICommand SelectedItem
        {
            get { return selectedItem ?? (selectedItem = new RelayArgCommand<Hotel>()); }
            set { selectedItem = value; }
        }

        public ICommand IAdd
        {
            get { return iAdd ?? (iAdd = new RelayCommand(HotelHandler.CreateHotel)); }
            set { iAdd = value; }
        }
        public ICommand IRemove
        {
            get { return iRemove ?? (iRemove = new RelayCommand()); }
            set { iRemove = value; }
        }
        
        public ICommand IUpdate
        {
            get { return iUpdate ?? (iUpdate = new RelayCommand()); }
            set { iUpdate = value; }
        }


        public ViewModel()
        {


            ListHotels = new ObservableCollection<Hotel>();
            Persistency.HotelPersistency P = new Persistency.HotelPersistency();

            HotelHandler = new HotelHandler(this, P);

            List<Hotel> Hotels = P.Read();

            foreach (var ho in Hotels)
            {
                ListHotels.Add(ho);
            }
            

        }

    }
}
