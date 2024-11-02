namespace api.Models
{
    public class AdvertismentImage
    {
        public int AdvertismentImageID { get; set; }
        public string? ImageSource { get; set; }
        public int AdvertismentID { get; set; }
        public Advertisement Advertisement { get; set; } = null!;
    }
}
