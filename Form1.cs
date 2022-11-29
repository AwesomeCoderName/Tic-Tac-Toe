using System.CodeDom;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using TicTac.ObjectModels;

/* TO DO LIST
 * NOTHING!!!!!
 */

namespace TicTac
{
    public partial class Form1 : Form
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Player whoIsPlaying = new Player(); // delares a player object
        int turns = 1;
        int[,] winningConditions = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 },
                                     { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 },
                                     { 1, 5, 9 }, { 3, 5, 7 } };
        public Form1() { genesis(); }
        private void genesis()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            player1.Color = "Green";
            player1.Name = "Adam";
            player1.Piece = "X";

            player2.Name = "Eve";
            player2.Color = "Purple";
            player2.Piece = "O";
        }

        private void btnConverter(object sender, EventArgs e) // this method is being called first in Form1.Designers.cs
        {// Main objective: takes in which button is currently being pressed
            play();
            TestMethod(sender as Button); // turns the text "button5" into a button and sends it to TestMethod();
        }
        public void play()
        {
            // Repeatedly initializes who is playing 9 times in this loop
            whoIsPlaying = (turns % 2 == 0) ? player2 : player1; // if  "turns" is even/true it's player 2's turn else it is player 1's and stores all that player attributes in whoIsPlaying
            // button_Click(whoIsPlaying)
            if (turns == 9)
            {
                label1.Text = "It's a draw!!!";
                resetForm();
            }
        }
        private void TestMethod(Button? button) // takes in a button object
        {
            //whoIsPlaying.Conquered.Append(button.TabIndex);
            // if space is occupied. The player cannot change from X -> O and vis versa
            if (player1.Conquered.Contains(button!.TabIndex) || player2.Conquered.Contains(button.TabIndex))
            {  // If they or opponent already owns that piece  they can't own it 
                label1.Text = "That area is already conquered, dummy! Try again...";
                turns--;
            }
            else
            {
				label1.Text = " ";
				button!.Text = whoIsPlaying.Piece; // changes the button being pressed to the Player1/2's playing piece                                  //        button!.ForeColor = ;
                button!.ForeColor = Color.FromName(whoIsPlaying.Color);
				if (whoIsPlaying.Conquered != null)
                {
                    int x = whoIsPlaying.Conquered.Count; // stores the button being pressed to conquered list of player x; button!.TabIndex should store an integer
                                                          //whoIsPlaying.Conquered[x] = button!.TabIndex;
                    if (!whoIsPlaying.Conquered.Contains(button.TabIndex))
                        whoIsPlaying.Conquered.Add(button.TabIndex);
                }
                else
                {
                    whoIsPlaying.Conquered![0] = button!.TabIndex;
                }
            }
            judgement(); // judges if theres a winner
            turns++;
        }

        public void judgement()
        {
            for (int row = 0; row < 8; row++)
            {
                bool[] miniJudge = { false, false, false };
                for (int col = 0; col < 3; col++)
                {
                    if (whoIsPlaying.Conquered.Contains(winningConditions[row, col]))
                    {
                        miniJudge[col] = true;
                    }
                }
                if (miniJudge[0] && miniJudge[1] && miniJudge[2])
                {
                    resetForm();
                }
            }

        }

        public void resetForm()
        {
            label3.Visible = true;
            label3.Text = "Winner! Winner! " + whoIsPlaying.Name;
            label2.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            pictureBox2.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.BackColor = Color.FromArgb(25, Color.Black);
        }

        private void replayFunction(object sender, EventArgs e)
        {
            var temp = sender as Button;
            if (temp!.Text.Equals("YES")) {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }

    }
}
