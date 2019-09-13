using System.Collections;

namespace BowlingGameSDET
{
    public class SpareFrame: Frame
    {
        public SpareFrame(IList throws, int firstThrow, int secondThrow) : base(throws)
        {
            throws.Add(firstThrow);
            throws.Add(secondThrow);
        }

        public override int Score()
        {
            var index = startingThrow + FrameSize();
            var score = 10 + (int)throws[index];

            return score;
        }

        protected override int FrameSize()
        {
            return 2;
        }
    }
}