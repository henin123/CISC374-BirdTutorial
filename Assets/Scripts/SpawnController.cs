using UnityEngine;
using UnityEngine.Rendering;

public class SpawnController : MonoBehaviour
{
    public GameObject pipesPreFab;
    private float timer = 0.0f;
    public float spawnTime = 2.0f;
    public float heightOffset = 9;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawnPipes();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnTime){
            timer = timer + Time.deltaTime;
        } else {
            spawnPipes();
            timer = 0.0f;
        }
    }

    void spawnPipes()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipesPreFab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
