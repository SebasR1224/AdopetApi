namespace Application.Common.Interfaces.Models;

public static class EmailTemplateModel
{
    public static string GetVerificationEmailTemplate(string userName, string verificationLink)
    {
        return $@"
            <!DOCTYPE html>
            <html>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Verificar Email</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            line-height: 1.6;
                            margin: 0;
                            padding: 0;
                            background-color: #f6f6f6;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 20px auto;
                            background-color: #ffffff;
                            border-radius: 8px;
                            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                            overflow: hidden;
                        }}
                        .header {{
                            background-color: #5B53D1;
                            color: white;
                            padding: 20px;
                            text-align: center;
                        }}
                        .content {{
                            padding: 20px;
                            color: #444444;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 12px 24px;
                            background-color: #5B53D1;
                            color: white;
                            text-decoration: none;
                            border-radius: 4px;
                            margin: 20px 0;
                        }}
                        .footer {{
                            background-color: #f9f9f9;
                            padding: 15px;
                            text-align: center;
                            font-size: 12px;
                            color: #666666;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Verificación de Email</h1>
                        </div>
                        <div class='content'>
                            <h2>¡Hola {userName}!</h2>
                            <p>Gracias por registrarte en <strong>Adopet</strong>, Uniendo Comunidades y Rescatistas.</p>
                            Para completar tu registro, por favor verifica tu dirección de email.</p>

                            <div style='text-align: center;'>
                                <a href='{verificationLink}' class='button'>Verificar Email</a>
                            </div>

                            <p>O copia y pega el siguiente enlace en tu navegador:</p>
                             <a href='{verificationLink}'>{verificationLink}</a>

                            <p>Si no has creado una cuenta, puedes ignorar este email.</p>
                        </div>
                        <div class='footer'>
                            <p>Este es un email automático, por favor no respondas a este mensaje.</p>
                            <p>&copy; {DateTime.Now.Year} Tu Aplicación. Todos los derechos reservados.</p>
                        </div>
                    </div>
                </body>
            </html>";
    }
}