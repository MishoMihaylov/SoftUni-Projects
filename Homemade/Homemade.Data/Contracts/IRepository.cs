namespace Homemade.Data.Contracts
{
    public interface IRepository
    {
        void AddArticle();

        bool DeleteArticle();

        bool ContainsArticle();

        void EditArticle();

        Article GetArticleById();

        Category GetAllByCategory();

        Subcategory GetAllBySubcategory();
    }
}
