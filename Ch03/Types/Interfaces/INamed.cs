namespace Interfaces
{
    public interface INamed
    {
        int Id { get; }
        string Name => $"{this.GetType()}: {this.Id}";
    }
}