using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBowling.Models;
using WpfBowling.ViewModels;

namespace WpfBowling.Commands
{
    internal class ClearScoreBoardCommand : CommandBase
    {
        private readonly BowlingScoreBoardViewModel _bowlingScoreBoardViewModel;

        public ClearScoreBoardCommand(BowlingScoreBoardViewModel bowlingScoreBoardViewModel)
        {
            _bowlingScoreBoardViewModel = bowlingScoreBoardViewModel;

            foreach (BowlingFrameViewModel frame in _bowlingScoreBoardViewModel.BowlingFrames)
            {
                frame.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        public override bool CanExecute(object parameter)
        {
            bool test = false;
            foreach (BowlingFrameViewModel frame in _bowlingScoreBoardViewModel.BowlingFrames)
            {
                if(!(frame.FirstThrow.Equals(string.Empty)&& 
                    frame.SecondThrow.Equals(string.Empty)&& 
                    frame.ThirdThrow.Equals(string.Empty)))
                {
                    test = true;
                }
            }

            return test &&
            base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            foreach (BowlingFrameViewModel frame in _bowlingScoreBoardViewModel.BowlingFrames)
            {
                frame.FirstThrow = String.Empty;
                frame.SecondThrow = String.Empty;
                frame.ThirdThrow = String.Empty;
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BowlingFrameViewModel.FirstThrow) ||
                e.PropertyName == nameof(BowlingFrameViewModel.SecondThrow)||
                e.PropertyName == nameof(BowlingFrameViewModel.ThirdThrow))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
