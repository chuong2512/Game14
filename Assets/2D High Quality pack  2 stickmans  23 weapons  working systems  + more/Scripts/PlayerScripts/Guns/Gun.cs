using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string Name;
    public AudioClip Song;

    public void ShootTrigger()
    {
        if (GameDataManager.Instance.playerData.bullets > 0)
        {
            AudioManager.Instance.Fire(Song);
            GameDataManager.Instance.playerData.Shoot();
        }
        else
        {
            UIManager.Instance.OpenScreen(ScreenType.IAPScreen);
        }
    }

    public void SetActive(bool b)
    {
        gameObject.SetActive(b);
    }
}