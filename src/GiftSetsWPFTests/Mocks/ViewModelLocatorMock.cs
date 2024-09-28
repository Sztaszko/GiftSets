using GiftSetsWPF.VML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GiftSetsWPFTests.Mocks;

public class ViewModelLocatorMock : ViewModelLocator
{
    public static string PrepareViewModelNameTest(DependencyObject obj)
    {
        return PrepareViewModelName(obj);
    }
}