using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EndlessRunningGameManangerBehaviour : MonoBehaviour
{
    public static EndlessRunningGameManangerBehaviour instance;
    private int obstacleRandomNumber;
    private int cylinderPosition;
    private int scoreToInt;
    private float elapseTime;
    private PlayerData loadGameData;
    private GameObject obstacle;
    [HideInInspector] public List<GameObject> activeObstacles;
    [SerializeField] private Canvas gameScreenCanvas;
    [SerializeField] private GameObject[] obstaclesPreFabs;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generateObstacles", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ashjbd: " + scoreToInt);
    }

    public void generateObstacles()
    {
        obstacleRandomNumber = Random.Range(0, 3);
        if (obstacleRandomNumber == 0)      /*Spawn a BigWall*/
        {
            obstacle = Instantiate<GameObject>(obstaclesPreFabs[obstacleRandomNumber]);
            //Debug.Log("obstacle" + obstacle);
            addObstacleToList(obstacle);
            
            obstacle.transform.position = new Vector3(Random.Range(-5.15f, 0.4f), 2.227f, -4f);
        }
        else if (obstacleRandomNumber == 1)         /*Spawn a HorizontalCylinder*/
        {
            cylinderPosition = Random.Range(0, 2);
            obstacle = Instantiate<GameObject>(obstaclesPreFabs[obstacleRandomNumber]);
            addObstacleToList(obstacle);
            if (cylinderPosition == 0)
                obstacle.transform.position = new Vector3(-2.39f, 1.4f, -4f);
            else
                obstacle.transform.position = new Vector3(-2.39f, 1.7f, -4f);
        }
        else if (obstacleRandomNumber == 2)         /*Spawn a BoucingBall bouncing sideways*/
        {
            obstacle = Instantiate<GameObject>(obstaclesPreFabs[obstacleRandomNumber]);
            addObstacleToList(obstacle);
            obstacle.transform.position = new Vector3(Random.Range(-5.7f, 0.95f), 1.5f, -4f);
        }
        else            /*Spawn a BigWall with a HorizontalCylinder*/
        {
            obstacle = Instantiate<GameObject>(obstaclesPreFabs[0]);
            obstacle.transform.position = new Vector3(Random.Range(-5.15f, 0.4f), 2.227f, -4f);
            obstacle = Instantiate<GameObject>(obstaclesPreFabs[1]);
            addObstacleToList(obstacle);
            obstacle.transform.position = new Vector3(-2.39f, 1.42f, -4f);
        }
    }

    public void addScore(int score)
    {
        int.TryParse(gameScreenCanvas.GetComponent<GameCanvasHelper>().scoreTextField.text, out scoreToInt);
        scoreToInt += score;
        gameScreenCanvas.GetComponent<GameCanvasHelper>().scoreTextField.text = scoreToInt.ToString();
    }

    public void onPlayerDeath()
    {
        CancelInvoke("generateObstacles");
        foreach (var obstacleVar in activeObstacles)
        {
            Destroy(obstacleVar);
        }
        //DestroyObject(obstacle);
        //Object.Destroy(obstacle);
    }

    public void addObstacleToList(GameObject newObstacle)
    {
        activeObstacles.Add(newObstacle);
    }

    public void removeObstacleFromList()
    {
        activeObstacles.RemoveAt(0);
    }

    //public void onPlayerFall()
    //{
    //    PlayerPrefs.SetFloat("ElapsedTime", Time.realtimeSinceStartup);
    //    PlayerPrefs.SetInt("FinalPoints", scoreToInt);

    //    //Debug.Log("Tempo: " + PlayerPrefs.GetFloat("ElapsedTime"));
    //    //Debug.Log("Pontuação: " + PlayerPrefs.GetInt("FinalPoints"));

    //    //Debug.Log("Cheguei Aqui!");
    //    LoadGameData();
    //}

    //private void LoadGameData()
    //{
    //    string filePath = Path.Combine(Application.streamingAssetsPath, "TestDataJson.txt");

    //    //Debug.Log("Mas não Aqui!");

    //    if (File.Exists(filePath))
    //    {
    //        string dataAsJson = File.ReadAllText(filePath);

    //        loadGameData = JsonUtility.FromJson<PlayerData>(dataAsJson);

    //        Debug.Log("gameLoaded points: " + loadGameData.points);

    //        Debug.Log("gameLoaded time: " + loadGameData.timeElapsed);

    //    }
    //}
}
