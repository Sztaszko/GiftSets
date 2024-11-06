using System.Windows;

namespace GiftSetsWPFTests.Mocks;

public class ViewModelLocatorMock : ViewModelLocator
{
    public static string PrepareViewModelNameTest(DependencyObject obj)
    {
        return PrepareViewModelName(obj);
    }
}