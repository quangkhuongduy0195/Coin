using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace DataBinding
{
    public class Pokemon: INotifyPropertyChanged
    {

        private String _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Number { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string property =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public static List<Pokemon> GetListPokemon ()
        {
            return new List<Pokemon>(){
                new Pokemon(){Number = 1, Name = "Pokemon 1"},
                new Pokemon(){Number = 2, Name = "Pokemon 2"},
                new Pokemon(){Number = 3, Name = "Pokemon 3"},
                new Pokemon(){Number = 4, Name = "Pokemon 4"},
                new Pokemon(){Number = 5, Name = "Pokemon 5"},
                new Pokemon(){Number = 6, Name = "Pokemon 6"},
                new Pokemon(){Number = 7, Name = "Pokemon 7"},
                new Pokemon(){Number = 8, Name = "Pokemon 8"},
                new Pokemon(){Number = 9, Name = "Pokemon 9"},
                new Pokemon(){Number = 10, Name = "Pokemon 10"},
                new Pokemon(){Number = 11, Name = "Pokemon 11"},
                new Pokemon(){Number = 12, Name = "Pokemon 12"},
                new Pokemon(){Number = 13, Name = "Pokemon 13"},
                new Pokemon(){Number = 14, Name = "Pokemon 14"},
                new Pokemon(){Number = 15, Name = "Pokemon 15"},
                new Pokemon(){Number = 16, Name = "Pokemon 16"},
                new Pokemon(){Number = 17, Name = "Pokemon 17"},
                new Pokemon(){Number = 18, Name = "Pokemon 18"},
                new Pokemon(){Number = 19, Name = "Pokemon 19"},
                new Pokemon(){Number = 20, Name = "Pokemon 20"},
            };
        }
    }
}