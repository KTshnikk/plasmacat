using UnityEngine;

public class DROPDOWN : MonoBehaviour
{
    public GameObject downmin;
    public GameObject player;
    public GameObject downhour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "floorFORQUEST")
        {
            downmin.SetActive(true);
            downhour.SetActive(true);
        }

    }
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "floorFORQUEST")
        {
            downmin.SetActive(false);
            downhour.SetActive(false);
        }
    }
}
