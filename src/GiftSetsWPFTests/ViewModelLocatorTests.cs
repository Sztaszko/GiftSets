using FluentAssertions;
using GiftSetsWPFTests.Mocks;
using GiftSetsWPFTests.Mocks.Views;
using System.Windows;

namespace GiftSetsWPFTests;

public class ViewModelLocatorTests
{
    [StaFact]
    public void PrepareViewModelName_ReturnsSuccess()
    {
        var obj = (DependencyObject) new ViewClassMock();

        var result = ViewModelLocatorMock.PrepareViewModelNameTest(obj);

        result.Should().Be("GiftSetsWPFTests.Mocks.ViewModels.ViewClassMock");
    }
}