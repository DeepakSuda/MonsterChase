using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomside;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomside = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomside == 0)
            {

                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                if (spawnedMonster.CompareTag("Ghost"))
                {
                    spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    spawnedMonster.transform.localScale = new Vector3(-0.55f, 0.55f, 1f);
                }
            }
        }
    }
}




















