using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "S&D/Heroes/Hero", order = 0)]
public class Hero : Character
{
    public int Level;
    public HeroColor HeroColor;
    public DiceFace[] StartingFaces = new DiceFace[6];
}