using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject Asteroid;

    public Transform[] spawners;

    RootNode rootNode;

    public Node.Status treeStatus = Node.Status.RUNNING;

    private void Start()
    {
    }

    public Node.Status SpawnAsteroid()
    {
        var Instance = Instantiate(Asteroid, spawners[UnityEngine.Random.Range(-1, spawners.Length - 1)].position, Quaternion.identity);
        return Node.Status.SUCCESS;
    }

    void Update()
    {
        AI();

        if (treeStatus == Node.Status.RUNNING)
            treeStatus = rootNode.Process();
    }

    void AI()
    {
        treeStatus = Node.Status.RUNNING;
        rootNode = new RootNode();
        Sequence spawner = new Sequence("Spawner");
        Leaf spawnAsteroid = new Leaf("SpawnAsteroid", SpawnAsteroid);
        spawner.AddChild(spawnAsteroid);
        rootNode.AddChild(spawner);
    }
}
