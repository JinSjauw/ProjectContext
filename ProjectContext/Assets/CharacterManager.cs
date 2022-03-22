using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterManager
{
    public static List<Character> characterList = new List<Character>(); 
}

[System.Serializable]
public class Character
{
    public int i_TotalPoints;
    public int i_ConstitutionPoints;
    public int i_StrengthPoints;
    public int i_DexterityPoints;
    public int i_IntelligencePoints;

    public Texture2D characterImage = null;

    private float HP;
    private float AttackPower;
    private float Speed;

    public void Setup() 
    {
        HP = i_ConstitutionPoints * 5.2f;
        AttackPower = i_StrengthPoints * 1.65f;
        Speed = i_DexterityPoints * 1.2f;
    }

    public float GetAttackPower() 
    {
        return this.AttackPower;
    }

    public float GetSpeed() 
    {
        return this.Speed;
    }

    public float GetHP() 
    {
        return this.HP;
    }

    public void setHP(float HP) 
    {
        this.HP = HP;
    }

    public void TakeDamage(float damage) 
    {
        HP = HP - damage;
    }

}
