using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcademicPageDotNet.Pages
{
    public class PublicationsModel : PageModel
    {
        public List<PublicationItem> _publicationList = new();

        public void OnGet()
        {
            this._appendTestPublication();
        }

        public void _appendTestPublication()
        {
            PublicationItem item = new()
            {
                title = "GenDexGrasp: Generalizable Dexterous Grasping",
                authors = new List<AuthorLabel>(),
                publishDate = "2023-01-16",
                publicationName = "International Conference on Robotics and Automation (ICRA) 2023",
                links = new List<ExternalLabel>(),
                teaserUrl = "https://assets.yuyangli.com/Academic/ICRA23_Grasp/teaser.gif",
                introduction = "We propose GenDexGrasp, a versatile dexterous grasping method that can generalize to out-of-domain robotic hands. In addition, we contribute MultiDex, a large-scale synthetic dexterous grasping dataset."
            };

            item.authors.Add(new AuthorLabel("Puhao Li", "https://xiaoyao-li.github.io", AuthorType.FirstAuthor));
            item.authors.Add(new AuthorLabel("Tengyu Liu", "http://tengyu.ai", AuthorType.FirstAuthor));
            item.authors.Add(new AuthorLabel("Yuyang Li", "https://yuyangli.com", AuthorType.StrongAuthor));
            item.authors.Add(new AuthorLabel("Yiran Geng", "https://gengyiran.github.io", AuthorType.Author));
            item.authors.Add(new AuthorLabel("Yixin Zhu", "https://yzhu.io", AuthorType.Author));
            item.authors.Add(new AuthorLabel("Yaodong Yang", "https://www.yangyaodong.com", AuthorType.Author));
            item.authors.Add(new AuthorLabel("Siyuan Hunag", "https://siyuanhuang.com", AuthorType.CorrespondingAuthor));

            item.links.Add(new ExternalLabel("Arxiv", "https://arxiv.org/abs/2210.00722"));
            item.links.Add(new ExternalLabel("PDF", "https://blog-img-1302618638.cos.ap-beijing.myqcloud.com/uPic/ICRA23_GenDexGrasp.pdf"));
            item.links.Add(new ExternalLabel("Project", "https://sites.google.com/view/gendexgrasp/home"));
            item.links.Add(new ExternalLabel("Code", "https://github.com/tengyu-liu/GenDexGrasp"));

            _publicationList.Add(item);
        }
    }
}
