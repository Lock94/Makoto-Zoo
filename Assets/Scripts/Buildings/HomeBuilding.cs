using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBuilding : Building
{
    private PlayerBaseProperty playerBase;

    private void Start()
    {
        playerBase = new PlayerBaseProperty
        {
            PlayerName = "人渣诚",
            CurrentEnergy = 100,
            MaxEnergy = 100,
            CoinCount = 0,
            EarnCoin = 0,
            PlayDays =0,
            AnimalCount = 0,
            CropCount =0
        };
    }

    public override void ShowBuildingPanel()
    {
        if (!(P2B is HomePanel))
        {
            Debug.LogError("对应的UI错误，请检查!");
            return;
        }
        HomePanel HP2B = (HomePanel)P2B;
        HP2B.SetMessage2List(playerBase);
        base.ShowBuildingPanel();
    }

}