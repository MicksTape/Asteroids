﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int amountAsteroids; //current amount of asteroids in scene
    public int levelNumber = 1;
    public GameObject asteroid;


    public void UpdateAmountAsteroids(int change) {
        amountAsteroids += change;

        //check to see if there are anu asteroids left
        if(amountAsteroids <= 0 ) {
            //next level
            Invoke("NextLevel", 3f);
        }
    }

    void NextLevel() {
        levelNumber++;

        //spawn more asteroids in the next level
        for (int i = 0; i < levelNumber*2; i++) {
            Vector2 spawnPosition = new Vector2(Random.Range(-7.35f, 7.35f), 5.7f);
            Instantiate(asteroid,spawnPosition,Quaternion.identity);
            amountAsteroids++;
        }
        
    }


}
