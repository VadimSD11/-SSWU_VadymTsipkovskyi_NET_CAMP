namespace Home_task_7b_windowsformsapp
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// У лівому верхньому куті секундомер після натискання кнопки START форма змінює кольори відповідно до світлофора,
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrafficLight tl1 = new TrafficLight(0.50f, 0.2f, 0.7f);
            TrafficLight tl2 = new TrafficLight(0.50f, 0.2f, 0.7f);
            TrafficLight tl3 = new TrafficLight(0.50f, 0.2f, 0.7f);
            TrafficLight tl4 = new TrafficLight(0.50f, 0.2f, 0.7f);
            Crossroads crossroads= new Crossroads(tl1,tl2,tl3,tl4,0,5);
            crossroads.setLabels(label10, label7, label8, label6, label5);
            crossroads.SetForm(this);
            crossroads.StartSimulation();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}