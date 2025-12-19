namespace RestWithASPNET10.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parser(O origin);
        List<D> ParseList(List<O> origin);
    }
}
