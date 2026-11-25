using Lab09.Model;

namespace Lab09.Services
{
    public interface IWindowService
    {
        bool OpenEditUserDialog(User userCopy);
        void OpenAboutWindow();
        bool Confirm(string message, string title);
    }
}
