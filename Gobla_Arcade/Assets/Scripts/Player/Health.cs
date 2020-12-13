
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Health : MonoBehaviour
{
    private const int GameOver = 2;

    //Health
    private const int StartingHealth = 3;
    private int m_CurrentHealth;                      
    private bool m_Dead;                              
    
    public Image hearth01;
    public Image hearth02;
    public Image hearth03;
    
    
    private void OnEnable()
    {
        m_CurrentHealth = StartingHealth;
        m_Dead = false;
        SetAllHealthHearth();
    }
    

    public void TakeDamage(int amount)
    {
        DeleteHearth(m_CurrentHealth);
        m_CurrentHealth -= amount;
        
        
        if (m_CurrentHealth <= 0 && !m_Dead)
        {
            OnDeath();
        }
    }
    

    private void DeleteHearth(int hearthNumber)
    {
        if (hearthNumber == 1)
        { 
            hearth01.enabled = false; 
        }
        if (hearthNumber == 2)
        { 
            hearth02.enabled = false; 
        }
        if (hearthNumber == 3)
        { 
            hearth03.enabled = false; 
        }
    }    
    
    private void AddHearth(int hearthNumber)
    {
        if (hearthNumber == 1)
        { 
            hearth01.enabled = true; 
        }
        if (hearthNumber == 2)
        { 
            hearth02.enabled = true; 
        }
        if (hearthNumber == 3)
        { 
            hearth03.enabled = true; 
        }
    } 
    
    private void SetAllHealthHearth()
    {
        hearth01.enabled = true;
        hearth02.enabled = true;
        hearth03.enabled = true;
    }
    
    private void OnDeath()
    {
        m_Dead = true;
        SceneManager.LoadScene(GameOver);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("Enemy")){
           TakeDamage(1);
       }
    }
}
   


