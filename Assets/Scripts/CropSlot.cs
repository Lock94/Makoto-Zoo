using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropSlot : MonoBehaviour
{
    public Text CropName;
    public Text CropCount;
    public Image CropImage;


    public void SetCropSlot(CropProperty cp)
    {
        CropName.text = cp.CropName;
        CropCount.text =string.Format("{0}个/天", cp.CropCount.ToString());
        //image;
    }
}
