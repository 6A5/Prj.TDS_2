using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testManager : MonoBehaviour
{
    public float hp = 20;
    public float mp = 5;
    public testHero hero = new testHero(20, 5);


    private void Awake()
    {
        print(hero.hp);
    }
}
