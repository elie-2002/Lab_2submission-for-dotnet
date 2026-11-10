namespace program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true; // Shows dots instead of the typed password.
            FormClosed += Form1_FormClosed; // Makes sure the program ends when this window is closed.
        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Ends the whole program when this window is closed.
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btndisplay_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            MessageBox.Show("Your username is " + username + " and the password is " + password);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            if ((username.Trim() != "") && (password.Trim() != ""))
            {
                Form_stocks stock = new Form_stocks();
                stock.Show();
                this.Hide();
                txtusername.Text = "";
                txtpassword.Text = "";
                
            }
            else
            {
                MessageBox.Show("The username and password cannot be empty");
            }
        }
    }
}
