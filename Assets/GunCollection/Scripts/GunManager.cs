using TMPro;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Gun[] guns;

    public int currentID;

    public TextMeshProUGUI _remainBullets;
    public TextMeshProUGUI nameGun;

    private void Start()
    {
        ShowGun(0);
        SetTextBullets();
        GameManager.OnChangeBullet += ChangeBullet;
    }

    private void ChangeBullet(int a)
    {
        SetTextBullets();
    }

    private void SetTextBullets()
    {
        _remainBullets.SetText("Bullets :" + GameDataManager.Instance.playerData.bullets.ToString());
    }

    public void ShowGun(int id)
    {
        currentID = id;

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(id == i);
        }
        
        SetName();
    }

    public void SetName()
    {
        nameGun.SetText(guns[currentID].Name);
    }

    public void Next()
    {
        currentID++;
        if (currentID >= guns.Length)
        {
            currentID = guns.Length - 1;
        }

        ShowGun(currentID);
        AudioManager.Instance.ClickSound();
    }

    public void Previous()
    {
        currentID--;
        if (currentID < 0)
        {
            currentID = 0;
        }

        ShowGun(currentID);
        AudioManager.Instance.ClickSound();
    }

    public void Shoot()
    {
        guns[currentID].ShootTrigger();
    }
}