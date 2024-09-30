using System.Windows;
using System.Windows.Controls;

namespace ChrisKaczor.Wpf.Windows;

public class CategoryPanelBase : UserControl
{
    protected Window? ParentWindow;

    protected CategoryPanelBase()
    {
    }

    public virtual string? CategoryName => null;

    protected bool HasLoaded { get; private set; }

    public virtual void LoadPanel(Window parentWindow)
    {
        ParentWindow = parentWindow;
    }

    protected void MarkLoaded()
    {
        HasLoaded = true;
    }
}