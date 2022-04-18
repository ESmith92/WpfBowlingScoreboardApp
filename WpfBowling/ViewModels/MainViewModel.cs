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
            //testFrameObject = new BowlingFrameModel("1","2",false,1);
            //CurrentViewModel = new BowlingFrameViewModel(testFrameObject);
            CurrentViewModel = new BowlingScoreBoardViewModel(firstScoreBoard);
        }

        //public MainViewModel(BowlingScoreBoardModel scoreBoard)
        //public MainViewModel(BowlingFrameModel _debugfield)
        //{
        //    CurrentViewModel = new BowlingFrameViewModel(_debugfield);
        //}
    }
}
