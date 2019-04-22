using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingPanel P2B;

    public virtual void ShowBuildingPanel()
    {
        if (P2B == null )
        {
            Debug.LogWarning("未配置对于UI，请检查");
            return;
        }
        P2B.Show();
    }
}
