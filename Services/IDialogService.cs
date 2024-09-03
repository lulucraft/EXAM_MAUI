namespace EXAM_MAUI.Services
{
	public interface IDialogService
	{
        Task DisplayAlertAsync(string title, string message, string cancel);

        Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel);
    }
}
