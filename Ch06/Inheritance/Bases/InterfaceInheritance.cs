namespace Bases
{
    interface IBase1
    {
        void Base1Method();
    }

    interface IBase2
    {
        void Base2Method();
    }

    interface IBoth : IBase1, IBase2
    {
        void Method3();
    }
}
