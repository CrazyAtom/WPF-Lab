using Prism.Ioc;
using PrismStep1.Models;
using PrismStep1.Views;
using System.Diagnostics;
using System.Windows;

namespace PrismStep1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            var win1 = Container.Resolve<MainWindow>();
            var win2 = Container.Resolve<MainWindow>();
            if (win1.Equals(win2))
            {
                Debug.WriteLine("Equals");
            }
            else
            {
                Debug.WriteLine("Not Equals");
            }
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MainWindow>();
            //containerRegistry.RegisterSingleton<Person>();
            var person = new Person { Id = 1, Name = "person1" };
            containerRegistry.RegisterInstance(person, "p1");
            containerRegistry.RegisterInstance(person, "p2");
        }

        /// <summary>
        /// 뷰모델 로케이터 이름 설정
        /// </summary>
        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();

        //    Prism.Mvvm.ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
        //    {
        //        string viewName = viewType.Name;
        //        if (viewName == null)
        //        {
        //            return null;
        //        }

        //        if (viewName.EndsWith("View"))
        //        {
        //            viewName = viewName.Substring(0, viewName.Length - 4);
        //        }

        //        viewName = viewName.Replace(".Views.", ".ViewModels.");
        //        //viewName = viewName.Replace(".Controls.", ".ControlViewModels.");
        //        string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        //        string viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
        //        return Type.GetType(viewModelName);
        //    });
        //}
    }
}
