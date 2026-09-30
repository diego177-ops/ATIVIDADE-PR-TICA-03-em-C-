using System;

namespace RotaPrime.Classes
{
    public class HistoricoEntrega
    {
        public DateTime Data { get; set; }
        public string Status { get; set; }

        public HistoricoEntrega()
        {
        }

        public HistoricoEntrega(string status)
        {
            Data = DateTime.Now;
            Status = status;
        }

        public void MostrarHistorico()
        {
            Console.WriteLine(
                Data.ToString("dd/MM/yyyy HH:mm") +
                " - " +
                Status
            );
        }
    }
}