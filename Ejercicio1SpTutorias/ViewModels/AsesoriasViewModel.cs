using Ejercicio1SpTutorias.Models;
using Ejercicio1SpTutorias.Repository.AsesoriasRepository;
using Ejercicio1SpTutorias.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1SpTutorias.View;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Ejercicio1SpTutorias.ViewModels
{
    public class AsesoriasViewModel : INotifyPropertyChanged
    {
        AsesoriasRepository asesoriaRepository = new AsesoriasRepository();
        AlumnoRepository alumnoRepository = new AlumnoRepository();

        public ObservableCollection<Asesorias> Asesorias { get; set; }
            = new ObservableCollection<Asesorias>();

        public ObservableCollection<Alumnos> Alumnos { get; set; }
        = new ObservableCollection<Alumnos>();

        public Asesorias? Asesor { get; set; }
        public Alumnos? Alumno { get; set; } = new Alumnos();

        public Accion Operacion { get; set; }

        public string? Errores { get; set; }


        public ICommand VerRegistrarAsesorCommand { get; set; }
        public ICommand RegistrarAsesorCommand { get; set; }
        public ICommand VerEditarAsesoriaCommand { get; set; }
        public ICommand EditarAsesoriaCommand { get; set; }

        public ICommand VerEliminarAsesoriaCommand { get; set; }
        public ICommand EliminarAsesoriaCommand { get; set; }

        public ICommand FiltrarAsesoriasCommand { get; set; }

        public ICommand RegresarCommand { get; set; }


        public AsesoriasViewModel()
        {
            VerRegistrarAsesorCommand = new RelayCommand(VerRegistrarAsesor);
            RegistrarAsesorCommand = new RelayCommand(RegistrarAsesor);
            VerEliminarAsesoriaCommand = new RelayCommand<int>(VerEliminarAsesor);
            VerEditarAsesoriaCommand = new RelayCommand<int>(VerEditarAsesoria);
            EditarAsesoriaCommand = new RelayCommand(EditarAsesoria);
            EliminarAsesoriaCommand = new RelayCommand(EliminarAsesor);
            FiltrarAsesoriasCommand = new RelayCommand(FiltrarAsesorias);
            RegresarCommand = new RelayCommand(Regresar);


            Operacion = Accion.VerAsesorias;
            GetAsesores();
            GetAlumnos();
            OnPropertyChanged();
        }

        private void EditarAsesoria()
        {
            Errores = "";
            if (Asesor != null)
            {
                if (ValidadorAsesor.Validar(Asesor, out List<string> errores))
                {
                    var existeAsesor = asesoriaRepository.GetAsesoriasById(Asesor.Id);
                    if (existeAsesor != null)
                    {
                        existeAsesor.Id = Asesor.Id;
                        existeAsesor.Asesor = Asesor.Asesor;
                        existeAsesor.Fecha = Asesor.Fecha;
                        existeAsesor.Hora = Asesor.Hora;
                        existeAsesor.IdTutorado = Asesor.IdTutorado;
                        asesoriaRepository.Update(existeAsesor);
                        asesoriaRepository.Save();
                        Operacion = Accion.VerAsesorias;
                        OnPropertyChanged();
                        Regresar();
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

        private void VerEditarAsesoria(int obj)
        {
            if (asesoriaRepository.GetAsesoriasById(obj) != null)
            {
                Asesor = asesoriaRepository.GetAsesoriasById(obj);
                if (Asesor != null)
                {
                    Asesorias clon = new Asesorias()
                    {
                        Id = Asesor.Id,
                        Asesor = Asesor.Asesor,
                        Fecha = Asesor.Fecha,
                        Hora = Asesor.Hora,
                        IdTutorado = Asesor.IdTutorado

                    };
                    Asesor = clon;
                    Operacion = Accion.EditarAsesorias;
                    OnPropertyChanged();
                }
            }
        }

        private void FiltrarAsesorias()
        {
            if (Asesorias != null)
            {
                Asesorias.Clear();
                if (Alumno != null)
                {
                    var listAsesorias = asesoriaRepository.GetAllAsesoriasById(Alumno.Id);
                    foreach (var item in listAsesorias)
                    {
                        Asesorias.Add(item);
                    }
                }
            }
        }

        private void VerRegistrarAsesor()
        {
            Asesor = new Asesorias();

            Operacion = Accion.AgregarAsesorias;
            OnPropertyChanged();
        }

        private void RegistrarAsesor()
        {
            Errores = "";
            if (Asesor is not null)
            {
                if (ValidadorAsesor.Validar(Asesor, out List<string> errores))
                {
                    asesoriaRepository.Create(Asesor);
                    asesoriaRepository.Save();
                    Operacion = Accion.VerAsesorias;
                    Regresar();
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



        public void GetAsesores()
        {
            Asesorias.Clear();
            foreach (var item in asesoriaRepository.GetAsesorias())
            {
                Asesorias.Add(item);
            }
        }
        private void GetAlumnos()
        {
            Alumnos.Clear();
            foreach (var item in alumnoRepository.GetAlumnos())
            {
                Alumnos.Add(item);
            }
        }



        private void Regresar()
        {
            Operacion = Accion.VerAsesorias;
            GetAsesores();
            Errores = "";
            Asesor = null;
            OnPropertyChanged();
        }

        private void VerEliminarAsesor(int obj)
        {
            Asesor = asesoriaRepository.GetAsesoriasById(obj);
            if (Asesor != null)
            {
                Operacion = Accion.EliminarAsesorias;
                OnPropertyChanged();
            }
        }

        private void EliminarAsesor()
        {
            if (Asesor != null)
            {
                asesoriaRepository.Delete(Asesor);
                asesoriaRepository.Save();
                Regresar();
            }
        }

        private void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
