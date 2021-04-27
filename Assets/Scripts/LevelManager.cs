using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnInterval = 1f;
    public float difficultyInterval = 5f;
    public float difficultyModifier = 0.01f;
    private float difficultyTimer = 0f;
    private float spawnTimer = 0f;
    private float spawnHeight = -2f;

    public delegate void PauseToggle();
    public static event PauseToggle PauseResume;

    // Start is called before the first frame update
    void Start()
    {
        spawnHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        HandlePause();
        UpdateDifficulty();
        HandleSpawn();
    }

    private void HandlePause()
    {
        bool pauseToggle = Input.GetKeyDown(KeyCode.Escape);
        if (pauseToggle)
        {
            PauseResume();
        }
    }

    public void OnClickResumeButton()
    {
        PauseResume();
    }

    private void UpdateDifficulty()
    {
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= difficultyInterval)
        {
            difficultyTimer = 0;
            spawnInterval -= difficultyModifier;
        }
    }

    private void HandleSpawn()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            float xVal = Random.Range(-1.4f, 1.4f);
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(xVal, spawnHeight, 0), Quaternion.identity);
            enemy.transform.parent = gameObject.transform.parent;
        }
    }
}
