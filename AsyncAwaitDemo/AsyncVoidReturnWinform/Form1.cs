namespace AsyncVoidReturnWinform
{
    public partial class Form1 : Form
    {
        readonly TaskCompletionSource<bool> s_tcs = new TaskCompletionSource<bool>();
        public Form1()
        {
            InitializeComponent();
            button1.Click += OnButtonClicked1;
            button1.Click += OnButtonClicked2Async;
            button1.Click += OnButtonClicked3;
        }

        private void OnButtonClicked1(object? sender, EventArgs e)
        {
            textBox1.Text += $"   Handler 1 is starting...{Environment.NewLine}";
            Task.Delay(1000).Wait();
            textBox1.Text += $"   Handler 1 is done.{Environment.NewLine}";
        }

        private  async void OnButtonClicked2Async(object? sender, EventArgs e)
        {
            textBox1.Text += $"   Handler 2 is starting...{Environment.NewLine}";
            Task.Delay(1000).Wait();
            textBox1.Text += $"   Handler 2 is about to go async...{Environment.NewLine}";
            await Task.Delay(5000);
            textBox1.Text += $"   Handler 2 is done. {Environment.NewLine}";
        }

        private  void OnButtonClicked3(object? sender, EventArgs e)
        {
            textBox1.Text += $"   Handler 3 is starting... {Environment.NewLine}";
            Task.Delay(1000).Wait();
            textBox1.Text += $"   Handler 3 is done.{Environment.NewLine}";
        }
    }
}
