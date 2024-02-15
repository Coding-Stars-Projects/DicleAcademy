namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IRepositoryAboutUs> _repositoryAboutUs;
        private readonly Lazy<IRepositoryBestCourses> _repositoryBestCourses;
        private readonly Lazy<IRepositoryContact> _repositoryContact;
        private readonly Lazy<IRepositoryCourseDetails> _repositoryCourseDetails;
        private readonly Lazy<IRepositoryCourses> _repositoryCourses;
        private readonly Lazy<IRepositoryFAQ> _repositoryFaq;
        private readonly Lazy<IRepositoryGallery> _repositoryGallery;
        private readonly Lazy<IRepositoryGetInTouch> _repositoryGetInTouch;
        private readonly Lazy<IRepositoryInstructors> _repositoryInstructors;
        private readonly Lazy<IRepositorySkills> _repositorySkills;
        private readonly Lazy<IRepositoryWelcomeInformations> _repositoryWelcomeInformations;
        private readonly RepositoryContext _context;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _repositoryAboutUs = new Lazy<IRepositoryAboutUs>(() => new RepositoryAboutUs(_context));
            _repositoryBestCourses= new Lazy<IRepositoryBestCourses(() => new RepositoryBestCourses(_context));
            _repositoryContact = new Lazy<IRepositoryContact(() => new RepositoryContact(_context));
            _repositoryCourseDetails= new Lazy<IRepositoryCourseDetails(() => new RepositoryCourseDetails(_context));
            _repositoryCourses = new Lazy<IRepositoryCourses(() => new RepositoryCourses(_context));
            _repositoryFaq= = new Lazy<IRepositoryFaq(() => new RepositoryFaq(_context));
            _repositoryGallery= new Lazy<IRepositoryGallery(() => new RepositoryGallery(_context));
            _repositoryGetInTouch= new Lazy<IRepositoryGetInTouch(() => new RepositoryGetInTouch(_context));
            _repositoryInstructors= new Lazy<IRepositoryInstructors(() => new RepositoryInstructors(_context));
            _repositorySkills= new Lazy<IRepositorySkills(() => new RepositorySkils(_context));
            _repositoryWelcomeInformations= new Lazy<IRepositoryWelcomeInformations(() => new RepositoryWelcomeInformations(_context));
        }
        


        public void Save()
        {
            _context.SaveChanges();
        }

    }
}