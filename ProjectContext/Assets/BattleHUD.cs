using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleHUD : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthBar player1Health;
    public Button attackButton, defenseButton;

    public void SetHUD(Character character) 
    {
        player1Health.SetMaxValue(character.GetHP());
        player1Health.SetValue(character.GetHP());
    }

    public void UpDateHealth(float value) 
    {
        player1Health.SetValue(value);
    }

}
