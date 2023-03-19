using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ejercicio1SpTutorias.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public ICommand NavegarAlumnosCommand { get; set; }

        public ICommand NavegarAsesoriasCommand { get; set; }

        ViewModelAlumnos viewModelAlumnos = new ViewModelAlumnos();
        AsesoriasViewModel asesoriasViewModel = new AsesoriasViewModel();

        private object? _viewmodelactual;

        public object? ViewModelAactual
        {
            get { return _viewmodelactual; }
            set
            {
                _viewmodelactual = value; OnPropertyChanged(nameof(ViewModelAactual));

            }
        }

        public MainViewModel()
        {
            ViewModelAactual = viewModelAlumnos;
            NavegarAlumnosCommand = new RelayCommand(NavegarAlumnos);
            NavegarAsesoriasCommand = new RelayCommand(NavegarAsesorias);
            OnPropertyChanged(nameof(ViewModelAactual));
        }

        private void NavegarAlumnos()
        {
            ViewModelAactual = viewModelAlumnos;
            viewModelAlumnos.GetAlumnos();
            OnPropertyChanged();
        }

        private void NavegarAsesorias()
        {
            ViewModelAactual = asesoriasViewModel;
            asesoriasViewModel.GetAsesores();
            OnPropertyChanged();
        }

        public void OnPropertyChanged(string? properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
