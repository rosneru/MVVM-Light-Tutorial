/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Ui.Desktop"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Logic.Ui
{
  /// <summary>
  /// This class contains static references to all the view models in the
  /// application and provides an entry point for the bindings.
  /// </summary>
  public class ViewModelLocator
  {
    /// <summary>
    /// Initializes a new instance of the ViewModelLocator class.
    /// </summary>
    public ViewModelLocator()
    {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

      ////if (ViewModelBase.IsInDesignModeStatic)
      ////{
      ////    // Create design time view services and models
      ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
      ////}
      ////else
      ////{
      ////    // Create run time view services and models
      ////    SimpleIoc.Default.Register<IDataService, DataService>();
      ////}

      SimpleIoc.Default.Register<MainViewModel>();
      SimpleIoc.Default.Register<ChildViewModel>();
      SimpleIoc.Default.Register<DataErrorInfoViewModel>();
    }

    /// <summary>
    /// Retrieves the view model for the main view
    /// </summary>
    public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

    /// <summary>
    /// Retrieves the view model for the child view model
    /// </summary>
    public ChildViewModel Child => ServiceLocator.Current.GetInstance<ChildViewModel>();

    /// <summary>
    /// Retrieves the view model for the data error info test view
    /// </summary>
    public DataErrorInfoViewModel DataErrorInfo => ServiceLocator.Current.GetInstance<DataErrorInfoViewModel>();


    public static void Cleanup()
    {
      // TODO Clear the ViewModels
    }
  }
}
