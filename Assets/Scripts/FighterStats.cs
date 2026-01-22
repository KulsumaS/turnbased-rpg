using System;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject healthFill;//represents players health left
    [SerializeField] private GameObject magicFill;// represents players mana left

    
    [Header("Stats")]
    public float health;
    public float magic;
    public float melee;
    public float magicRange;
    public float defense;
    public float speed;
    public float experience;

    private float startHealth;
    private float startMagic;

    [HideInInspector] //hides the public variable in the inspector so that i cant mess with it
    public int nextActTurn;// used to calculate whose turn is next 
    
    private bool dead = false;
    
    //makes the magic and health bar resizeable
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;
    
    private GameObject GameControllerObj;
    
    void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;
        
        magicTransform = magicFill.GetComponent<RectTransform>();
        magicScale = magicFill.transform.localScale;

        startHealth = health;
        startMagic = magic;
        
        GameControllerObj = GameObject.Find("GameController");
        PlayerContoller.control.melee = melee;


    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        PlayerContoller.control.health = health;
        animator.Play("Damage");

        if (health <= 0)// checks if player is dead
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        }
        else if (damage > 0)
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }

        if (damage > 0)
        {
            GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);//text becomes visible
            GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();
        }
        
        Invoke(nameof(ContinueGame), 2);
    }

  
    public void updateMagicFill(float cost)
    {
        if (cost > 0)
        {
            magic -= cost;
            PlayerContoller.control.magic = magic;
            xNewMagicScale = magicScale.x * (magic / startMagic);
            magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);  
        }
      
    }

    public bool GetDead()// returns the status of the player
    {
        return dead;
    }
    void ContinueGame()
    {
        GameObject.Find("GameController").GetComponent<GameController>().NextTurn();
    }


    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f/speed);
    }
    
    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return nex;
    }

    
    
    
    
}

