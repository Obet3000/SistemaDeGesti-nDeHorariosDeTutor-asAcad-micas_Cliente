using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioReservacion;
using System.Collections.Generic;
using System;
using System.Linq;

public class GestorDeTurnos
{
    public List<TurnoDTO> GenerarTurnos()
    {
        var turnos = new List<TurnoDTO>();
        var inicio = new TimeSpan(8, 0, 0); 
        var fin = new TimeSpan(18, 0, 0); 

        for (var tiempo = inicio; tiempo <= fin; tiempo = tiempo.Add(new TimeSpan(0, 15, 0))) // Incrementa cada 15 minutos
        {
            turnos.Add(new TurnoDTO
            {
                Hora = tiempo,
                Disponible = true
            });
        }
        return turnos;
    }

    public void ActualizarTurnosConReservaciones(List<TurnoDTO> turnos, TurnoDTO[] turnosOcupados)
    {
        foreach (var turnoOcupado in turnosOcupados)
        {
            var turno = turnos.FirstOrDefault(t => t.Hora == turnoOcupado.Hora);
            if (turno != null)
            {
                turno.Disponible = false;
            }
        }
    }
}
