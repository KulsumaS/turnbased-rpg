using System;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    public static PlayerGameController control;
    [SerializeField] FighterStats fighterStats;
    [SerializeField] PlayerContoller playerContoller;
    
    public float health;
    public float magic;
    public float melee;
    public float magicRange;
    public float defense;
    public float speed;
    
    public float x;
    public float y;

    private void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(this.gameObject);
            control = this;
            
        }
        else if (control != this)
        {
            Destroy(this.gameObject);
        }
        
    }
}
