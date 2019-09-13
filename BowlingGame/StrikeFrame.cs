using System.Collections;

namespace BowlingGameSDET
{
    public class StrikeFrame : Frame
    {
        public StrikeFrame(IList throws) : base(throws)
        {
            throws.Add(10);
        }

        public override int Score()
        {
            var index = startingThrow + FrameSize();
            var score = 10 + (int)throws[index] + (int)throws[index + 1];

            return score;
        }

        protected override int FrameSize()
        {
            return 1;
        }
    }
}