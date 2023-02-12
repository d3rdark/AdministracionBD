using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Ejercicio1.Models;
using Ejercicio1.Repository;
using System.Collections.ObjectModel;

namespace Ejercicio1.ViewModels
{
    public class MenoresViewModels : INotifyPropertyChanged
    {
        MenoresRepository context = new MenoresRepository();

        public Menor? Menor { get; set; }

        public string Modo { get; set; } = "VerMenores";
        public ICommand VerMenoresCommand { get; set; }
        public ICommand VerHoyCommand { get; set; }
        public ICommand VerMesCommand { get; set; }
        public ICommand VerMenoresDoceCommand { get; set; }

        public ObservableCollection<Menor> ListaMenores { get; set; }
            = new ObservableCollection<Menor>();
        public ObservableCollection<Vwcumplehoy> ListaMenoresHoy { get; set; }
            = new ObservableCollection<Vwcumplehoy>();
        public ObservableCollection<Vwcumplemes> ListaMenoresMes { get; set; }
           = new ObservableCollection<Vwcumplemes>();
        public ObservableCollection<Vwmenoresedad> ListaMenorsDoceAños { get; set; }
            = new ObservableCollection<Vwmenoresedad>();
        public MenoresViewModels()
        {
            VerMenoresCommand = new RelayCommand(VerMenores);
            VerHoyCommand = new RelayCommand(VerHoy);
            VerMesCommand = new RelayCommand(VerMes);
            VerMenoresDoceCommand = new RelayCommand(VerMenoresDoceAños);
            Actualizar();
            ActualizarMenoresHoy();
            ActualizarMenoresMes();

        }

        private void VerMenoresDoceAños()
        {
            ActualizarMenorDoceAños();
            Modo = "verMenoresDoceAños";
            OnPropertyChanged();

        }


        

        private void VerMes()
        {
            ActualizarMenoresMes();
            Modo = "verCumpleañosMes";
            OnPropertyChanged();
        }



        private void VerHoy()
        {
            ActualizarMenoresHoy();
            Modo = "verCumpleañosHoy";
            OnPropertyChanged();

        }

        private void VerMenores()
        {
            Actualizar();
            Modo = "VerMenores";
            OnPropertyChanged();
        }

        public void Actualizar()
        {
            ListaMenores.Clear();
            foreach (var e in context.GetMenores())
            {
                ListaMenores.Add(e);
            }



        }
        public void ActualizarMenoresHoy()
        {
            ListaMenoresHoy.Clear();
            foreach (var item in context.GetMenoresCumplenHoy())
            {
                ListaMenoresHoy.Add(item);
            }
        }
        private void ActualizarMenoresMes()
        {
            ListaMenoresMes.Clear();
            foreach (var item in context.GetMenoresCumplenMes())
            {
                ListaMenoresMes.Add(item);
            }
        }

        private void ActualizarMenorDoceAños()
        {
            ListaMenorsDoceAños.Clear();
            foreach (var item in context.GetMenoresEDad())
            {
                ListaMenorsDoceAños.Add(item);
            }
        }

        public void OnPropertyChanged(string? pop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pop));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}