using System.Collections.Generic;
using System.Windows.Controls;

namespace ChrisKaczor.Wpf.Windows;

public partial class CategoryWindow
{
    private readonly List<CategoryPanelBase> _categoryPanels;

    public CategoryWindow(List<CategoryPanelBase> categoryPanels, string title, string closeButtonText)
    {
        InitializeComponent();

        Title = title;
        CloseButton.Content = closeButtonText;

        _categoryPanels = categoryPanels;

        // Load the category list
        LoadCategories();
    }

    private void LoadCategories()
    {
        // Loop over each panel
        foreach (var optionsPanel in _categoryPanels)
        {
            // Tell the panel to load itself
            optionsPanel.LoadPanel(this);

            // Add the panel to the category ist
            CategoryListBox.Items.Add(new CategoryListItem(optionsPanel));

            // Set the panel into the right side
            ContentControl.Content = optionsPanel;
        }

        // Select the first item
        CategoryListBox.SelectedItem = CategoryListBox.Items[0];
    }

    private void SelectCategory(CategoryPanelBase panel)
    {
        // Set the content
        ContentControl.Content = panel;
    }

    private void HandleSelectedCategoryChanged(object sender, SelectionChangedEventArgs e)
    {
        // Select the right category
        SelectCategory(((CategoryListItem)CategoryListBox.SelectedItem).Panel);
    }

    private class CategoryListItem(CategoryPanelBase panel)
    {
        public CategoryPanelBase Panel { get; } = panel;

        public override string? ToString()
        {
            return Panel.CategoryName;
        }
    }
}