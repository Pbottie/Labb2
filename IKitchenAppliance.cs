namespace Labb2
{
    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        void Use();
    }
}