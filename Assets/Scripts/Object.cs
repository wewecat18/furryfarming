using UnityEngine;
[CreateAssetMenu]
public class Object : ScriptableObject
{
    public string itemName;
    public stat Stat = new stat();
    public int AmountS;
    public attributes Attri = new attributes();
    public int AmountA;
    public void UseItem()
    {
        Debug.Log("Usaste el objeto " + itemName);
    }
    public enum stat
    {
        none,
        health,
        mana,
        stamina
    };
    public enum attributes
    {
        none,
        Str,
        Def,
        Int,
        Agi
    };

    
}
