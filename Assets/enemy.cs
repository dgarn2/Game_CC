using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int curHealth;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(int Damage){
        curHealth -= Damage;
        if(curHealth<=0){
            Die();
        }
    }

    void Die(){
        Debug.Log("dd");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
