using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBowling.Exceptions;

namespace WpfBowling.Models
{
    public class BowlingFrameModel
    {
        //Fields
        private string _firstThrow;
        private string _secondThrow;
        private string _thirdThrow;
        private int _currentScore;
        private int _frameIndex;
        private BowlingScoreBoardModel _parent;
        private readonly bool _is10thFrame;


        //Constructors
        /// <summary>
        /// Initialize BowlingFrameModel Object.
        /// </summary>
        /// <param name="is10thFrame">Bool indicator of the 10th Frame.</param>
        /// <param name="frameIndex">int indicator of the current Frame.</param>
        /// <param name="parent">parent bowlingsScoreBoardModel object.</param>
        /// <returns>BowlingFrameModel Object</returns>
        public BowlingFrameModel(bool is10thFrame, int frameIndex,BowlingScoreBoardModel parent)
        {
            _parent = parent;
            _is10thFrame = is10thFrame;
            _frameIndex = frameIndex;
            FirstThrow = String.Empty;
            SecondThrow = String.Empty;
            ThirdThrow = String.Empty;
            CurrentScore = 0;
        }
        /// <summary>
        /// Initialize BowlingFrameModel Object.
        /// </summary>
        /// <param name="firstThrow">String: Pins hit on first throw.</param>
        /// <param name="secondThrow">String: Pins hit on second throw.</param>
        /// <param name="is10thFrame">Bool indicator of the 10th Frame.</param>
        /// <param name="frameIndex">int indicator of the current Frame.</param>
        /// <param name="parent">parent bowlingsScoreBoardModel object.</param>
        /// <returns>BowlingFrameModel Object</returns>
        public BowlingFrameModel(string firstThrow, string secondThrow, bool is10thFrame, int frameIndex, BowlingScoreBoardModel parent)
        {
            _is10thFrame = is10thFrame;
            _frameIndex = frameIndex;
            FirstThrow = firstThrow;
            SecondThrow = secondThrow;
            ThirdThrow = String.Empty;
            CurrentScore = 0;
        }
        /// <summary>
        /// Initialize BowlingFrameModel Object.
        /// </summary>
        /// <param name="firstThrow">String: Pins hit on first throw.</param>
        /// <param name="secondThrow">String: Pins hit on second throw.</param>
        /// <param name="thirdThrow">String: Pins hit on second throw.</param>
        /// <param name="is10thFrame">Bool indicator of the 10th Frame.</param>
        /// <param name="frameIndex">int indicator of the current Frame.</param>
        /// <param name="parent">parent bowlingsScoreBoardModel object.</param>
        /// <returns>BowlingFrameModel Object</returns>
        public BowlingFrameModel(string firstThrow, string secondThrow, string thirdThrow, bool is10thFrame, int frameIndex, BowlingScoreBoardModel parent)
        {
            _is10thFrame = is10thFrame;
            _frameIndex = frameIndex;
            FirstThrow = firstThrow;
            SecondThrow = secondThrow;
            ThirdThrow = thirdThrow;
            CurrentScore = 0;
        }
        /// <summary>
        /// Initialize BowlingFrameModel Object.
        /// </summary>
        /// <param name="score">Int: Starting Score Values.</param>
        /// <param name="is10thFrame">Bool indicator of the 10th Frame.</param>
        /// <param name="frameIndex">int indicator of the current Frame.</param>
        /// <param name="parent">parent bowlingsScoreBoardModel object.</param>
        /// <returns>BowlingFrameModel Object</returns>
        public BowlingFrameModel(int score, bool is10thFrame, int frameIndex, BowlingScoreBoardModel parent)
        {
            _is10thFrame = is10thFrame;
            _frameIndex = frameIndex;
            FirstThrow = String.Empty;
            SecondThrow = String.Empty;
            ThirdThrow = String.Empty;
            CurrentScore = score;   
        }
        /// <summary>
        /// Initialize BowlingFrameModel Object.
        /// </summary>
        /// <param name="firstThrow">String: Pins hit on first throw.</param>
        /// <param name="secondThrow">String: Pins hit on second throw.</param>
        /// <param name="score">Int: Starting Score Values.</param>
        /// <param name="is10thFrame">Bool indicator of the 10th Frame.</param>
        /// <param name="frameIndex">int indicator of the current Frame.</param>
        /// <param name="parent">parent bowlingsScoreBoardModel object.</param>
        /// <returns>BowlingFrameModel Object</returns>
        public BowlingFrameModel(string firstThrow, string secondThrow, int score, bool is10thFrame, int frameIndex, BowlingScoreBoardModel parent)
        {
            _is10thFrame = is10thFrame;
            _frameIndex = frameIndex;
            FirstThrow = firstThrow;
            SecondThrow = secondThrow;
            ThirdThrow = String.Empty;
            CurrentScore = score;
        }
        /// <summary>
        /// Initialize BowlingFrameModel Object.
        /// </summary>
        /// <param name="firstThrow">String: Pins hit on first throw.</param>
        /// <param name="secondThrow">String: Pins hit on second throw.</param>
        /// <param name="thirdThrow">String: Pins hit on second throw.</param>
        /// <param name="score">Int: Starting Score Values.</param>
        /// <param name="is10thFrame">Bool indicator of the 10th Frame.</param>
        /// <param name="frameIndex">int indicator of the current Frame.</param>
        /// <param name="parent">parent bowlingsScoreBoardModel object.</param>
        /// <returns>BowlingFrameModel Object</returns>
        public BowlingFrameModel(string firstThrow, string secondThrow, string thirdThrow, int score, bool is10thFrame, int frameIndex, BowlingScoreBoardModel parent)
        {
            _is10thFrame = is10thFrame;
            _frameIndex = frameIndex;
            FirstThrow = firstThrow;
            SecondThrow = secondThrow;
            ThirdThrow = thirdThrow;
            CurrentScore = score;
        }


        //Properties
        public string FirstThrow
        {
            get { return _firstThrow; }
            set => _setFirstFrame(value);
        }
        public string SecondThrow
        {
            get { return _secondThrow; }
            set => _setSecondFrame(value);
        }
        public string ThirdThrow
        {
            get { return _thirdThrow; }
            set => _setThirdFrame(value);
        }
        public int CurrentScore
        {
            get { return _currentScore; }
            set { _currentScore = value; }
        }
        public int FrameIndex
        {
            get { return _frameIndex; }
            set { _frameIndex = value; }
        }
        public bool Is10thFrame => _is10thFrame;
        public BowlingScoreBoardModel Parent => _parent;



        //Methods
        /// <summary>
        /// Get Underscore('_') if a Strike occurred on frames 1-9.
        /// </summary>
        /// <param name="firstScore">The incoming score(string) containing a Strike(x) char.</param>
        /// <param name="secondScore">The incoming score(string) to swap char.</param>
        /// <returns>String: Underscore('_') [after Strike on frames 1-9] or {secondScore}.</returns>
        private string _setSecondScoreToUnderscore(string firstScore, string secondScore)
        {
            //On frames 1-9, If a stike was thrown on; return '_'
            if (Is10thFrame == false && RegexModel.isXChar(firstScore))
            {
                return "_";
            }
            return secondScore;
        }

        /// <summary>
        /// remove Underscore('_') if score1 is empty and score2 == '_'.
        /// </summary>
        /// <param name="firstScore">The incoming score(string) char checked for empty.</param>
        /// <param name="secondScore">The incoming score(string) char checked for '_'; (Returned).</param>
        /// <returns>String: String.Empty or {secondScore}.</returns>
        private string _removeUnderScoreFromSecondScore(string firstScore, string? secondScore)
        {
            if (secondScore != null)
            {
                //On frames 1-9, If a stike was thrown on; return '_'
                if (firstScore.Equals(string.Empty) && secondScore.Contains("_"))
                {
                    return "";
                }
            }
            return secondScore;
        }

        /// <summary>
        /// Get ForwardSlash('/') if a spare occurred ({firstThrowScore} + {secondThrowScore} >= 10).
        /// </summary>
        /// <param name="firstThrowScore">The first incoming score(string).</param>
        /// <param name="secondThrowScore">The second incoming score(string).</param>
        /// <returns>String: ForwardSlash('/') [when Sum of both scores >= 10] or {secondThrowScore}.</returns>
        private string _changeThrowToSpare(string firstThrowScore, string secondThrowScore)
        {
            //Checks if a spare has occurred and replaces the value
            //Checking if both scores are 0-9
            if (RegexModel.isDigitChar(firstThrowScore) && RegexModel.isDigitChar(secondThrowScore))
            {
                //Checks if both scores is greater than 10
                if (Int32.Parse(firstThrowScore) + Int32.Parse(secondThrowScore) >= 10)
                {
                    return  "/";
                }
            }
            return secondThrowScore;
        }

        /// <summary>
        /// Validate input and set first throw where input is valid.
        /// </summary>
        /// <param name="value">The incoming score value(string).</param>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming score input conflicts with valid throw 1 input.</exception>
        private void _setFirstFrame(string value)
        {
            //Check if empty
            if (!value.Equals(String.Empty))
            {
                //value other than x, X, or 0-9; throw exception
                _xOrDigitCharValidation(value);
                _firstThrow = value;

                //On frames 1-9, If a stike was thrown; set second throw to '_'
                _secondThrow = _setSecondScoreToUnderscore(value, SecondThrow);
            }
            else 
            { 
                _firstThrow = value;

                //Checks if throw1 is empty and throw2 contains '_' => removes the '_'
                _secondThrow = _removeUnderScoreFromSecondScore(value, SecondThrow);
            }
        }

        /// <summary>
        /// Validate input and set second throw where input is valid for frames 1-9 or frame 10
        /// </summary>
        /// <param name="value">The incoming score value(string).</param>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming score input conflicts with valid throw 2 input.</exception>
        private void _setSecondFrame(string value)
        {
            //input isn't empty
            if (!value.Equals(String.Empty))
            {
                //if throw 1 was a Strike
                if (RegexModel.isXChar(FirstThrow))
                {
                    //on frame 10?
                    if (Is10thFrame == true)
                    {
                        //value other than x,X,or 0-9; throw exception
                        _xOrDigitCharValidation(value);
                        _secondThrow = value;
                    }
                    //First throw was a strike, Second throw must be '_'; throw exception
                    else
                    {
                        //value other than '_' after a Strike; throw exception
                        _containsUnderscoreValidation(value);
                    }
                }
                //if throw 1 was not a Strike
                else
                {
                    //value other than / or 0-9; throw exception
                    _forwardSlashOrDigitCharValidation(value);
                    _secondThrow = value;

                    //Checking if the second throw needs to be set as '/'
                    _secondThrow = _changeThrowToSpare(FirstThrow, SecondThrow);
                }
            }
            //input is empty
            else
            {
                _secondThrow = value;

                ///On frames 1-9, If a stike was thrown on; set second throw to '_'
                _secondThrow = _setSecondScoreToUnderscore(FirstThrow, SecondThrow);
            }
        }

        /// <summary>
        /// Validate input and set third throw where input is valid on frame 10.
        /// </summary>
        /// <param name="value">The incoming score value(string).</param>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming score input conflicts with valid throw 3 input.</exception>
        private void _setThirdFrame(string value)
        {
            if (value.Equals(string.Empty))
            {
                _thirdThrow = value;
            }
            //Check if on frame 10  
            else if (Is10thFrame == true)
            {
                //Throw exception if frame 10 is open while setting the third throw
                if (!RegexModel.isXChar(FirstThrow) && !RegexModel.isForwardSlashChar(SecondThrow))
                {
                    throw new BowlingFrameInvaildInputException("Open Frame: ThirdThrow value can't be set with a open frame on frame 10: ", ThirdThrow);
                }
                //if 2nd is digit => can't be a Strike(x)
                if (RegexModel.isDigitChar(SecondThrow))
                {

                    //value other than /, or 0-9; throw exception
                    _forwardSlashOrDigitCharValidation(value);
                    _thirdThrow = value;

                    //Checking if the third throw needs to be set as '/'
                    _thirdThrow = _changeThrowToSpare(SecondThrow, ThirdThrow);
                }
                //if 2nd is / or x => can't be / RegexModel.xordigit
                else if (RegexModel.isForwardSlashOrXChar(SecondThrow))
                {
                    //value other than x, X, or 0-9; throw exception
                    _xOrDigitCharValidation(value);
                    _thirdThrow = value;
                }
                else
                {
                    _xOrForwardSlashOrDigitCharValidation(value);
                    _thirdThrow = value;

                    //Checking if the third throw needs to be set as '/'
                    _thirdThrow = _changeThrowToSpare(SecondThrow, ThirdThrow);
                }
            }
            //if value is not empty and is frames 1-9; throw exception
            else
            {
                throw new BowlingFrameInvaildInputException("ThirdThrow value can't be set on frames 1-9: ", ThirdThrow);
            }
        }

        /// <summary>
        /// Updates each throw value by sending the current value throw the setter. Used to change throw Char for strikes and spares
        /// </summary>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming score input conflicts with valid throw 3 input.</exception>
        public void UpdateThrows()
        {
            _setFirstFrame(FirstThrow); //<- unnessary call: frame1 should never need to be updated.
            _setSecondFrame(SecondThrow);
            _setThirdFrame(ThirdThrow);

            //Updating the score; update previous scores where possible; go from oldest to newest
            _parent.CalculateScore();
        }

        /// <summary>
        /// Resets the frame values back to the defaults.
        /// </summary>
        public void ClearFrame()
        {
            FirstThrow = String.Empty;
            SecondThrow = String.Empty;
            ThirdThrow = String.Empty;
            CurrentScore = 0;
        }

        public override bool Equals(object? obj)
        {
            return obj is BowlingFrameModel bowlingFrame && 
                FirstThrow == bowlingFrame.FirstThrow &&
                SecondThrow == bowlingFrame.SecondThrow &&
                ThirdThrow == bowlingFrame.ThirdThrow &&
                CurrentScore == bowlingFrame.CurrentScore &&
                Is10thFrame == bowlingFrame.Is10thFrame;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstThrow,SecondThrow,ThirdThrow,CurrentScore,Is10thFrame);
        }

        /// <summary>
        /// Score ToString()
        /// </summary>
        /// <returns>String: 
        /// <br/>FirstThrow: {_firstThrow}, SecondThrow: {_secondThrow}, ThirdThrow: {_thirdThrow}, CurrentScore: {CurrentScore}, _is10thFrame: {_is10thFrame} 
        /// <br/>OR "Frame is Empty".
        /// </returns>
        public override string ToString()
        {
            if (FirstThrow == null)
            {
                return "Frame is Empty";
            }
            return $"FirstThrow: {_firstThrow}, SecondThrow: {_secondThrow}, ThirdThrow: {_thirdThrow}, CurrentScore: {CurrentScore}, _is10thFrame: {_is10thFrame}";
        }



        //Exception Throwing Checks
        /// <summary>
        /// Validate input as 0-9; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to validate.</param>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming input is not 0-9.</exception>
        private void _DigitCharValidation(string throwScore)
        {
            //value other than 0-9; throw exception
            if (!RegexModel.isDigitChar(throwScore))
            {
                throw new BowlingFrameInvaildInputException("Value must be 0-9: ", throwScore);
            }
        }

        /// <summary>
        /// Validate input as x or 0-9; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to validate.</param>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming input is not x or 0-9.</exception>
        private void _xOrDigitCharValidation(string throwScore)
        {
            //value other than x, X, or 0-9; throw exception
            if (!RegexModel.isXOrDigitChar(throwScore))
            {
                throw new BowlingFrameInvaildInputException("Value must be X, x, or 0-9: ", throwScore);
            }
        }

        /// <summary>
        /// Validate input as / or 0-9; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to validate.</param>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming input is not / or 0-9.</exception>
        private void _forwardSlashOrDigitCharValidation(string throwScore)
        {
            //value other than /, or 0-9; throw exception
            if (!RegexModel.isForwardSlashOrDigitChar(throwScore))
            {
                throw new BowlingFrameInvaildInputException("Value Must be / or 0-9: ", throwScore);
            }
        }

        /// <summary>
        /// Validate input as X, x, /, or 0-9; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to validate.</param>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming input is not X, x, /, or 0-9.</exception>
        private void _xOrForwardSlashOrDigitCharValidation(string throwScore)
        {
            //value other than /, or 0-9; throw exception
            if (!RegexModel.isForwardSlashOrXOrDigitChar(throwScore))
            {
                throw new BowlingFrameInvaildInputException("Value Must be X, x, /, or 0-9: ", throwScore);
            }
        }

        /// <summary>
        /// Validate input is '_'.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to validate.</param>
        /// <exception cref="BowlingFrameInvaildInputException">Thrown if incoming input is not '_'.</exception>
        private void _containsUnderscoreValidation(string throwScore)
        {
            //value other than _ after a strike; throw exception
            if (!throwScore.Contains('_'))
            {
                throw new BowlingFrameInvaildInputException("Value Must be _ after a Strike: ", throwScore);
            }
        }
    }
}