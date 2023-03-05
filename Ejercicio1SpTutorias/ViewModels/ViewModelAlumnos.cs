using Ejercicio1SpTutorias.Models;
using Ejercicio1SpTutorias.Repository;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ejercicio1SpTutorias.View;

namespace Ejercicio1SpTutorias.ViewModels
{
    public class ViewModelAlumnos : INotifyPropertyChanged
    {
        AlumnoRepository catalagos = new AlumnoRepository();

        

        public ObservableCollection<Alumnos> ListAlumnos { get; set; }
            = new ObservableCollection<Alumnos>();

        public Alumnos? Alumno { get; set; }

        public Accion Operacion { get; set; }

        public string? Errores { get; set; }


        public ICommand VerRegistrarAlumnoCommand { get; set; }
        public ICommand RegistrarAlumnoCommand { get; set; }
        public ICommand VerAlumnosCommand { get; set; }
        public ICommand VerEditarAlumnoCommand { get; set; }
        public ICommand EditarAlumnoCommand { get; set; }
        public ICommand VerEliminarAlumnoCommand { get; set; }
        public ICommand EliminarAlumnoCommand { get; set; }

        public ICommand RegresarCommand { get; set; }

        public ViewModelAlumnos()
        {
            VerRegistrarAlumnoCommand = new RelayCommand(VerAgregarAlumnos);
            RegistrarAlumnoCommand = new RelayCommand(RegistrarAlumnos);
            VerAlumnosCommand = new RelayCommand(VerAlumnos);
            VerEditarAlumnoCommand = new RelayCommand<int>(VerEditarAlumnos);
            EditarAlumnoCommand = new RelayCommand(EdiarAlumnos);
            VerEliminarAlumnoCommand = new RelayCommand<int>(VerEliminarAlumno);
            EliminarAlumnoCommand = new RelayCommand(EliminarAlumno);
            RegresarCommand = new RelayCommand(Regresar);

            Operacion = Accion.VerTutorados;
            GetAlumnos();
            OnPropertyChanged();
        }



        private void VerAgregarAlumnos()
        {
            throw new NotImplementedException();
        }

        private void RegistrarAlumnos()
        {
            throw new NotImplementedException();
        }

        private void VerAlumnos()
        {
            throw new NotImplementedException();
        }

        private void VerEditarAlumnos(int obj)
        {
            throw new NotImplementedException();
        }

        private void EdiarAlumnos()
        {
            throw new NotImplementedException();
        }

        private void VerEliminarAlumno(int obj)
        {
            throw new NotImplementedException();
        }

        private void EliminarAlumno()
        {
            throw new NotImplementedException();
        }

        private void Regresar()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string? pop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pop));
        }

        private void GetAlumnos()
        {
            ListAlumnos.Clear();
            foreach (var item in catalagos.GetAlumnos())
            {
                ListAlumnos.Add(item);
            }
        }

    }
}
