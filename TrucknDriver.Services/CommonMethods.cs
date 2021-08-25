using AutoMapper;
using TrucknDriver.CommonModels;
using TrucknDriver.Entities.Models;
using TrucknDriver.Utilities.ApiResponse;
using TrucknDriver.Utilities.Model.Settings;
using Exceptionless;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace TrucknDriver.Services
{
    public class CommonMethods
    {
        #region
        private readonly UserManager<AspNetUserModel> _userManager;
        private readonly IOptions<AppSettings> _appSettings;

        public CommonMethods(IOptions<AppSettings> appSettings, UserManager<AspNetUserModel> userManager)
        {
            _userManager = userManager;
            _appSettings = appSettings;
        }

        #endregion
        public async Task<string> GenerateResetPasswordToken(AspNetUserModel userResult)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(userResult);
            return token;
        }

        public async Task<IdentityResult> SetPassword(string emailAddress, string PasswordHash)
        {

            var user = await _userManager.FindByEmailAsync(emailAddress);
            var token = await GenerateResetPasswordToken(user);
            if (user == null)
                return IdentityResult.Success;
            var resetPassResult = await _userManager.ResetPasswordAsync(user, token, PasswordHash);

            return resetPassResult;

        }

        public void SendMail(string Email, string htmlResponse, string Subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_appSettings.Value.FromEmailAddress);
                message.To.Add(new MailAddress(Email));
                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Body = htmlResponse;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = _appSettings.Value.SMTPUrl;
                smtp.Port = _appSettings.Value.Port;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(_appSettings.Value.FromEmailAddress, _appSettings.Value.EmailPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Send(message);

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().SetMessage(ex.Message);
            }
        }
        public string Encrypt(string inputText)
        {
            //string EncryptionKey = _appSettings.Value.EncryptionKey;
            //byte[] keybytes = Encoding.ASCII.GetBytes(EncryptionKey.Length.ToString());
            //RijndaelManaged rijndaelCipher = new RijndaelManaged();
            //byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            //PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(EncryptionKey, keybytes);
            //using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            //{
            //    using (MemoryStream mstrm = new MemoryStream())
            //    {
            //        using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
            //        {
            //            cryptstm.Write(plainText, 0, plainText.Length);
            //            cryptstm.Close();
            //            return Convert.ToBase64String(mstrm.ToArray());
            //        }
            //    }
            //}
            Byte[] stringBytes = System.Text.Encoding.Unicode.GetBytes(inputText);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public string Decrypt(string encryptText)
        {
            try
            {
                // var userId = RemoveWhitespace(encryptText);
                //string encryptionkey = _appSettings.Value.EncryptionKey;
                //byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
                //RijndaelManaged rijndaelCipher = new RijndaelManaged();
                //byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(" ", "+"));
                //PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
                //using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
                //{
                //    using (MemoryStream mstrm = new MemoryStream(encryptedData))
                //    {
                //        using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
                //        {
                //            byte[] plainText = new byte[encryptedData.Length];
                //            int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
                //            return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                //        }
                //    }
                //}
                int numberChars = encryptText.Length;
                byte[] bytes = new byte[numberChars / 2];
                for (int i = 0; i < numberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(encryptText.Substring(i, 2), 16);
                }
                return System.Text.Encoding.Unicode.GetString(bytes);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public string GetFilePath(IFormFile formFile,string FileType, string FileName)
        {
            string storagePath = _appSettings.Value.ImageStoragePath;
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }
            string profilePicDir = Path.Combine(storagePath, FileType);
            if (!Directory.Exists(profilePicDir))
            {
                Directory.CreateDirectory(profilePicDir);
            }

            string Extension = System.IO.Path.GetExtension(formFile.FileName).Trim('.');
            var fileKey = FileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + Extension;
            var filePath = Path.Combine(profilePicDir, fileKey);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            return filePath;
        }
    }
}
