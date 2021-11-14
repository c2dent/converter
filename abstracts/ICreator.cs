namespace converter
{
    interface ICreator
    {
        IConverter GetConverter(string[] args);
    }
}
