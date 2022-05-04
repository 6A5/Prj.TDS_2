using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testUsingHero : MonoBehaviour
{
    public testHero hero;
    public testManager manager;

    private void Start()
    {
        hero = manager.hero;
        print(hero.mp);
    }
}
