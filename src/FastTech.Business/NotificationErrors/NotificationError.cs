using MediatR;

namespace FastTech.Aplication.NotificationErrors;

public class NotificationError : INotification
{

    public string NomeProcesso { get; set; }
    public string Messagem { get; set; }

    public NotificationError(string messagem)
    {
        Messagem = "Processo Padrão";
    }
    public NotificationError(string nomeProcesso, string messagem)
    {
        NomeProcesso = nomeProcesso;
        Messagem = messagem;
    }

}
