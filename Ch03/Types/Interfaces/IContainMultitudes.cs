namespace Interfaces
{
    public interface IContainMultitudes
    {
        public const string TheMagicWord = "Please";

        public enum Outcome
        {
            Yes,
            No
        }

        Outcome MayI(string request)
        {
            return request == TheMagicWord ? Outcome.Yes : Outcome.No;
        }
    }
}