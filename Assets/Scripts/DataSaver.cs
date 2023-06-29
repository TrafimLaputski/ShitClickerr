using UnityEngine;

public static class DataSaver 
{
    public static void Save(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
        PlayerPrefs.Save();
    }

    public static int Load(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            return PlayerPrefs.GetInt(name);
        }
        else
        {
            return 1;
        }
    }
}
