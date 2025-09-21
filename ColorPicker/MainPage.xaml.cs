namespace ColorPicker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
            Color color = Color.FromRgb(0, 0, 0);

            SetBackgroundColor(color);
        }

        private void SlrValue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = rValue.Value;
            var green = gValue.Value;
            var blue = bValue.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetBackgroundColor(color);

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var random = new Random();

            var red = random.Next(0, 255);
            var green = random.Next(0, 255);
            var blue = random.Next(0, 255);

            rValue.Value = (double)red / 255;
            gValue.Value = (double)green / 255;
            bValue.Value = (double)blue / 255;

            var color = Color.FromRgb(red, green, blue);
            
            SetBackgroundColor(color);
        }

        private void SetBackgroundColor(Color color)
        {
            lblInfo.Text = "";

            AppBackground.BackgroundColor = color;

            rgbValue.Text = color.ToHex();

        }

        private async void copyBtn_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(rgbValue.Text);

            lblInfo.Text = "Copied to clipboard";
        }

    }
}
