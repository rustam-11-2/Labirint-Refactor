using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    public class SoundManager
    {
        SoundPlayer completedLevel;
        SoundPlayer corChoice;
        SoundPlayer wrongChoice;

        public SoundManager()
        {
            completedLevel = new SoundPlayer("Sounds//soundFinishedLevel.wav");
            corChoice = new SoundPlayer("Sounds//correct_choice.wav");
            wrongChoice = new SoundPlayer("Sounds//wrong_choice.wav");
        }

        public void PlayCorrect()
        {
            corChoice.Play();
        }

        public void PlayWrong()
        {
            wrongChoice.Play();
        }

        public void PlayCompletedLevel()
        {
            completedLevel.Play();
        }
    }
}
