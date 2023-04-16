using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedCarRandSpawner : MonoBehaviour
{
    [SerializeField] DirectionMover[] lightCarPrefabsToSpawn;
    [SerializeField] DirectionMover[] heavyCarPrefabsToSpawn;
    [SerializeField] float velocityOfLightSpawnedObject;
    [SerializeField] float velocityOfHeavySpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 3f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 4f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 0.5f;
    [Tooltip("The direction vector of the prefabs")] [SerializeField] private Vector3 direction;

    void Start() {
        this.StartCoroutine(SpawnRoutine());    // co-routines
        // _ = SpawnRoutine();                   // async-await
    }

    IEnumerator SpawnRoutine() {    // co-routines
        // async Task SpawnRoutine() {  // async-await
        while (true) {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            int randCarType = Random.Range(0, 2);
            DirectionMover[] currCars = randCarType == 0 ? lightCarPrefabsToSpawn : heavyCarPrefabsToSpawn;
            float carsSpeed = randCarType == 0 ? velocityOfLightSpawnedObject : velocityOfHeavySpawnedObject;
            int randCar = Random.Range(0, currCars.Length);
            
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
            // await Task.Delay((int)(timeBetweenSpawnsInSeconds*1000));       // async-await
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);
            
            // Rotate the cars according to the direction vector
            Quaternion rotationOfSpawnedObject = Quaternion.Euler(0, 0, -Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

            GameObject newObject = Instantiate(currCars[randCar].gameObject, positionOfSpawnedObject, rotationOfSpawnedObject);
            DirectionMover directionMover = newObject.GetComponent<DirectionMover>();
            directionMover.SetDirection(direction);  
            directionMover.SetVelocity(carsSpeed);
        }
    }
}
