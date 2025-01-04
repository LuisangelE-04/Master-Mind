namespace mastermind.GUI;

public partial class HowToPlayPage : ContentPage
{
	public HowToPlayPage()
	{
		InitializeComponent();
	}

	private async void CheckSourceCodeClicked(object sender, EventArgs e) {
		await Launcher.Default.OpenAsync("https://www.github.com/LuisangelE-04/Master-Mind");
	}
}