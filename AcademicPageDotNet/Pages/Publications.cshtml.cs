using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcademicPageDotNet.Pages
{
    public class PublicationsModel : PageModel
    {
        private readonly AuthorDbContext _authorCtx;
        public List<PublicationItem> _publicationList = new();

        public PublicationsModel(AuthorDbContext authorCtx)
        {
            _authorCtx = authorCtx;
        }

        public void OnGet()
        {
            _appendTestPublication();
        }

        public void _appendTestPublication()
        {
            PublicationItem item = new()
            {
                Title = "GenDexGrasp: Generalizable Dexterous Grasping",
                Authors = new List<AuthorLabel>(),
                PublishDate = "2023-01-16",
                PublicationName = "International Conference on Robotics and Automation (ICRA) 2023",
                State = "Accepted",
                Links = new List<ExternalLabel>(),
                TeaserUrl = "https://assets.yuyangli.com/Academic/ICRA23_Grasp/teaser.gif",
                Introduction = "We propose GenDexGrasp, a versatile dexterous grasping method that can generalize to out-of-domain robotic hands. In addition, we contribute MultiDex, a large-scale synthetic dexterous grasping dataset."
            };

            List<Tuple<string, AuthorType>> authors = new();
            authors.Add(new Tuple<string, AuthorType>("Puhao Li", AuthorType.FirstAuthor));
            authors.Add(new Tuple<string, AuthorType>("Tengyu Liu", AuthorType.FirstAuthor));
            authors.Add(new Tuple<string, AuthorType>("Yuyang Li", AuthorType.WebsiteOwner));
            authors.Add(new Tuple<string, AuthorType>("Yiran Geng", AuthorType.Author));
            authors.Add(new Tuple<string, AuthorType>("Yixin Zhu", AuthorType.Author));
            authors.Add(new Tuple<string, AuthorType>("Yaodong Yang", AuthorType.Author));
            authors.Add(new Tuple<string, AuthorType>("Siyuan Huang", AuthorType.CorrespondingAuthor));
            authors.Add(new Tuple<string, AuthorType>("Fake Author", AuthorType.Author));

            Author author;
            foreach (var (authorName, authorType) in authors)
            {
                author = _authorCtx.getAuthor(authorName);
                item.Authors.Add(new AuthorLabel(author.Name, author.Url, authorType));
            }

            //item.Authors.Add(new AuthorLabel("Puhao Li", "https://xiaoyao-li.github.io", AuthorType.FirstAuthor));
            //item.Authors.Add(new AuthorLabel("Tengyu Liu", "http://tengyu.ai", AuthorType.FirstAuthor));
            //item.Authors.Add(new AuthorLabel("Yuyang Li", "https://yuyangli.com", AuthorType.StrongAuthor));
            //item.Authors.Add(new AuthorLabel("Yiran Geng", "https://gengyiran.github.io", AuthorType.Author));
            //item.Authors.Add(new AuthorLabel("Yixin Zhu", "https://yzhu.io", AuthorType.Author));
            //item.Authors.Add(new AuthorLabel("Yaodong Yang", "https://www.yangyaodong.com", AuthorType.Author));
            //item.Authors.Add(new AuthorLabel("Siyuan Hunag", "https://siyuanhuang.com", AuthorType.CorrespondingAuthor));

            //item.Links.Add(new ExternalLabel("Arxiv", "https://arxiv.org/abs/2210.00722"));
            //item.Links.Add(new ExternalLabel("PDF", "https://blog-img-1302618638.cos.ap-beijing.myqcloud.com/uPic/ICRA23_GenDexGrasp.pdf"));
            //item.Links.Add(new ExternalLabel("Project", "https://sites.google.com/view/gendexgrasp/home"));
            //item.Links.Add(new ExternalLabel("Code", "https://github.com/tengyu-liu/GenDexGrasp"));


            _publicationList.Add(item);
        }
    }
}
