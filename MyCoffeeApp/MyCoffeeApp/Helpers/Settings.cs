namespace MyCoffeeApp.Helpers;

public static class Settings
{
    // 0 = default, 1 = light, 2 = dark
    const int theme = 0;
    public static int Theme
    {
        get => Preferences.Get(nameof(Theme), theme);
        set => Preferences.Set(nameof(Theme), value);
    }
}
