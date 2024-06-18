using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioReservacion;
using System.Collections.Generic;
using System;
using System.Linq;

/**
 * Clase responsable de gestionar los turnos de reservaciones.
 * Modificado por: Obet Jair Hernandez Gonzalez
 * Fecha de modificación: 18-06-2024
 */
public class GestorDeTurnos
{
    
     // Genera una lista de turnos de 15 minutos entre las 8:00 AM y las 6:00 PM.
     
    public List<TurnoDTO> GenerarTurnos()
    {
        var turnos = new List<TurnoDTO>();
        var inicio = new TimeSpan(8, 0, 0);
        var fin = new TimeSpan(18, 0, 0);

        for (var tiempo = inicio; tiempo <= fin; tiempo = tiempo.Add(new TimeSpan(0, 15, 0)))
        {
            turnos.Add(new TurnoDTO
            {
                Hora = tiempo,
                Disponible = true
            });
        }
        return turnos;
    }

     // Actualiza una lista de turnos marcando como no disponibles aquellos que ya están ocupados.
     
    public void ActualizarTurnosConReservaciones(List<TurnoDTO> turnos, TurnoDTO[] turnosOcupados)
    {
        if (turnos == null)
        {
            throw new ArgumentNullException(nameof(turnos), "La lista de turnos no puede ser nula.");
        }

        if (turnosOcupados == null)
        {
            throw new ArgumentNullException(nameof(turnosOcupados), "El arreglo de turnos ocupados no puede ser nulo.");
        }

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
