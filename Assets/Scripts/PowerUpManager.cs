using System;
using NUnit.Framework;
using UnityEngine;
using Collectibles;

public class PowerUpManager : MonoBehaviour {
	//Toggle through collected abilities & display
	//in the array, position 0 is pickles, 1 is cheese, 2 is tomato, and 3 is lettuce
	int[] powerups;
	int currentPower;

	void Start() {
		powerups = new int[] {0,0,0,0};
		currentPower = -1;
	}

	void Update() {
		if (Collectibles.pickle_activated) {
			powerups [0] = 1;
			currentPower = 0;
		}


	}



	
}


