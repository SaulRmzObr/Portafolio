using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
    public class ServicioEmailSendGrid : IServicioEmail
    {
        private readonly IConfiguration _configuration;

        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Enviar(ContactoViewModel contacto)
        {
            var llaveApi = _configuration.GetValue<string>("SENDGRID_APIKEY");
            var emailRemitente = _configuration.GetValue<string>("SENDGRID_EMAIL_REMITENTE");
            var nombreRemitente = _configuration.GetValue<string>("SENDGRID_NOMBRE_REMITENTE");

            var cliente = new SendGridClient(llaveApi);
            var remitente = new EmailAddress(emailRemitente, nombreRemitente);
            var asunto = $"El cliente {contacto.sEmail} quiere contactarte";
            var para = new EmailAddress(emailRemitente, nombreRemitente);
            var mensajeTextoPlano = contacto.sMensaje;
            var contenidoHtml = @$"De: {contacto.sNombreCompleto} -
Email: {contacto.sEmail}
Mensaje: {contacto.sMensaje}";
            var emailSencillo = MailHelper.CreateSingleEmail(remitente, para, asunto, mensajeTextoPlano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(emailSencillo);
        }
    }
}
