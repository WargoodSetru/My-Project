namespace Convert_Number
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                int user_number = Convert.ToInt32(textBox1.Text);

                if (radioButton1.Checked == true)
                {
                    textBox2.Text = Convert.ToString(user_number, 2);
                }
                else if (radioButton2.Checked == true)
                {
                    textBox2.Text = Convert.ToString(user_number, 8);
                }
                else if (radioButton3.Checked == true)
                {
                    textBox2.Text = Convert.ToString(user_number, 10);
                }
                else if (radioButton4.Checked == true)
                {
                    textBox2.Text = Convert.ToString(user_number, 16);
                }
            }

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
      
            int i = Convert.ToInt32(textBox1.Text);
            textBox2.Text = Convert.ToString(i, 2);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox1.Text);
            textBox2.Text = Convert.ToString(i, 8);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox1.Text);
            textBox2.Text = Convert.ToString(i, 10);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox1.Text);
            textBox2.Text = Convert.ToString(i, 16);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}