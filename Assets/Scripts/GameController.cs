using UnityEngine;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private List<FighterStats> fighterStats;
    [SerializeField] private GameObject battleMenu;// battle menu is the option menu that lets the player attack
    public Text battleText;
    void Start()
    {
        // allows as to decide whether the enemy or player goes first based on speed
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);
        
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);
        
        fighterStats.Sort();
        this.battleMenu.SetActive(false);

        NextTurn();
        
    }

   public void NextTurn()
   {
       battleText.gameObject.SetActive(false);//hides the battletext
       FighterStats currentFighterStats = fighterStats[0];
       fighterStats.Remove(currentFighterStats);
       if (!currentFighterStats.GetDead())
       {
           GameObject currentUnit = currentFighterStats.gameObject;
           currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
           fighterStats.Add(currentFighterStats);
           fighterStats.Sort();
           if (currentUnit.tag == "Hero")
           {
              this.battleMenu.SetActive(true); 
           }
           else//allows enemy to attack
           {
               string attackType = Random.Range(0,2) == 1 ? "melee" : "range";
               currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
           }

       }
       else 
       {
          NextTurn(); 
       }
    }
}
