namespace converter
{
    public class CreatorJsonCsv: ICreator
    {
        public IConverter GetConverter(string[] args)
        {
            return new JsonToCsv(args);
        }
    }
}