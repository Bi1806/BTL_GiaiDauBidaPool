
using System;
using System.Net;
using System.Net.Mail;

namespace PoolTournament
{
    public class EmailService
    {
        // Lấy thông tin Gmail từ Environment Variables
        private static readonly string FromEmail =
            Environment.GetEnvironmentVariable("POOL_EMAIL")
            ?? throw new Exception(
                "Chưa cấu hình POOL_EMAIL. Vui lòng xem hướng dẫn trong tài liệu.");

        private static readonly string AppPassword =
            Environment.GetEnvironmentVariable("POOL_EMAIL_PASSWORD")
            ?? throw new Exception(
                "Chưa cấu hình POOL_EMAIL_PASSWORD. Vui lòng xem tài liệu .");

        public static bool SendOTP(string toEmail, string otpCode)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(
                        FromEmail,
                        "Bida Pool Tournament Support"
                    );

                    mail.To.Add(toEmail);
                    mail.Subject = "Mã xác thực khôi phục mật khẩu";

                    mail.Body = $@"
                        <div style='font-family: Arial, sans-serif; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
                            <h2 style='color: #2c3e50;'>Yêu cầu cấp lại mật khẩu</h2>
                            <p>Mã OTP xác thực của bạn là:</p>
                            <h1 style='color: #2980b9; letter-spacing: 4px;'>{otpCode}</h1>
                            <p>Mã này có hiệu lực trong <b>5 phút</b>.</p>
                            <p>Vui lòng không chia sẻ mã này cho bất kỳ ai.</p>
                        </div>";

                    mail.IsBodyHtml = true;

                    using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials =
                            new NetworkCredential(FromEmail, AppPassword);

                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Lỗi gửi email: " + ex.Message
                );

                return false;
            }
        }
    }
}
