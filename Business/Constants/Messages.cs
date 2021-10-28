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
    }
}
