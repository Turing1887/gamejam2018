using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject randomPrefab;
    public GameObject startPrefab;
    public GameObject questionPrefab;
    public GameObject eventPrefab;
    public GameObject bubble;
	public GameObject[] playerPrefabs;
    public Text countdown;
    public Text p1;
    public Text p2;
    public Text p3;
    public Text p4;

    public float offset = 16f;
    public string[] roomTypes;
    public float duration = 8f;
    public float timer = 10f;

    private Vector3 spawnPos = new Vector3(0f, 0f, 0f);
    private int counter = 1;

	public string[] tubes;

    // Raumwechsel
    // Raumbuilding

    private void Start()
    {
        buildNewRoom(true);
        GameObject player1 = GameObject.FindGameObjectWithTag("Player_1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player_2");
        GameObject player3 = GameObject.FindGameObjectWithTag("Player_3");
        GameObject player4 = GameObject.FindGameObjectWithTag("Player_4");
        if (player1 == null)
        {
            p1.text = "";
        }
        if (player2 == null)
        {
            p2.text = "";
        }
        if (player3 == null)
        {
            p3.text = "";
        }
        if (player4 == null)
        {
            p4.text = "";
        }
    }

    // Use this for initialization
    void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            CancelInvoke();
            // Camera Lerp
            CameraMovement camMov = cam.GetComponent<CameraMovement>();
            camMov.enableCam();
            killPlayer();
        }
        else
        {
            countdown.text = (Mathf.Round(timer)).ToString();
        }
        
	}

    void killPlayer()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player_1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player_2");
        GameObject player3 = GameObject.FindGameObjectWithTag("Player_3");
        GameObject player4 = GameObject.FindGameObjectWithTag("Player_4");
        if (player1 != null)
        {
            player1.SetActive(false);
            string oldText = p1.text;
            int oldLife;
            int.TryParse(oldText, out oldLife);
            oldLife--;
            p1.text = oldLife.ToString();
        }
        if (player2 != null)
        {
            player2.SetActive(false);
            string oldText = p2.text;
            int oldLife;
            int.TryParse(oldText, out oldLife);
            oldLife--;
            p2.text = oldLife.ToString();
        }
        if (player3 != null)
        {
            player3.SetActive(false);
            string oldText = p3.text;
            int oldLife;
            int.TryParse(oldText, out oldLife);
            oldLife--;
            p3.text = oldLife.ToString();
        }
        if (player4 != null)
        {
            player4.SetActive(false);
            string oldText = p4.text;
            int oldLife;
            int.TryParse(oldText, out oldLife);
            oldLife--;
            p4.text = oldLife.ToString();
        }
    }

    void getRoomType()
    {
        int randomNum = Random.Range(0, roomTypes.Length);
        buildRoomInterior(randomNum);
    }

    void buildRoomInterior(int roomNum)
    {
        GameObject newRoom = GameObject.Find("newRoom");
        if (newRoom != null)
        {
            GameObject olderRoom = GameObject.Find("oldRoom");
            if (olderRoom != null)
            {
                olderRoom.name = "olderRoom";
                Destroy(olderRoom, 3f);
            }
            GameObject oldRoom = GameObject.Find("newRoom");
            oldRoom.name = "oldRoom";
        }
        switch (roomNum)
        {
            //Random
            case 0:
                Vector3 prefabPos0 = randomPrefab.transform.position;
                float newHeight0 = prefabPos0.y + offset * counter;
                GameObject ranRoom = Instantiate(randomPrefab, new Vector3(prefabPos0.x, newHeight0, prefabPos0.z), Quaternion.identity);
                ranRoom.name = "newRoom";
                randomizeDif();
                break;
            // Event
            case 1:
                Vector3 prefabPos1 = eventPrefab.transform.position;
                float newHeight1 = prefabPos1.y + offset * counter;
                GameObject eventRoom = Instantiate(eventPrefab, new Vector3(prefabPos1.x, newHeight1, prefabPos1.z), Quaternion.identity);
                eventRoom.name = "newRoom";
                break;
            // Question
            case 2:
                Vector3 prefabPos2 = eventPrefab.transform.position;
                float newHeight2 = prefabPos2.y + offset * counter;
                GameObject questionRoom = Instantiate(questionPrefab, new Vector3(prefabPos2.x, newHeight2, prefabPos2.z), Quaternion.identity);
                questionRoom.name = "newRoom";
                break;
        }
    }

    void randomizeDif()
    {
        int dif1 = Random.Range(0, 10);
        int dif2 = Random.Range(0, 10);
        int dif3 = Random.Range(0, 10);
        int dif4 = Random.Range(0, 10);

        StartCoroutine(waitForSpawn(dif1, dif2, dif3, dif4));
    }

    IEnumerator waitForSpawn(int dif1, int dif2, int dif3, int dif4)
    {
        yield return new WaitForSeconds(10f);
        InvokeRepeating("spawnBubble1", 1f, Random.Range(5f, 6.5f) / dif1);
        InvokeRepeating("spawnBubble2", 1f, Random.Range(5f, 6.5f) / dif2);
        InvokeRepeating("spawnBubble3", 1f, Random.Range(5f, 6.5f) / dif3);
        InvokeRepeating("spawnBubble4", 1f, Random.Range(5f, 6.5f) / dif4);
    }

    void spawnBubble1()
    {
        GameObject oldRoom = GameObject.Find("oldRoom");
        float y = oldRoom.transform.GetChild(1).GetChild(1).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(-8.75f, -5.75f), y + 2f, 0f), Quaternion.identity);
        Destroy(bub, 3f);
    }
    void spawnBubble2()
    {
        GameObject oldRoom = GameObject.Find("oldRoom");
        float y = oldRoom.transform.GetChild(1).GetChild(1).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(-4.25f, -0.75f), y + 2f, 0f), Quaternion.identity);
        Destroy(bub, 3f);
    }
    void spawnBubble3()
    {
        GameObject oldRoom = GameObject.Find("oldRoom");
        float y = oldRoom.transform.GetChild(1).GetChild(1).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(0.75f, 4.25f), y + 2f, 0f), Quaternion.identity);
        Destroy(bub, 3f);
    }
    void spawnBubble4()
    {
        GameObject oldRoom = GameObject.Find("oldRoom");
        float y = oldRoom.transform.GetChild(1).GetChild(1).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(5.75f, 8.75f), y + 2f, 0f), Quaternion.identity);
        Destroy(bub, 3f);
    }

    void changeSzene()
    {

    }
	void SpawnPlayer(){
		
	}
    public void buildNewRoom(bool startRoom = false)
    {
        counter--;
        if (startRoom)
        {
            Instantiate(startPrefab);
            buildNewRoom();
        }
        else
        {
            getRoomType();
        }
        

    }
}
