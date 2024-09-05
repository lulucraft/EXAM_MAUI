using EXAM_MAUI.Context.Models;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace EXAM_MAUI.ViewModels
{
    [QueryProperty(nameof(Context.Models.Invite), "data")]
    public partial class EditionInviteViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Invite _invite = new();

        public EditionInviteViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : base(dialogService, navigationService, inviteService, evenementService)
        {
            GenerateCodeInvite();
        }

        [RelayCommand]
        private async Task EnregistrerAsync()
        {
            string? nom = Invite.NomInvite;

            if (string.IsNullOrEmpty(nom))
            {
                await DialogService.DisplayAlertAsync("Erreur", "Le nom est vide", "Ok");
                return;
            }

            string? prenom = Invite.PrenomInvite;

            if (string.IsNullOrEmpty(prenom))
            {
                await DialogService.DisplayAlertAsync("Erreur", "Le prénom est vide", "Ok");
                return;
            }

            string? email = Invite.EmailInvite;

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                await DialogService.DisplayAlertAsync("Erreur", "L'adresse email n'est pas au bon format", "Ok");
                return;
            }

            string? telephone = Invite.TelephoneInvite;

            if (string.IsNullOrEmpty(telephone) || !Regex.IsMatch(telephone, @"^(?:0|\+33)[1-9]\d{8}$"))
            {
                await DialogService.DisplayAlertAsync("Erreur", "Le numéro de téléphone n'est pas au bon format", "Ok");
                return;
            }

            if (Invite.IdInvite == 0)
            {
                // Si le CodeInvite généré est identique à un déjà existant
                Invite? inv = InviteService!.GetInvite(Invite.CodeInvite).FirstOrDefault();
                if (inv != null)
                {
                    // Regénération d'un code aléatoire
                    GenerateCodeInvite();
                    // Un événement porte déjà le code entré
                    await DialogService.DisplayAlertAsync("Erreur", $"Un invité porte déjà le code {Invite.CodeInvite}, je t'en régénère", "Ah cool");
                    return;
                }

                // Mode edition
                await InviteService!.CreateInviteAsync(Invite);
            }
            else
            {
                // Mode ajoutgq
                InviteService!.UpdateInvite(Invite);
            }

            await InviteService!.SaveChangesAsync();

            // Envoi mail avec CodeInvite
            _ = SendEmailAsync(Invite.EmailInvite, "Votre accès Invité", $"Voici votre code d'invité : {Invite.CodeInvite}");
            
            await NavigationService.GoBackAsync();

        }

        [RelayCommand]
        private async Task AnnulerAsync()
        {
            //DbContext.ChangeTracker.Clear(); // Permet d'oublier les changements
            await NavigationService.GoBackAsync();
        }

        private void GenerateCodeInvite()
        {
            Random random = new();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[6];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            Invite.CodeInvite = new string(stringChars);
        }


        private async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                string fromEmail = "jeanmi@akrone.fr";
                string password = "34rV880SuCqXDA26969";

                // Configuration client SMTP
                SmtpClient smtpClient = new SmtpClient("mail.champatux.fr")
                {
                    Port = 465, // Port SMTP
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                // Crée le message
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true, // Si tu veux envoyer du HTML
                };
                mailMessage.To.Add(toEmail);

                // Envoyer l'e-mail de façon asynchrone
                await smtpClient.SendMailAsync(mailMessage);

                Console.WriteLine("E-mail envoyé avec succès !");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite lors de l'envoi de l'e-mail : {ex.Message}");
            }
        }
    }
}