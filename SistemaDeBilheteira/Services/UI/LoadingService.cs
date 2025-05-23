namespace SistemaDeBilheteira.Services.UI;

public class LoadingService
{
    public event Action? OnLoadingChanged;

    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
                OnLoadingChanged?.Invoke();
            }
        }
    }
}