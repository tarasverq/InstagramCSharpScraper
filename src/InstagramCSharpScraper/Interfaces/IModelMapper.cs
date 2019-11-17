namespace InstagramCSharpScraper.Interfaces
{
    public interface IModelMapper
    {
        TDestination Map<TDestination>(object source);
    }
}