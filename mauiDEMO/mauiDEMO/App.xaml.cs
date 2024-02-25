namespace mauiDEMO
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           // var nav_page = new NavigationPage(new PrimeiraPagina());
            

            MainPage = new TabbedPageDEMO();

        }
    }
}
