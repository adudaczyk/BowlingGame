using System.Collections;

namespace BowlingGameSDET
{
    public class OpenFrame : Frame
    {
        public OpenFrame(IList throws, int firstThrow, int secondThrow) : base(throws)
        {
            throws.Add(firstThrow);
            throws.Add(secondThrow);
        }

        public override int Score()
        {
            var score = (int)throws[startingThrow] + (int)throws[startingThrow +1];

            return score;
        }

        protected override int FrameSize()
        {
            return 2;
        }
    }
}