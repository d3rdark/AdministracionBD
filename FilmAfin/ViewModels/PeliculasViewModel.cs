using FilmAfin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAfin.ViewModels
{
    public class PeliculasViewModel : BaseViewModel
    {

        public ObservableCollection<Peliculas> ListaPeliculas { get; set; } 
            = new ObservableCollection<Peliculas>();

        public PeliculasViewModel(CinetecaContext context) : base(context)
        {
            Llenar();
        }


        private void Llenar()
        {
            ListaPeliculas.Clear();
            foreach (var P in peliculaRepository.GetAll())
            {
                ListaPeliculas.Add(P);
            }
        }
    }

}
