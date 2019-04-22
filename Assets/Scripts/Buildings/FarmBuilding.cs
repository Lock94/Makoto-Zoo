using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBuilding : Building
{
    public int FramLevel = 1;

    private CropProperty rabish;

    private void Start()
    {
        rabish = new CropProperty();
        rabish.CropID = 1;
        rabish.CropName = "萝卜";
        rabish.CropCount = 10;
    }

    public override void ShowBuildingPanel()
    {
        if (!(P2B is FarmPanel))
        {
            Debug.LogError("对应的UI错误，请检查!");
            return;
        }
        FarmPanel FP2B = (FarmPanel)P2B;

        FP2B.CheckCrops(FramLevel, rabish);
        base.ShowBuildingPanel();
    }
}
