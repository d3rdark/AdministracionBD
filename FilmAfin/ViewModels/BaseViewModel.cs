using FilmAfin.Models;
using FilmAfin.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAfin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public CinetecaContext Context { get; set; }
        public PeliculaRepository peliculaRepository;

        public event PropertyChangedEventHandler? PropertyChanged;

        public BaseViewModel(CinetecaContext context)
        {
            Context = context;
            peliculaRepository = new PeliculaRepository(Context);
        }

        public void OnPropertyChanged(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
