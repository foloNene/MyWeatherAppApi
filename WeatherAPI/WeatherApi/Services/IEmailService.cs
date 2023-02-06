using Mail;

namespace WeatherApi.Services
{
    public interface IEmailService
    {
        void SendMail(Message message);
    }
}
