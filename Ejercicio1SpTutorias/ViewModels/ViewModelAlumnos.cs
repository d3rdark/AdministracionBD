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
            Alumno = new Alumnos();
            Operacion = Accion.AgregarTutorados;
            OnPropertyChanged();
        }

        private void RegistrarAlumnos()
        {
            Errores = "";
            if (Alumno is not null)
            {
                if (ValidadorAlumno.Validar(Alumno, out List<string> errores))
                {
                    catalagos.CreateSP(Alumno);
                    GetAlumnos();
                    Operacion = Accion.VerTutorados;
                    Errores = "";
                    OnPropertyChanged();
                }
                else
                {
                    foreach (var item in errores)
                    {
                        Errores = $"{Errores} {item} {Environment.NewLine}";
                    }
                    OnPropertyChanged();
                }
            }
        }

        private void VerAlumnos()
        {
            GetAlumnos();
            Operacion = Accion.VerTutorados;
            OnPropertyChanged();
        }

        private void VerEditarAlumnos(int obj)
        {

            if (catalagos.GetAlumnoById(obj) != null)
            {
                Alumno = catalagos.GetAlumnoById(obj);
                if (Alumno != null)
                {
                    Alumnos clon = new Alumnos()
                    {
                        Id = Alumno.Id,
                        Nombre = Alumno.Nombre,
                        NumeroControl = Alumno.NumeroControl,
                        Promedio = Alumno.Promedio,
                        Evaluacion = Alumno.Evaluacion
                    };

                    Alumno = clon;
                    Operacion = Accion.EditarTutorados;
                    OnPropertyChanged();

                }

            }

        }

        private void EdiarAlumnos()
        {
            Errores = "";
            if (Alumno != null)
            {
                if (ValidadorAlumno.Validar(Alumno, out List<string> errores))
                {
                    var existeAlumno = catalagos.GetAlumnoById(Alumno.Id);
                    if (existeAlumno != null)
                    {
                        existeAlumno.Id = Alumno.Id;
                        existeAlumno.Nombre = Alumno.Nombre;
                        existeAlumno.NumeroControl = Alumno.NumeroControl;
                        existeAlumno.Promedio = Alumno.Promedio;
                        existeAlumno.Evaluacion = Alumno.Evaluacion;
                        catalagos.Upadate(existeAlumno);
                        GetAlumnos();
                        Operacion = Accion.VerTutorados;
                        Errores = "";
                        OnPropertyChanged();
                    }
                }
                else
                {
                    foreach (var item in errores)
                    {
                        Errores = $"{Errores} {item} {Environment.NewLine}";
                    }
                    OnPropertyChanged();
                }
            }
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
            Operacion = Accion.VerTutorados;
            Errores = "";
            OnPropertyChanged();
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
