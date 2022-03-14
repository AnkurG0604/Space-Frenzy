using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] Vector3 center;
    [SerializeField] Vector3 size;

    public Rigidbody2D Asteroid;

    public Transform[] spawners;

    [SerializeField] Rigidbody2D LivesPowerUp;
    [SerializeField] Rigidbody2D RandomizerPowerUp;

    [SerializeField] Transform LivesSpawn;
    [SerializeField] Transform RandomizerSpawn;

    RootNode rootNode;

    float timer = 0;
    float enemySpawnRate = 1;
    float timeBase = 5;

    float uniTimer = 0;

    //float timerPlus = 0;

    bool TimerStop;

    [SerializeField] float EnemySpeed = 500;

    [SerializeField] Text WaveStatus;
    [SerializeField] Text TimeStatus;

    public Node.Status treeStatus = Node.Status.RUNNING;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(center, size);
    }

    private void Start()
    {
        AI();
    }

    void SpawnEnemy()
    {
        Vector3 randomPosition = new Vector3(0, Random.Range(size.y/2,-size.y/2), 0) + center;
        var Instance = Instantiate(Asteroid, randomPosition, Quaternion.identity);
        Instance.AddForce(Vector2.left * EnemySpeed);
        Destroy(Instance.gameObject, 3);
    }

    public Node.Status WaveOneAprroaching()
    {
        WaveStatus.text = "ENEMIES APPROACHING";
        return Node.Status.SUCCESS;
    }

    public Node.Status WaitFor()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer > timeBase)
        {
            WaveStatus.text = "";
            Debug.Log("Success");
            timer = 0;
            return Node.Status.SUCCESS;    
        }
        return Node.Status.RUNNING;
    }

    public Node.Status SpawnAsteroid()
    {
        timer += Time.deltaTime;
        if(timer > enemySpawnRate)
        {
            SpawnEnemy();
            timer = 0;
        }
        return Node.Status.RUNNING;
    }

    void Update()
    {
        if(!TimerStop)
        {
            uniTimer += Time.deltaTime;
            TimeStatus.text = uniTimer.ToString();
        }

        if (treeStatus == Node.Status.RUNNING)
            treeStatus = rootNode.Process();
    }

    void AI()
    {
        treeStatus = Node.Status.RUNNING;
        rootNode = new RootNode();

        Sequence spawner = new Sequence("Spawner");
        
        Leaf waveOneApproaching = new Leaf("status", WaveOneAprroaching);
        Leaf waitFor = new Leaf("Wait For", WaitFor);
        Leaf spawnAsteroid = new Leaf("SpawnAsteroid", SpawnAsteroid);

        spawner.AddChild(waveOneApproaching);
        spawner.AddChild(waitFor);
        spawner.AddChild(spawnAsteroid);

        rootNode.AddChild(spawner);
    }
}
