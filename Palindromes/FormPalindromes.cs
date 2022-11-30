using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palindromes
{
    public partial class FormPalindromes : Form
    {
        public FormPalindromes()
        {
            InitializeComponent();
        }


        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\palindromes.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    if (CheckIfAPalindrome(line))
                    {
                        TxtResult.Text += line + " - " + "is a palindrome." + Environment.NewLine;
                    }
                    else
                    {
                        TxtResult.Text += line + " - " + "is not a palindrome." + Environment.NewLine;
                    }      
                }
            }
        }

        private bool CheckIfAPalindrome(string text)
        {
            string chars = "([{<";
            string charsReversed = ")]}>";

            bool palindrome = false;
            string letter = "";
            string oppositeLetter = "";


            for (int i = 0; i < text.Length / 2; i++)
            {
                letter = text.Substring(i, 1);
                oppositeLetter = text.Substring(text.Length - (i + 1), 1);

                //Check if the letter is one of the characters ([{<
                if (chars.IndexOf(letter) != -1)
                {
                    if (charsReversed.IndexOf(oppositeLetter) == chars.IndexOf(letter))
                    {
                        palindrome = true;
                    }
                    else
                    {
                        palindrome = false;
                    }                
                }
                else
                {
                    if (letter != oppositeLetter)
                    {
                        palindrome = false;
                    }
                    else
                    {
                        palindrome = true;
                    }
                }
            }
            return palindrome;
        }
    }
}
