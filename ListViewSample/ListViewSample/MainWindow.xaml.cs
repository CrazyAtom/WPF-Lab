using System.Windows;

namespace ListViewSample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Animal> _list;
    public MainWindow()
    {
        InitializeComponent();

        _list = new List<Animal>
        {
            new Animal { IsChecked=true, Name="Cat", Type="animal", ImagePath=@"Images\cat.png"},
            new Animal { IsChecked=false, Name="Dog", Type="animal", ImagePath=@"Images\dog.png"},
            new Animal { IsChecked=true, Name="Fish", Type="fish", ImagePath=@"Images\fish.png"},
            new Animal { IsChecked=false, Name="Flower", Type="plant", ImagePath=@"Images\flower.png"},
        };
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        ListView01.ItemsSource = _list;
        ListView02.ItemsSource = _list;
        ListBox.ItemsSource = _list;
        DataGrid.ItemsSource = _list;
    }
}