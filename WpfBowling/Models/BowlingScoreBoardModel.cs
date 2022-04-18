using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBowling.Models
{
    public class BowlingScoreBoardModel
    {
        //Fields
        public static int EmptyFramesCount = 10;
        public readonly List<BowlingFrameModel> BowlingFrames;

        //Constructors
        /// <summary>
        /// Initialize BowlingScoreBoardModel Object.
        /// </summary>
        /// <param name="bowlingFrames"> List<BowlingFrameModel>: List Containing 10 or more frames.</param>
        /// </returns>
        public BowlingScoreBoardModel()
        {
            BowlingFrames = new List<BowlingFrameModel>();
            InitalizeScoreFrame();
        }

        public IEnumerable<BowlingFrameModel> GetAllReservations()
        {
            return BowlingFrames;
        }

        //
        //Methods
        //
        //methods to modify values
        /// <summary>
        /// Initalize 10 frames objects.
        /// </summary>
        private void InitalizeScoreFrame()
        {
            BowlingFrameModel frame;

            //init the first 10 with is10thFrame = false
            for (int i=0; i<9; i++)
            {
                frame = new BowlingFrameModel(false,i+1,this);
                BowlingFrames.Add(frame);
            }

            //init the 10th frame with is10thFrame = true
            frame = new BowlingFrameModel(true,10,this);
            BowlingFrames.Add(frame);
        }

        /// <summary>
        /// Parses the string values into int value scores.
        /// </summary>
        /// /// <param name="value">string: String value to convert to in.</param>
        private int _getDigitValue(string value)
        {
            if (value.Equals(string.Empty))
                return 0;
            else if (RegexModel.isXChar(value) || RegexModel.isForwardSlashChar(value))
                return 10;
            return Int32.Parse(value);
        }

        /// <summary>
        /// Calculates the Current Frame Score.
        /// </summary>
        /// /// <param name="frameIndex">Int: List[BowlingFrameModel] Index of the frame score being calculated.</param>
        public void CalculateScore()
        {
            for (int i = 0; i < BowlingFrames.Count; i++)
            {
                int frameIndex = i;
                BowlingFrameModel theFrame = BowlingFrames.ElementAt(frameIndex);
                int previousScore = 0;

                //getting the previous score
                if (frameIndex > 0)
                    previousScore = BowlingFrames.ElementAt(frameIndex - 1).CurrentScore;

                //Frame 10: check for spares then add all 3 values
                if (theFrame.Is10thFrame == true)
                {
                    //second Throw is a spare; add 10 and Throw 3
                    if (RegexModel.isForwardSlashChar(theFrame.SecondThrow))
                    { theFrame.CurrentScore = previousScore + 10 + _getDigitValue(theFrame.ThirdThrow); }
                    //third Throw is a spare; add 10 and Throw 1
                    else if (RegexModel.isForwardSlashChar(theFrame.ThirdThrow))
                    { theFrame.CurrentScore = previousScore + 10 + _getDigitValue(theFrame.FirstThrow); }
                    //add all three values
                    else
                    { theFrame.CurrentScore = previousScore + _getDigitValue(theFrame.FirstThrow) + _getDigitValue(theFrame.SecondThrow) + _getDigitValue(theFrame.ThirdThrow); }
                }
                //Frames 1-9:
                ///check if there is a spare or strike
                else if (RegexModel.isXChar(theFrame.FirstThrow) || RegexModel.isForwardSlashChar(theFrame.SecondThrow))
                {
                    //there is a strike in Throw 1; calculate Strike Score
                    if (RegexModel.isXChar(theFrame.FirstThrow))
                    {
                        int SecondScore;
                        BowlingFrameModel FutureBowlingFrames = BowlingFrames.ElementAt(frameIndex + 1);

                        //Checking if the second Throw from the next frame is empty due to strike
                        if (FutureBowlingFrames.SecondThrow.Contains('_'))
                            //get score from 2nd frame over, first Throw
                            SecondScore = _getDigitValue(BowlingFrames.ElementAt(frameIndex + 2).FirstThrow);
                        else
                            //get score from 1st frame over, second Throw
                            SecondScore = _getDigitValue(FutureBowlingFrames.SecondThrow);

                        //add previousScore(CurrentFrame-1 score) + StrikeBase(10) + StrikeAddition1(CurrentFrame+1,Throw1 score) + 
                        //      (StrikeAddition1(CurrentFrame+1,Throw2 score) Or StrikeAddition1(CurrentFrame+2,Throw1 score))
                        theFrame.CurrentScore = previousScore + _getDigitValue(theFrame.FirstThrow) + _getDigitValue(FutureBowlingFrames.FirstThrow) + SecondScore;
                    }
                    //there is a spare in Throw 2; calculate Spare Score
                    else
                    {
                        //add previousScore(CurrentFrame-1 score) + Spare(10) + StrikeAddition1(CurrentFrame+1,Throw1 score)
                        theFrame.CurrentScore = previousScore + _getDigitValue(theFrame.SecondThrow) + _getDigitValue(BowlingFrames.ElementAt(frameIndex + 1).FirstThrow);
                    }
                }
                ///no spare or strike, just add the 1st and 2nd Throw
                else
                {
                    //add previousScore(CurrentFrame-1 score) + Throw1 + Throw2
                    theFrame.CurrentScore = previousScore + _getDigitValue(theFrame.FirstThrow) + _getDigitValue(theFrame.SecondThrow);
                }
            }
        }


        //*****These are just for fun*****//
        //Methods to extend the current game
        /// <summary>
        /// Add a new BowlingFrameModel to the BowlingFrames List.
        /// </summary>
        /// <param name="is10thFrame">Bool indicator of if this is the 10th frame.</param>
        public void AddScoreFrame(bool is10thFrame)
        {
            BowlingFrames.Insert(BowlingFrames.Count - 1, new BowlingFrameModel(is10thFrame, BowlingFrames.Count - 1,this));

            //Updating the frameindex for the last frame; frames are add at the end-1
            BowlingFrames.ElementAt(BowlingFrames.Count).FrameIndex = BowlingFrames.Count;
        }

        /// <summary>
        /// Add a new BowlingFrameModel to the BowlingFrames List.
        /// </summary>
        /// <param name="firstThrow">String: Pins hit on first throw.</param>
        /// <param name="secondThrow">String: Pins hit on second throw.</param>
        /// <param name="is10thFrame">Bool indicator of if this is the 10th frame.</param>
        public void AddScoreFrame(string firstThrow, string secondThrow, bool is10thFrame)
        {
            BowlingFrames.Insert(BowlingFrames.Count - 1, new BowlingFrameModel(firstThrow, secondThrow, is10thFrame, BowlingFrames.Count - 1,this));

            //Updating the frameindex for the last frame; frames are add at the end-1
            BowlingFrames.ElementAt(BowlingFrames.Count).FrameIndex = BowlingFrames.Count;
        }

        /// <summary>
        /// Add a new BowlingFrameModel to the BowlingFrames List.
        /// </summary>
        /// /// <param name="firstThrow">String: Pins hit on first throw.</param>
        /// <param name="secondThrow">String: Pins hit on second throw.</param>
        /// <param name="thirdThrow">String: Pins hit on second throw.</param>
        /// <param name="is10thFrame">Bool indicator of if this is the 10th frame.</param>
        public void AddScoreFrame(string firstThrow, string secondThrow, string thirdThrow, bool is10thFrame)
        {
            BowlingFrames.Insert(BowlingFrames.Count - 1, new BowlingFrameModel(firstThrow, secondThrow, thirdThrow, is10thFrame, BowlingFrames.Count - 1, this));

            //Updating the frameindex for the last frame; frames are add at the end-1
            BowlingFrames.ElementAt(BowlingFrames.Count).FrameIndex = BowlingFrames.Count;
        }

        /// <summary>
        /// Add a new BowlingFrameModel to the BowlingFrames List.
        /// </summary>
        /// <param name="score">Int: Score value to initialize Current and Previous Scores.</param>
        /// <param name="is10thFrame">Bool indicator of if this is the 10th frame.</param>
        public void AddScoreFrame(int score, bool is10thFrame)
        {
            BowlingFrames.Insert(BowlingFrames.Count - 1,new BowlingFrameModel(score, is10thFrame, BowlingFrames.Count - 1, this));

            //Updating the frameindex for the last frame; frames are add at the end-1
            BowlingFrames.ElementAt(BowlingFrames.Count).FrameIndex = BowlingFrames.Count;
        }

        /// <summary>
        /// Add a new BowlingFrameModel to the BowlingFrames List.
        /// </summary>
        /// <param name="firstThrow">String: Pins hit on first throw.</param>
        /// <param name="secondThrow">String: Pins hit on second throw.</param>
        /// <param name="score">Int: Score value to initialize Current and Previous Scores.</param>
        /// <param name="is10thFrame">Bool indicator of if this is the 10th frame.</param>
        public void AddScoreFrame(string firstThrow, string secondThrow, int score, bool is10thFrame)
        {
            BowlingFrames.Insert(BowlingFrames.Count - 1, new BowlingFrameModel(firstThrow, secondThrow, score, is10thFrame, BowlingFrames.Count - 1, this));

            //Updating the frameindex for the last frame; frames are add at the end-1
            BowlingFrames.ElementAt(BowlingFrames.Count).FrameIndex = BowlingFrames.Count;
        }

        /// <summary>
        /// Add a new BowlingFrameModel to the BowlingFrames List.
        /// </summary>
        /// /// <param name="firstThrow">String: Pins hit on first throw.</param>
        /// <param name="secondThrow">String: Pins hit on second throw.</param>
        /// <param name="thirdThrow">String: Pins hit on second throw.</param>
        /// <param name="score">Int: Score value to initialize Current and Previous Scores.</param>
        /// <param name="is10thFrame">Bool indicator of if this is the 10th frame.</param>
        public void AddScoreFrame(string firstThrow, string secondThrow, string thirdThrow, int score, bool is10thFrame)
        {
            BowlingFrames.Insert(BowlingFrames.Count - 1, new BowlingFrameModel(firstThrow, secondThrow, thirdThrow, score, is10thFrame, BowlingFrames.Count - 1, this));

            //Updating the frameindex for the last frame; frames are add at the end-1
            BowlingFrames.ElementAt(BowlingFrames.Count).FrameIndex = BowlingFrames.Count;
        }

        /// <summary>
        /// remove a BowlingFrameModel object from the end of BowlingFrames List; skips 10th frame.
        /// </summary>
        public void RemoveScoreFrameFromTheEnd()
        {
            BowlingFrames.RemoveAt(BowlingFrames.Count - 1);

            //Updating the frameindex for the last frame; frames are add at the end-1
            BowlingFrames.ElementAt(BowlingFrames.Count).FrameIndex = BowlingFrames.Count;
        }
        //(end) Methods to extend the current game (end)
    }
}
