using Xamarin.Forms;
using System.Collections.Generic;
using DataBinding;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Coin.Common;
using System.Diagnostics;
using System.ComponentModel;

namespace Coin
{
    public partial class CoinPage : ContentPage
    {
        RequestAPI CallApi;
        ListCoin coins;
        ObservableCollection<Coin> listCoin;

        public CoinPage()
        {
            InitializeComponent();
            this.Title = "List Coin";
            CallApi = new RequestAPI();
            listCoin = new ObservableCollection<Coin>();
            coins = new ListCoin();
            BindingContext = coins;
            mListView.RefreshCommand = coins.RefreshCommand;
            mListView.SetBinding(ListView.IsRefreshingProperty, nameof(coins.isRefresh));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Device.BeginInvokeOnMainThread( async () => {
            //List<Coin> mcoins = await CallApi.GetAllCoint(Url.UrlGetAllCoin);

            //coins.setListCoin(mcoins);
            //});

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var list = BindingContext as ListCoin;
            if (list != null)
            {
                list.Collection.RemoveAt(list.Collection.Count - 1);
            }
        }

        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            //listCoin.Clear();
            //Device.BeginInvokeOnMainThread(async () => {
            //List<Coin> coins = await CallApi.GetAllCoint(Url.UrlGetAllCoin);
            //foreach (Coin coin in coins)
            //{
            //    listCoin.Add(coin);
            //}
            //});
            //coins.PullToRefresh();
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Notification", "test", "OK");
            });
        }

        public class ListCoin : INotifyPropertyChanged
        {
            RequestAPI CallApi;
            bool _isRefresh = false;
            Command _RefreshCommand;
            public bool isRefresh
            {
                get { return _isRefresh; }

                set
                {
                    _isRefresh = value;
                    OnPropertyChanged(nameof(isRefresh));
                }
            }


            public Command RefreshCommand
            {
                get { return _RefreshCommand; }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            public ObservableCollection<Coin> Collection { get; set; }

            public ListCoin()
            {
                Collection = new ObservableCollection<Coin>();
                _RefreshCommand = new Command(PullToRefresh);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    CallApi = new RequestAPI();
                    List<Coin> coins = await GetListCoinFromApi();
                    setListCoin(coins);
                });

            }

            public void setListCoin(List<Coin> coins)
            {
                Collection.Clear();
                foreach (Coin coin in coins)
                {
                    Collection.Add(coin);
                }
                _isRefresh = false;
                OnPropertyChanged(nameof(isRefresh));
                Debug.WriteLine(_isRefresh);
            }

            public async Task<List<Coin>> GetListCoinFromApi()
            {
                List<Coin> coins = await CallApi.GetAllCoint(Url.UrlGetAllCoin);
                return coins;
            }

            public async void PullToRefresh()
            {
                _isRefresh = true;
                OnPropertyChanged(nameof(isRefresh));
                List<Coin> coins = await GetListCoinFromApi();
                setListCoin(coins);
                _isRefresh = false;
                OnPropertyChanged(nameof(isRefresh));
            }

            public void setName(int Index, string Name)
            {
                //Collection[Index].Name = Name;
            }
        }
    }
}
