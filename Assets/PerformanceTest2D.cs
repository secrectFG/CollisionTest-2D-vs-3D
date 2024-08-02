using UnityEngine;
using UnityEngine.UI;

public class PerformanceTest2D : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spacing = 1.5f; // 间距
    public int totalObjects = 3000;

    void Start()
    {
        int totalObjects = 0;
        if(GameManager.Instance == null){
            totalObjects = this.totalObjects;
        }else{
            totalObjects = GameManager.Instance.testNumber;
        }
        int objectsPerRow = Mathf.CeilToInt(Mathf.Sqrt(totalObjects)); // 每行对象数量
        int createdObjects = 0;

        for (int i = 0; i < objectsPerRow; i++)
        {
            for (int j = 0; j < objectsPerRow; j++)
            {
                if (createdObjects >= totalObjects)
                {
                    GameObject.Find("number").GetComponent<Text>().text = "Created " + createdObjects + " objects";
                    return;
                }


                Vector3 position = new Vector2(i * spacing + Random.Range(0.01f, 0.03f), j * spacing);
                var go = Instantiate(objectPrefab, objectPrefab.transform.position + position, Quaternion.identity);
                go.SetActive(true);
                go.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
                createdObjects++;
            }
        }
        GameObject.Find("number").GetComponent<Text>().text = "Created " + createdObjects + " objects";


    }
}
