namespace Infrastructure.SaveLoad
{
    public interface IProgressSaver
    {
        public void Save(GameProgressData gameProgressData);
    }
}