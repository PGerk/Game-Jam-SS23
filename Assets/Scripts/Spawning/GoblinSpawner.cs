using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    [Header("Spawn Behavior")]
    [Tooltip("Time in seconds until spawning begins")]
    [SerializeField, Range(0f, 10f)] float spawnDelay;
    [Tooltip("The amount of Goblins spawned")]
    [SerializeField, Range(0, 255)] int amountSpawned;
    [Tooltip("The time in seconds between Goblin spawns")]
    [SerializeField, Range(0f, 30f)] float timeBetweenSpawns;
    [Tooltip("Offset for the spawn")]
    [SerializeField] Vector2 spawnOffset;
    [Tooltip("The amount of force applied to the spawn explosion")]
    [SerializeField, Range(0f, 100f)] float spawnForce;
    //[Tooltip("X Sway")]
    //[SerializeField] float xSway;
    //[Tooltip("Y Sway")]
    //[SerializeField] float ySway;
    [Tooltip("The Goblin Prefab to spawn")]
    private SpawnMaster spawnMaster;


    private void Awake()
    {
        this.spawnMaster = FindObjectOfType<SpawnMaster>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {        
        yield return new WaitForSeconds(spawnDelay);

        Vector3 spawnPlace = new Vector3(transform.position.x + spawnOffset.x, transform.position.y + spawnOffset.y, 0);

        for (int i = 1; i <= amountSpawned; i++)
        {
            GameObject goblin = this.spawnMaster.GetNewGoblin();
            goblin.transform.position = spawnPlace;
            goblin.transform.rotation = Quaternion.identity;
            goblin.SetActive(true);
            Vector2 spawnExplosionVector = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
            goblin.GetComponent<Rigidbody2D>().AddForce(spawnExplosionVector * spawnForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
