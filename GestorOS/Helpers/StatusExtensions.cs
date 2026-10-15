using GestorOS.Models;

namespace GestorOS.Helpers
{
    public static class StatusExtensions
    {
        public static string ParaTexto(this StatusOrdem status) => status switch
        {
            StatusOrdem.Aberta => "Aberta",
            StatusOrdem.EmAndamento => "Em Andamento",
            StatusOrdem.Concluida => "Concluída",
            StatusOrdem.Cancelada => "Cancelada",
            _ => status.ToString()

        };

        public static string ParaClasseBagde(this StatusOrdem status) => status switch
        {
            StatusOrdem.Aberta => "bagde-aberta",
            StatusOrdem.EmAndamento => "bagde-andamento",
            StatusOrdem.Concluida => "bagde-concluida",
            StatusOrdem.Cancelada => "bagde-cancelada",
            _ => "bg-secondary"

        };

        public static string ParaIcone(this StatusOrdem status) => status switch
        {
            StatusOrdem.Aberta => "fa-folder-open",
            StatusOrdem.EmAndamento => "fa-gear",
            StatusOrdem.Concluida => "fa-circle-check",
            StatusOrdem.Cancelada => "fa-circle-xmark",
            _ => "fa-circle"

        };
    }
}
