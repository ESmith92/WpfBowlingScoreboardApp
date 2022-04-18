using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBowling.Models;

namespace WpfBowling.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public BowlingScoreBoardModel firstScoreBoard;

        public BowlingFrameModel testFrameObject;

        public BowlingFrameViewModel testFrame;

        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            firstScoreBoard = new BowlingScoreBoardModel();
            CurrentViewModel = new BowlingScoreBoardViewModel(firstScoreBoard);
        }
    }
}
