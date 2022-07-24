namespace Euvic.StaffTraining.Contracts.Shared
{
    public class SelectItem<TKey> where TKey : struct
    {
        public TKey Value { get; set; }
        public string Label { get; set; }
    }
}
