namespace ManageIPAddresses.InternalSystem.Contracts.Data
{
    public class IpAddress
    {
        public string Address { get; set; }
        public string Mask { get; set; }
        public string Gateway { get; set; }
    }
}
