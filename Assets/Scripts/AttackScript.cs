using Unity.VisualScripting;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField] private string animationName;
    [SerializeField] private bool magicAttack; // will check if the attack is magical or not
    [SerializeField] private float magicCost;
    [SerializeField] private float minAttackMultiplier; // creates some randomness in the skill damage
    [SerializeField] private float maxAttackMultiplier;
    [SerializeField] private float minDefenseMultiplier;
    [SerializeField] private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;
    
    
    public void Attack(GameObject victim)
    {
        
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();
        
        if (attackerStats.magic >= magicCost)//checks if the attacker has enough mana to cast a spell
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
          
            damage = multiplier * attackerStats.melee;
            if (magicAttack)// changes the way damage is calculated if the attack is amgical
            {
                damage = multiplier * attackerStats.magicRange;
                
                
            
            }
            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));// takes away the targets defense away from the damge delt
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.updateMagicFill(magicCost);
        }
        else
        {
            Invoke("SkipTurnContinueGame",2);
        }
        


    }
    void SkipTurnContinueGame()
    {
        GameObject.Find("GameController").GetComponent<GameController>().NextTurn();
    }
   
    
}

