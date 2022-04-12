namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            //SynchronizationContext? main=SynchronizationContext.Current;

            if (int.TryParse(txtA.Text, out int a) && int.TryParse(txtB.Text, out int b))
            {
                //int result = LongAdd(a, b);
                //UpdateAnswer(result);
                //Task.Run(() => LongAdd(a, b))
                //    .ContinueWith((pt) =>
                //    {
                //        main?.Post(UpdateAnswer!, pt.Result);
                //        //UpdateAnswer(pt.Result);
                //    });

                // int result = await LongAddAsync(a, b);//.ConfigureAwait(false);


                // Deadlock
                int result = DoeIetsAsync(a, b).Result;
                UpdateAnswer(result);   
            }
        }

        private async Task<int> DoeIetsAsync(int a, int b)
        {
            return await LongAddAsync(a, b);
        }
        private void UpdateAnswer(object result)
        {
            lblAnswer.Text = result.ToString();
        }

        private int LongAdd(int a, int b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        private Task<int> LongAddAsync(int a, int b)
        {
            return Task.Run(() => LongAdd(a, b));
        }
    }
}