using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropProperty
{
    public int CropID { get; set; }
    public string CropName { get; set; }
    public int RipeDays { get; set; }   //作物成熟需要的天数
    public int CropCount { get; set; }  //作物成熟的数量
    public string CropImage { get; set; } //作物的图标
}
