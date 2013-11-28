namespace MetaLoaderLib.Interfaces
{
    using MetaLoaderLib;

    public interface IPageParser
    {
        MetaInformationContainer Parse(string isbn);
    }
}
