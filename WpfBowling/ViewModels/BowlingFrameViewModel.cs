using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfBowling.Exceptions;
using WpfBowling.Models;

namespace WpfBowling.ViewModels
{
    public class BowlingFrameViewModel : ViewModelBase
    {
        private BowlingFrameModel _bowlingFrame;
        private BowlingScoreBoardViewModel _parent;

        public string FirstThrow
        {
            get { return _bowlingFrame.FirstThrow; }
            set 
            {
                try
                {
                    //updating the total number of empty frames for button enable
                    updateEmptyFramesCount();

                    //setting the throw
                    _bowlingFrame.FirstThrow = value;
                    //updating other throws as needed
                    _bowlingFrame.UpdateThrows();
                    //notifying property changes
                    OnPropertyChanged(nameof(_bowlingFrame.FirstThrow));
                    OnPropertyChanged(nameof(_bowlingFrame.SecondThrow));
                    _parent.updateFrameScore();
                }
                catch (BowlingFrameInvaildInputException e)
                {
                    MessageBox.Show($"{e.InvalidScoreInput}: {e.Message}", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public string SecondThrow
        {
            get { return _bowlingFrame.SecondThrow; }
            set
            {
                try {
                    //updating the total number of empty frames for button enable
                    updateEmptyFramesCount();

                    //setting the throw
                    _bowlingFrame.SecondThrow = value;
                    //updating other throws as needed
                    _bowlingFrame.UpdateThrows();
                    //notifying property changes
                    OnPropertyChanged(nameof(_bowlingFrame.SecondThrow));
                    OnPropertyChanged(nameof(_bowlingFrame.ThirdThrow));
                    _parent.updateFrameScore();
                }
                catch (BowlingFrameInvaildInputException e)
                {
                    MessageBox.Show($"{e.InvalidScoreInput}: {e.Message}", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public string ThirdThrow
        {
            get { return _bowlingFrame.ThirdThrow; }
            set
            {
                try
                {
                    //updating the total number of empty frames for button enable
                    updateEmptyFramesCount();

                    //setting the throw
                    _bowlingFrame.ThirdThrow = value;
                    //updating other throws as needed
                    _bowlingFrame.UpdateThrows();
                    //notifying property changes
                    OnPropertyChanged(nameof(_bowlingFrame.ThirdThrow));
                    _parent.updateFrameScore();
                }
                catch (BowlingFrameInvaildInputException e)
                {
                    MessageBox.Show($"{e.InvalidScoreInput}: {e.Message}", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        public int CurrentScore
        {
            get 
            {
                if(Is10thFrame)
                {
                    if (FirstThrow.Equals(string.Empty) && SecondThrow.Equals(string.Empty) && ThirdThrow.Equals(string.Empty))
                        return 0;
                }    
                else if (FirstThrow.Equals(string.Empty) && SecondThrow.Equals(string.Empty) )
                {
                    return 0;
                }
                return _bowlingFrame.CurrentScore; 
            }
            set
            {
                _bowlingFrame.CurrentScore = value;
                OnPropertyChanged(nameof(_bowlingFrame.CurrentScore));
            }
        }
        public int FrameIndex
        {
            get { return _bowlingFrame.FrameIndex; }
            set
            {
                _bowlingFrame.FrameIndex = value;
                OnPropertyChanged(nameof(_bowlingFrame.FrameIndex));
            }
        }
        public bool Is10thFrame
        {
            get { return _bowlingFrame.Is10thFrame; }
        }
        public bool Isnot10thFrame
        {
            get { return !_bowlingFrame.Is10thFrame; }
        }

        //updates the score value
        public void updateFrameScore()
        {
            OnPropertyChanged(nameof(_bowlingFrame.CurrentScore));
        }

        private bool isFrameEmpty()
        {
            if (FirstThrow.Equals(string.Empty) && SecondThrow.Equals(string.Empty) && ThirdThrow.Equals(string.Empty))
            { return true; }
            return false;
        }
        private bool isFrameNotEmpty()
        {
            if (!isFrameEmpty())
            { return true; }
            return false;
        }
        private void updateEmptyFramesCount()
        {
            if (isFrameNotEmpty())
                BowlingScoreBoardModel.EmptyFramesCount++;
            else
                BowlingScoreBoardModel.EmptyFramesCount--;
        }

        public BowlingFrameViewModel(BowlingScoreBoardViewModel parent, BowlingFrameModel bowlingFrame)
        {
            _parent = parent;
            _bowlingFrame = bowlingFrame;
        }
    }
}
