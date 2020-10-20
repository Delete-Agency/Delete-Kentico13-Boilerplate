using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.DocumentEngine.Types.DeleteBoilerplate;
using CMS.Helpers;
using CMS.SiteProvider;

namespace DeleteBoilerplate.Domain.Repositories
{
    public interface ISocialLinkRepository
    {
        IEnumerable<SocialLink> GetSocialLinks(string siteName = null);
    }

    public class SocialLinkRepository : ISocialLinkRepository
    {
        private readonly string _projectCacheKey = "deleteboilerplate|sociallink";

        public IEnumerable<SocialLink> GetSocialLinks(string siteName = null)
        {
            var socialLinks = new List<SocialLink>();

            if (string.IsNullOrEmpty(siteName))
            {
                siteName = SiteContext.CurrentSiteName;
            }

            using (var cs = new CachedSection<List<SocialLink>>(ref socialLinks, CacheHelper.CacheMinutes(siteName), true, _projectCacheKey))
            {
                if (cs.LoadData)
                {
                    socialLinks = SocialLinkProvider.GetSocialLinks().OnSite(siteName).ToList();

                    var cacheDependencies = new List<string>
                    {
                        $"nodes|{siteName}|{SocialLink.CLASS_NAME}|all"
                    };

                    cs.Data = socialLinks;
                    cs.CacheDependency = CacheHelper.GetCacheDependency(cacheDependencies);
                }
            }

            return socialLinks;
        }
    }
}
