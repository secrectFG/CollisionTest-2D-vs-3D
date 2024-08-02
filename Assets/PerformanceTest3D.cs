using UnityEngine;
using UnityEngine.UI;

public class PerformanceTest3D : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spacing = 1.5f; // 间距

    public int totalObjects = 3000;

    //是否模拟2D
    public bool simulate2D = false;

    void Start()
    {
        int totalObjects = 0;
        if (GameManager.Instance == null)
        {
            totalObjects = this.totalObjects;
        }
        else
        {
            totalObjects = GameManager.Instance.testNumber;
        }


        
        int createdObjects = 0;
        if (simulate2D)
        {
            int objectsPerRow = Mathf.CeilToInt(Mathf.Sqrt(totalObjects)); // 每行对象数量
            var rb = objectPrefab.GetComponent<Rigidbody>();
            //冻结x,y轴旋转
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;


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
        }
        else
        {
            int objectsPerRow = Mathf.CeilToInt(Mathf.Pow(totalObjects, 1.0f / 3.0f)); // 每行对象数量
            for (int i = 0; i < objectsPerRow; i++)
            {
                for (int j = 0; j < objectsPerRow; j++)
                {
                    for (int k = 0; k < objectsPerRow; k++)
                    {
                        if (createdObjects >= totalObjects)
                        {
                            GameObject.Find("number").GetComponent<Text>().text = "Created " + createdObjects + " objects";
                            return;
                        }

                        Vector3 position = new Vector3(i * spacing + Random.Range(0.02f, 0.09f), j * spacing, k * spacing);
                        var go = Instantiate(objectPrefab, objectPrefab.transform.position + position, Quaternion.identity);
                        go.SetActive(true);
                        // go.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
                        go.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
                        createdObjects++;
                    }
                }
            }
        }



        GameObject.Find("number").GetComponent<Text>().text = "Created " + createdObjects + " objects";


    }
}
