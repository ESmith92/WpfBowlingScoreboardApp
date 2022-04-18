using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfBowling.Commands;
using WpfBowling.Models;

namespace WpfBowling.ViewModels
{
    public class BowlingScoreBoardViewModel : ViewModelBase
    {
        private ObservableCollection<BowlingFrameViewModel> _bowlingFrames;
        private BowlingScoreBoardModel _bowlingScoreBoard;

        public IEnumerable<BowlingFrameViewModel> BowlingFrames => _bowlingFrames;

        public ICommand ClearScoreBoardCommand { get; }

        //Cycles throught the BowlingFrameViewModel, calling updateFrameScore on each framemodel
        public void updateFrameScore()
        {
            foreach (BowlingFrameViewModel frame in _bowlingFrames)
            {
                frame.updateFrameScore();
            }
        }

        public BowlingScoreBoardViewModel(BowlingScoreBoardModel firstScoreBoard)
        {
            //BowlingScoreBoardModel object
            _bowlingScoreBoard = firstScoreBoard;

            //adding BowlingFrameViewModel to the ObservableCollection
            _bowlingFrames = new ObservableCollection<BowlingFrameViewModel>();
            foreach (BowlingFrameModel bowlingFrameModel in firstScoreBoard.BowlingFrames)
            {
                //creating BowlingFrameViewModel from BowlingFrameViewModel
                _bowlingFrames.Add(new BowlingFrameViewModel(this,bowlingFrameModel)); 
            }

            ClearScoreBoardCommand = new ClearScoreBoardCommand(this);
        }
    }
}
