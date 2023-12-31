using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Constant
{
    public static string DataKey_PlayerData = "player_data";
    public static int countSong = 54;
    public static int priceUnlockSong = 10;
}

public class PlayerData : BaseData
{
    [FormerlySerializedAs("intDiamond")] public int bullets;
    public int crtMusicalIns;
    public bool[] listMusical;
    public bool isUnlock;

    public long time;
    public string timeRegister;

    public bool isRate;

    public void Rated()
    {
        isRate = true;
    }

    public bool IsRate => isRate;

    public void SetTimeRegister(long timeSet)
    {
        timeRegister = DateTime.Now.ToBinary().ToString();
        time = timeSet;
        Save();
    }

    public void ResetTime()
    {
        time = 0;
        Save();
    }


    public override void Init()
    {
        prefString = Constant.DataKey_PlayerData;
        if (PlayerPrefs.GetString(prefString).Equals(""))
        {
            ResetData();
        }

        base.Init();
    }


    public override void ResetData()
    {
        timeRegister = DateTime.Now.ToBinary().ToString();
        time = 3 * 24 * 60 * 60;

        bullets = 100;
        crtMusicalIns = 0;
        listMusical = new bool[Constant.countSong];
        isUnlock = false;

        //listMusical[0] = true;
        for (int i = 0; i < 10; i++)
        {
            listMusical[i] = true;
        }

        Save();
    }

    public void AddBullets(int a)
    {
        bullets += a;

        GameManager.OnChangeBullet?.Invoke(a);

        Save();
    }

    public void Shoot()
    {
        bullets--;

        GameManager.OnChangeBullet?.Invoke(1);

        Save();
    }

    public bool CheckCanUnlock(int price, int id)
    {
        if (bullets < price) return false;
        SubDiamond(price);
        Unlock(id);
        return true;
    }

    public bool CheckLock(int id)
    {
        return this.listMusical[id];
    }

    public void Unlock(int id)
    {
        if (!listMusical[id])
        {
            listMusical[id] = true;
        }

        Save();
    }


    public void UnlockPack()
    {
        isUnlock = true;
        Save();
    }

    public void SubDiamond(int a)
    {
        bullets -= a;

        if (bullets < 0)
        {
            bullets = 0;
        }

        GameManager.OnChangeBullet?.Invoke(-a);

        Save();
    }

    public void ChooseSong(int i)
    {
        crtMusicalIns = i;
        Save();
    }
}