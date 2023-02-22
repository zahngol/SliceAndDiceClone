using UnityEngine;

[CreateAssetMenu(fileName = "DiceFace", menuName = "S&D/Dice/DiceFace", order = 0)]
public class DiceFace : ScriptableObject
{
    public string Name;
    public Sprite Picture;
    public int Strength;
}