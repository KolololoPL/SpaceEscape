using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Enemies {Generic, Fighter, Soldier, Tank}

public class SpawnManager : MonoBehaviour {
	public static SpawnManager current;

	public GameObject fighterSample;
	public GameObject soldierSample;

	List<FighterEnemy> fighters = new List<FighterEnemy>(); 
	List<SoldierEnemy> soldiers = new List<SoldierEnemy>(); 

	void Start() {
		SpawnManager.current = this;

		EventManager.OnEnemyDestroy += OnEnemyDestroy;
		SetTracks();
	}

	float fighterTime = -2, soldierTime = -10;
	void Update() {
		//Spawning fighters
		if (fighterTime >= 10)	{
			RevokeEnemies(Enemies.Fighter);
			fighterTime = -2 - Random.Range(0, 10);
		}

		if (fighterTime >= -1 && fighterTime < 0)
			fighterTime = 0;

		if (fighterTime == 0)
			SpawnFighters();

		fighterTime += Time.deltaTime;

		//Spawning soldier
		if (soldierTime >= 0) {
			soldierTime = -20 + Random.Range(0, (int) (PointsController.current.GetPoints() / 500));
			if (soldierTime > -5)
				soldierTime = -5;

			for (int x = 0; x < (int) ((PointsController.current.GetPoints() / 300) + 1); x++)
				StartCoroutine(SpawnSoldier(x));
		}
		soldierTime += Time.deltaTime;
	}

	void SpawnFighters() {
		int[] states;
		List<Vector3> sampleTracks;
		int test = Random.Range(0, 101) % 3;

		if (test == 0) {
			int[] statesTemp = {1, 3, 5, 7, 9, 11};
			states = statesTemp;

			sampleTracks = diamondTrack;
		} else if (test == 1){
			int[] statesTemp = {0, 1, 2, 3, 4, 5};
			states = statesTemp;
			
			sampleTracks = rhomboidTrack;
		} else {
			int[] statesTemp = {0, 1, 2, 3, 4, 5};
			states = statesTemp;
			
			sampleTracks = crossingTrack;
		}


		for (int x = 0; x < 6; x++) {
			GameObject spawned = Instantiate(fighterSample, sampleTracks[states[x]], Quaternion.identity) as GameObject;
			FighterEnemy fighter = spawned.GetComponent<FighterEnemy>();

			List<Vector3> track = new List<Vector3>();
			int startState = states[x];

			for (int y = 0; y < sampleTracks.Count; y++) {
				if (y + startState >= sampleTracks.Count)
					startState -= sampleTracks.Count;
				track.Add(sampleTracks[y + startState]);
			}

			fighter.SetMovesList(track);
			fighters.Add(fighter);
		}
	}

	IEnumerator SpawnSoldier(float x) {
		yield return new WaitForSeconds(x);

		GameObject spawned = Instantiate(soldierSample, new Vector3(0, 2.5f, 0), Quaternion.identity) as GameObject;
		SoldierEnemy soldier = spawned.GetComponent<SoldierEnemy>();

		soldiers.Add(soldier);
	}

	void RevokeEnemies(Enemies type) {
		if (type == Enemies.Fighter){
			for (int x = 0; x < fighters.Count; x++)
				fighters[x].Revoke();
		} else if (type == Enemies.Soldier) {
			for (int x = 0; x < soldiers.Count; x++)
				soldiers[x].Revoke();
		}
	}

	void OnEnemyDestroy(EnemyDestroyEvent e) {
		if (e.GetEnemyClass() is FighterEnemy)
			fighters.Remove((FighterEnemy) e.GetEnemyClass());
		else if (e.GetEnemyClass() is SoldierEnemy)
			soldiers.Remove((SoldierEnemy) e.GetEnemyClass());
	}

	public int GetEnemiesCount(Enemies type) {
		if (type == Enemies.Fighter)
			return fighters.Count;
		else if (type == Enemies.Soldier)
			return soldiers.Count;
		return -1;
	}

	//Tracking
	List<Vector3> diamondTrack = new List<Vector3>();
	List<Vector3> rhomboidTrack = new List<Vector3>();
	List<Vector3> crossingTrack = new List<Vector3>();

	void SetTracks() {
		diamondTrack.Add(new Vector3(-2.5f, 2.5f, 0));
		diamondTrack.Add(new Vector3(-2, 4, 0));
		diamondTrack.Add(new Vector3(-1, 3, 0));
		diamondTrack.Add(new Vector3(0, 4, 0));
		diamondTrack.Add(new Vector3(1, 3, 0));
		diamondTrack.Add(new Vector3(2, 4, 0));
		diamondTrack.Add(new Vector3(2.5f, 2.5f, 0));
		diamondTrack.Add(new Vector3(2, 1, 0));
		diamondTrack.Add(new Vector3(1, 2, 0));
		diamondTrack.Add(new Vector3(0, 1, 0));
		diamondTrack.Add(new Vector3(-1, 2, 0));
		diamondTrack.Add(new Vector3(-2, 1, 0));

		rhomboidTrack.Add(new Vector3(-3, 3.5f, 0));
		rhomboidTrack.Add(new Vector3(-1, 3.5f, 0));
		rhomboidTrack.Add(new Vector3(1, 3.5f, 0));
		rhomboidTrack.Add(new Vector3(3, 2, 0));
		rhomboidTrack.Add(new Vector3(1, 2, 0));
		rhomboidTrack.Add(new Vector3(-1, 2, 0));

		crossingTrack.Add(new Vector3(-3, 2.5f, 0));
		crossingTrack.Add(new Vector3(-1, 4, 0));
		crossingTrack.Add(new Vector3(1, 1, 0));
		crossingTrack.Add(new Vector3(3, 2.5f, 0));
		crossingTrack.Add(new Vector3(1, 4, 0));
		crossingTrack.Add(new Vector3(-1, 1, 0));
	}
}
