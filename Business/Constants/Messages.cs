using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        #region Success Messages
        public static string SuccessAdded = "Ekleme Basarili.";
        public static string SuccessUpdated = "Guncelleme Basarili.";
        public static string SuccessDeleted = "Silme basarili.";
        public static string SuccessListed = "Listeleme Basarili.";
        #endregion

        #region Error Messages
        public static string NameInvalidError = "Girilen ad gecersiz.";
        public static string MaintenanceTimeError = "Sistem bakimdadir.";
        public static string ErrorAdded = "Ekleme başarısız.";
        public static string ErrorUpdated = "Guncelleme başarısız.";
        public static string ErrorDeleted = "Silme başarısız.";
        public static string ErrorListed = "Listeleme başarısız.";
        internal static string NotFound = "Kayıt bulunamadı.";
        internal static string RecordAlreadyExist = "Bu kayıt zaten eklenmiştir.";
        #endregion

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
     }
}
