namespace SistemaDeBilheteira.Services.UI;

/**
 * NotificationService.cs
 * 
 * This class is used to manage notifications in the application.
 * It contains an event that can be triggered to notify subscribers.
 *
 */	
public class NotificationService
{
    public event Action<string>? OnNotify;

    public void Notify(string message)
    {
        OnNotify?.Invoke(message);
    }
}