namespace AsyncScenarios2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Calculate();

            Download();

        }
        private string calculateText = "";
        private void Calculate()
        {
            DamageResult CalculateResult()
            {
                calculateText += $"Begin CalculateResult: ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}{Environment.NewLine}";
                //Simulate long running task
                Thread.Sleep(5000);
                calculateText += $"End CalculateResult: ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}{Environment.NewLine}";
                return new DamageResult()
                {
                    
                };
            };

            btnCalculate.Click += async (sender, e) =>
            {
                textBox2.Clear();
                calculateText += $"Begin click: ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}{Environment.NewLine}";
                btnCalculate.Enabled = false;
                var damageResult = await Task.Run(() => CalculateResult());
                btnCalculate.Enabled = true;
                calculateText += $"End click: ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}{Environment.NewLine}";
                textBox2.Text = calculateText + $"Damage: {damageResult.Damage}";


            };
        }

        private void Download()
        {
            btnDownload.Click += async (sender, e) =>
            {
                textBox1.Clear();
                var httpClient = new HttpClient();
                try
                {
                    var html = await httpClient.GetStringAsync(textBox3.Text);
                    textBox1.Text = html;

                }
                catch (Exception ex)
                {

                    textBox1.Text = ex.Message;
                }

            };
        }
    }

    class DamageResult
    {
        public int Damage
        {
            get { return 0; }
        }
    }
}
