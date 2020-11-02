using System;

namespace DeleteBoilerplate.Common.Models.Media
{
    public class ImageViewModel
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public Guid Id { get; set; }

        public DateTime UploadDate { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public long? Order { get; set; }

        public float AspectRatio
        {
            get
            {
                if (Width == null || Height == null)
                {
                    return 1;
                }

                return (float)Width.Value / Height.Value;
            }
        }

        public float PaddingTopInPercentages => (1 / AspectRatio) * 100;
    }
}
