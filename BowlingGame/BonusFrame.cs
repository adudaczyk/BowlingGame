using System.Collections;

namespace BowlingGameSDET
{
    public class BonusFrame : Frame
    {
        public BonusFrame(IList throws, int firstThrow) : base(throws)
        {
            throws.Add(firstThrow);
        }

        public override int Score()
        {
            return 0;
        }

        protected override int FrameSize()
        {
            return 0;
        }
    }
}