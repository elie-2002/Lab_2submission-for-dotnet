using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace program
{

    public partial class Form5 : Form
    {
        private enum IdentificationQuestion
        {
            ConvexCup,
            ForestAfterConvexCup,
            Ring,
            GillsAfterConvexCup,
            ForestAfterNoConvexCup,
            GillsAfterNoConvexCup
        }
        private IdentificationQuestion currentQuestion;


        public Form5()
        {
            InitializeComponent();
            ResetIdentification();
            FormClosed += Form5_FormClosed; // Makes sure the program ends when this window is closed.
        }

        private void Form5_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Ends the whole program when this window is closed.
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            switch (currentQuestion)
            {
                case IdentificationQuestion.ConvexCup:
                    currentQuestion =
                        IdentificationQuestion.ForestAfterConvexCup;
                    lblQuestion.Text =
                        "Does the mushroom grow in a forest?";
                    break;

                case IdentificationQuestion.ForestAfterConvexCup:
                    currentQuestion = IdentificationQuestion.Ring;
                    lblQuestion.Text =
                        "Does the mushroom have a ring?";
                    break;

                case IdentificationQuestion.Ring:
                    Identify("The mushroom is Amanite tue-mouche.");
                    break;

                case IdentificationQuestion.GillsAfterConvexCup:
                    Identify("The mushroom is Agaric Jaunissant.");
                    break;

                case IdentificationQuestion.ForestAfterNoConvexCup:
                    currentQuestion =
                        IdentificationQuestion.GillsAfterNoConvexCup;
                    lblQuestion.Text =
                        "Does the mushroom have gills?";
                    break;

                case IdentificationQuestion.GillsAfterNoConvexCup:
                    Identify("The mushroom is Girolle.");
                    break;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            switch (currentQuestion)
            {
                case IdentificationQuestion.ConvexCup:
                    currentQuestion =
                        IdentificationQuestion.ForestAfterNoConvexCup;
                    lblQuestion.Text =
                        "Does the mushroom grow in a forest?";
                    break;

                case IdentificationQuestion.ForestAfterConvexCup:
                    currentQuestion =
                        IdentificationQuestion.GillsAfterConvexCup;
                    lblQuestion.Text =
                        "Does the mushroom have gills?";
                    break;

                case IdentificationQuestion.Ring:
                    Identify("The mushroom is Pied bleu.");
                    break;

                case IdentificationQuestion.GillsAfterConvexCup:
                    Identify("The mushroom could not be identified.");
                    break;

                case IdentificationQuestion.ForestAfterNoConvexCup:
                    Identify("The mushroom is Coprin chevelu.");
                    break;

                case IdentificationQuestion.GillsAfterNoConvexCup:
                    Identify("The mushroom is Cèpe de Bordeaux.");
                    break;
            }
        }
        private void ResetIdentification()
        {
            currentQuestion = IdentificationQuestion.ConvexCup;

            lblQuestion.Text =
                "Does the mushroom have a convex cup?";
        }
        private void Identify(string result)
        {
            MessageBox.Show(result);
            ResetIdentification();
        }
    }
}