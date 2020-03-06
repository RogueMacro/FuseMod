namespace Fuse.API
{
    public interface ISettings
    {
        bool GetBool(string name);
        float GetFloat(string name);
        int GetInt(string name);
        string GetSetting(string name);
    }
}