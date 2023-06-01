using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Web.Models;
namespace Web.Shared.Themes;

public partial class ThemesMenu
{
    private readonly List<string> _primaryColors = new()
{
    Colors.Green.Default,
    Colors.Blue.Default,
    Colors.BlueGrey.Default,
    Colors.Purple.Default,
    Colors.Orange.Default,
    Colors.Red.Default
};

    [EditorRequired][Parameter] public bool ThemingDrawerOpen { get; set; }
    [EditorRequired][Parameter] public EventCallback<bool> ThemingDrawerOpenChanged { get; set; }
    [EditorRequired][Parameter] public ThemeManagerModels ThemeManager { get; set; }
    [EditorRequired][Parameter] public EventCallback<ThemeManagerModels> ThemeManagerChanged { get; set; }

    private async Task UpdateThemePrimaryColor ( string color )
    {
        ThemeManager.PrimaryColor = color;
        await ThemeManagerChanged.InvokeAsync(ThemeManager);
    }

    private async Task ToggleDarkLightMode ( bool isDarkMode )
    {
        ThemeManager.IsDarkMode = isDarkMode;
        await ThemeManagerChanged.InvokeAsync(ThemeManager);
    }
}

