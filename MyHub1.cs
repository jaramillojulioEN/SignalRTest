using Microsoft.AspNet.SignalR;
using signal_test.Models.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace signal_test
{

    public class MyHub1 : Hub
    {
        public void SendMessage(string user, string message)
        {

            Clients.All.broadcastMessage(user, message);
        }

        public void EnviarNuevosNombres(IEnumerable<test> nombres)
        {
            // Envía el evento a todos los clientes conectados
            Clients.All.NuevosNombres(nombres);
        }

    }
}