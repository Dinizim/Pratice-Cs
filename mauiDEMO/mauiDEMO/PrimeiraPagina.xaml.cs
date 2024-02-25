namespace mauiDEMO;

public partial class PrimeiraPagina : ContentPage
{
	public PrimeiraPagina()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
    }
}