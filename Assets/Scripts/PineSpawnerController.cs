using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineSpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject _pineContainer;

    private void Start()
    {
        StartCoroutine(SpawnPineCoroutine());
    }

    private IEnumerator SpawnPineCoroutine()
    {
        while(true)
        {
            float secondsTime = Random.Range(1.5f, 3f);
            yield return new WaitForSeconds(secondsTime);
            SpawnPine();
        }
    }

    private void SpawnPine()
    {
        Instantiate(_pineContainer, transform.position, Quaternion.identity);
    }
}
