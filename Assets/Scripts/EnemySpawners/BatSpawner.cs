using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject batPrefab;
    [SerializeField] private float timeBetweenSpawn;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer> timeBetweenSpawn){
            Instantiate(batPrefab, new Vector3(Random.Range(
                transform.position.x - 5f, transform.position.x + 5f), Random.Range(transform.position.y - 5f, transform.position.x + 5f),0),
                Quaternion.identity);
                EnemyController.Counter++;
            timer=0f;
        }
    }
}
