using GiftSetsWPF.ViewModels;
using System.ComponentModel;
using System.Windows;
using GiftSetsWPF.Stores;

namespace GiftSetsWPF.VML;

public class ViewModelLocator
{
    public static bool GetAutoHookedUpViewModel(DependencyObject obj)
    {
        return (bool)obj.GetValue(AutoHookedUpViewModelProperty);
    }

    public static void SetAutoHookedUpViewModel(DependencyObject obj, bool value)
    {
        obj.SetValue(AutoHookedUpViewModelProperty, value);
    }

    public static readonly DependencyProperty AutoHookedUpViewModelProperty = DependencyProperty.RegisterAttached("AutoHookedUpViewModel", 
                                                                                typeof(bool), typeof(ViewModelLocator), 
                                                                            new PropertyMetadata(false, AutoHookedUpViewModelChanged));

    private static void AutoHookedUpViewModelChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        try
        {
            if (!DesignerProperties.GetIsInDesignMode(obj))
            {
                BindViewModelToDataContext(obj);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

    private static void BindViewModelToDataContext(DependencyObject obj)
    {
        object? viewModel;
        var viewModelType = GetViewModelType(obj);

        if (viewModelType.Name == "MainProductsViewModel")
        {
            viewModel = Activator.CreateInstance(viewModelType, new SelectedProductStore());
        }
        else
        {
            viewModel = Activator.CreateInstance(viewModelType);
        }

        ((FrameworkElement)obj).DataContext = viewModel;
    }

    private static Type GetViewModelType(DependencyObject obj)
    {
        var viewTypeName = PrepareViewModelName(obj);
        var viewModelTypeName = viewTypeName + "Model";
        var viewModelType = Type.GetType(viewModelTypeName) ?? throw new InvalidOperationException($"Failed to get view model type for {viewModelTypeName}");
        return viewModelType;
    }

    protected static string PrepareViewModelName(DependencyObject obj)
    {
        string viewModelName;

        var viewType = obj.GetType();
        viewModelName = viewType.FullName ?? throw new InvalidOperationException($"Failed to get view type name for {obj}");
        viewModelName = viewModelName.Replace(".Views.", ".ViewModels.");

        return viewModelName;
    }
}
