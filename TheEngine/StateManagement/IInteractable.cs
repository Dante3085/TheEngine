namespace TheEngine.StateManagement
{
    /// <summary>
    /// Describes Objects that can interact with each other.
    /// </summary>
    public interface IInteractable
    {
        void Interact(IInteractable other);
        void HandleInteraction();
    }
}
