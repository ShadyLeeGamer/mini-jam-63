using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorManager")]
public class ColorManager : ScriptableObject
{
    public Color[] playerCol, victimCol, threatCol, BGCol, obstacleCol;
}
