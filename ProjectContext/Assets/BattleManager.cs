using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, RPS, PLAYER1TURN, PLAYER2TURN, WON, LOST }

public class BattleManager : MonoBehaviour
{
    public Character player1, player2;
    public RawImage playerImage1, playerImage2;
    public BattleHUD playerHUD1, playerHUD2;
    public TextMeshProUGUI announcer;

    public BattleState state;

    private bool hasClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        player1 = CharacterManager.characterList[CharacterManager.characterList.Count - 2];
        player2 = CharacterManager.characterList[CharacterManager.characterList.Count - 1];

        state = BattleState.START;
        StartCoroutine(Setup());
    }

    IEnumerator Setup() 
    {
        playerImage1.texture = player1.characterImage;
        playerImage2.texture = player2.characterImage;

        player1.Setup();
        playerHUD1.SetHUD(player1);
        player2.Setup();
        playerHUD2.SetHUD(player2);

        yield return new WaitForSeconds(2f);

        state = BattleState.RPS;
        CoinFlip();
    }

    void CoinFlip() 
    {
        int coin = Random.Range(0, 1);
        if(coin == 0) 
        {
            Player1Turn();
        }

        if(coin == 1) 
        {
            Player2Turn();
        }   
    }

    public void OnAttackButton() 
    {
        if (hasClicked) 
        {
            return;
        }

        switch(state) 
        {
            case BattleState.PLAYER1TURN:
                StartCoroutine(Attack(player1, player2));
                Debug.Log("Player 1 Attacking Player 2! " + player2.GetHP());
                break;
            case BattleState.PLAYER2TURN:
                StartCoroutine(Attack(player2, player1));
                Debug.Log("Player 2 Attacking Player 1! " + player1.GetHP());

                break;
        }

        hasClicked = true;
    }

    IEnumerator Attack(Character attacker, Character defender) 
    {
        defender.TakeDamage(attacker.GetAttackPower());

        switch (state) 
        {
            case BattleState.PLAYER1TURN:
                playerHUD2.UpDateHealth(defender.GetHP());

                yield return new WaitForSeconds(.5f);
                
                Player2Turn();

                break;
            case BattleState.PLAYER2TURN:
                playerHUD1.UpDateHealth(defender.GetHP());

                yield return new WaitForSeconds(.5f);
                
                Player1Turn();

                break;
        }

        if(player1.GetHP() < 0) 
        {
            StartCoroutine(EndBattle("Player 2 WON"));
        }
        else if(player2.GetHP() < 0)
        {
            StartCoroutine(EndBattle("Player 1 WON"));

        }
    }

    void Player1Turn() 
    {
        hasClicked = false;
        state = BattleState.PLAYER1TURN;
        announcer.text = "Player 1 Turn";
        playerHUD1.attackButton.interactable = true;
        playerHUD1.defenseButton.interactable = true;

        playerHUD2.attackButton.interactable = false;
        playerHUD2.defenseButton.interactable = false;
    }
    void Player2Turn() 
    {
        hasClicked = false;
        state = BattleState.PLAYER2TURN;
        announcer.text = "Player 2 Turn";
        playerHUD2.attackButton.interactable = true;
        playerHUD2.defenseButton.interactable = true;

        playerHUD1.attackButton.interactable = false;
        playerHUD1.defenseButton.interactable = false;
    }

    IEnumerator EndBattle(string message) 
    {
        announcer.text = message;
        state = BattleState.LOST;

        playerHUD2.attackButton.interactable = false;
        playerHUD2.defenseButton.interactable = false;

        playerHUD1.attackButton.interactable = false;
        playerHUD1.defenseButton.interactable = false;

        yield return null;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
