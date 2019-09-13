using System.Collections;

namespace BowlingGameSDET
{
    public abstract class Frame : IFrame
    {
        protected IList throws;
        protected int startingThrow;

        public Frame(IList throws)
        {
            this.throws = throws;
            startingThrow = throws.Count;
        }

        public abstract int Score();
        protected abstract int FrameSize();
    }
}