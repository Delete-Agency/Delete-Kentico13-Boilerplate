using CMS.Helpers;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using DeleteBoilerplate.Common.Models.Media;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DeleteBoilerplate.Common.Extensions
{
    public static class MediaExtensions
    {
        private static string MediaCacheKey = "deleteboilerplate|mediaitem|";

        public static ImageModel GetImageModelByURL(string url)
        {
            var imageGuid = GetImageGuidByURL(url);
            return GetImageModelFromCache(imageGuid);
        }

        public static ImageModel GetImageModelFromCache(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return null;
            }

            try
            {
                ImageModel result = null;

                var cacheKey = $"{MediaCacheKey}{guid}";
                using (var cs = new CachedSection<ImageModel>(ref result, CacheHelper.CacheMinutes(SiteContext.CurrentSiteName), true, cacheKey))
                {
                    if (cs.LoadData)
                    {
                        result = GetImageModel(guid);

                        cs.Data = result;
                        cs.CacheDependency = CacheHelper.GetCacheDependency(new List<string>
                        {
                            $"mediafile|{guid}"
                        });
                    }
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        private static ImageModel GetImageModel(Guid guid)
        {
            var mediaFile = MediaFileInfo.Provider.Get(guid, SiteContext.CurrentSiteID);

            string fileName = $"{mediaFile?.FileName}{mediaFile?.FileExtension}";
            var url = MediaFileURLProvider.GetMediaFileUrl(guid, fileName);

            return new ImageModel
            {
                Id = guid,
                Title = mediaFile?.FileTitle.IfEmpty(mediaFile?.FileName),
                Url = URLHelper.ResolveUrl(url),
                FileName = fileName,
                FileExtension = mediaFile?.FileExtension.Replace(".", string.Empty),
                UploadDate = mediaFile?.FileCreatedWhen,
                Width = mediaFile?.FileImageWidth,
                Height = mediaFile?.FileImageHeight,
            };
        }

        private static Guid GetImageGuidByURL(string url)
        {
            var match = Regex.Match(url, @"[0-9a-fA-F]{8}[-]([0-9a-fA-F]{4}[-]){3}[0-9A-Fa-f]{12}");

            if (match.Success)
            {
                return Guid.Parse(match.Value);
            }

            return Guid.Empty;
        }
    }
}
