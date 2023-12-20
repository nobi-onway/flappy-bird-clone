using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineSpawnerController : MonoBehaviour
{
    private const float PINE_OFFSET_Y = 2.0f;
    [SerializeField] private GameObject _pineContainer;

    private IEnumerator _spawnPineCoroutine;
    private GameObject _lastPine;

    private void Start()
    {
        _spawnPineCoroutine = SpawnPineCoroutine();
    }

    public void EnableSpawner()
    {
        StartCoroutine(_spawnPineCoroutine);
    }

    public void DisableSpawner()
    {
        StopCoroutine(_spawnPineCoroutine);
    }

    public void ResetPine()
    {
        Destroy(_lastPine);
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
        float verticlePos = Random.Range(-PINE_OFFSET_Y, PINE_OFFSET_Y);

        Vector2 position = new Vector2(transform.position.x, verticlePos);

        _lastPine = Instantiate(_pineContainer, position, Quaternion.identity);

        Destroy(_lastPine, 5);
    }
}
