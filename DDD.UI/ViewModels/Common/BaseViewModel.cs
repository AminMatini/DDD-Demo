using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DDD.UI.ViewModels.Common
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// عنوان صفحه
        /// </summary>
        public virtual string PageTitle => string.Empty;
        
        /// <summary>
        /// رویداد تغییرات پراپرتی ها
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// ارسال تغییرات از ویو مدل به ویو
        /// </summary>
        protected void Notify([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
