using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmPanel : BuildingPanel
{
    public GameObject CropPFB;

    private Button riseFarm;
    private Transform content;

    private int cropCount = 0;

    public override void Start()
    {
        base.Start();
        riseFarm = transform.Find("Rise").GetComponent<Button>();
        content = transform.Find("Crops").Find("Scroll View").GetComponent<ScrollRect>().content;
        riseFarm.onClick.AddListener(RiseFarm);
    }

    public void CheckCrops(int level,CropProperty cp)
    {
        if (level == cropCount) return;
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
        for (int i = 0; i < level; i++)
        {
            GameObject go = Instantiate(CropPFB, content);
            go.GetComponent<CropSlot>().SetCropSlot(cp);
        }     
    }
    public void RiseFarm()
    {
        //TODO 升级农场
    }
}
