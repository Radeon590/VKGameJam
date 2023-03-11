using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour, IinfoBlock
{
    private static StorageInfo s_storage;

    public static StorageInfo Storage
    {
        get { return s_storage; }
    }

    public static int Money = 1000;

    public void LoadInfo()
    {
        s_storage = new StorageInfo();
        s_storage.LoadInfo();
    }
}
