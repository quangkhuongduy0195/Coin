using Xamarin.Forms;
using System.Collections.Generic;
using DataBinding;
using System.Threading.Tasks;

namespace Coin
{
    public partial class CoinPage : ContentPage
    {
        Pokemon pokemon;
        ListPokemon listPokemon;
        public CoinPage()
        {
            InitializeComponent();
            pokemon = new Pokemon();
            listPokemon = new ListPokemon();
            BindingContext = listPokemon;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread( async () => {
                await Task.Delay(5000);
                listPokemon.setName(1, "Duy test");
                await Task.Delay(2000);
                listPokemon.setName(2, "Duy test");
                await Task.Delay(2000);
                listPokemon.setName(3, "Duy test");
                await Task.Delay(2000);
                listPokemon.setName(4, "Duy test");
                await Task.Delay(2000);
                listPokemon.setName(5, "Duy test");
                await Task.Delay(2000);
                listPokemon.setName(6, "Duy test");
                await Task.Delay(2000);
                listPokemon.setName(7, "Duy test");
            });

        }

        public class ListPokemon
        {
            public List<Pokemon> Collection { get; set; }

            public ListPokemon()
            {
                Collection = Pokemon.GetListPokemon();
            }
            public void setName(int Index, string Name)
            {
                Collection[Index].Name = Name;
            }
        }
    }
}
