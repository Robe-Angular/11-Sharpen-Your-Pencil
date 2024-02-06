using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_Sharpen_Your_Pencil
{
    class Mole
    {
        public delegate void PopUp(int hole, bool show);
        private PopUp popUpCallback;

        private bool hidden;
        public bool Hidden { get { return hidden; } }
        private int timesHit = 0;
        private int timesShown = 0;
        private int hole = 0;
        Random random;

        public Mole (Random random, PopUp popUpCallback)
        {
            if (popUpCallback == null)
                throw new ArgumentException("popUpCallBack can't be null");
            this.random = random;

            this.popUpCallback = popUpCallback;
            hidden = true;
        }

        public void Show()
        {
            timesShown++;
            hidden = false;
            hole = random.Next(5);
            popUpCallback(hole, true);
        }

        public void HideAgain()
        {
            hidden = true;
            popUpCallback(hole, false);
            CheckForGameOver();
        }

        public void Smacked (int holeSmacked)
        {
            if(holeSmacked == hole)
            {
                timesHit++;
                hidden = true;
                CheckForGameOver();
                popUpCallback(hole, false);
            }
        }

        private void CheckForGameOver()
        {
            if(timesShown >= 10)
            {
                popUpCallback(-1, false);
                MessageBox.Show("You scored " + timesHit, "GameOver");
                Application.Exit();
            }
        }




    }
}
