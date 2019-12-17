using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    // Use this for initialization
    public int health;
    public int nHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < nHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void damage(int dam = 1)
    {
        if(health > 1)
        {
            health-= dam;
        }
        else
        {
            //gameOver
        }
    }

    public void curar(int cura)
    {
        if(health < nHearts)
        {
            health += cura;
        }
    }

    public void upgradeVida()
    {
        nHearts++;
    }
}