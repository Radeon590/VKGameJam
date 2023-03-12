using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private Transform spawnPoint;

    private int _carNumber = 0;

    public void StartSpawning()
    {
        StartCoroutine(SpawningCycle());
    }

    private IEnumerator SpawningCycle()
    {
        while (true)
        {
            if (_carNumber == 2)
            {
                _carNumber = 0;
            }
            Instantiate(car, spawnPoint.position, spawnPoint.rotation).GetComponent<Car>().SpriteNumber = _carNumber;
            yield return new WaitForSeconds(10);
            _carNumber++;
        }
    }
}
