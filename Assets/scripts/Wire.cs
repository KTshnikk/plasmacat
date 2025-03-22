using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject WireBaseOn;
    public Vector3 StartPoint;
    public Vector3 StartPosition;
    public float mzCoord;

    public Vector3 newPosition; 
    public float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius =  2.5f;
        StartPoint = transform.parent.position;
        StartPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        //Отлов позиции мыши в игровом пространстве
        mzCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; // z координата курсора относительно мира;
        newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 1.86f;

        //Присоединение к другим точкам
        Collider[] colliders = Physics.OverlapSphere(newPosition, radius);
        foreach (Collider collider in colliders)
        {
            //проверка, что подконтрольный провод не является целью коннекта
            if (collider.gameObject != gameObject)
            {
                //соединение проводов
                UpdateWire(collider.transform.position);

                //проверка соединения проводов одинакового цвета
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    // финальный шаг
                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                return;
            }

        }

        // update wire
        //UpdateWire(newPosition);

    }
    void Done()
    {
        //Включение света
        WireBaseOn.SetActive(true);

        //Отключение скрипта
        Destroy(this);
    }
    private void OnMouseUp()
    {
        // reset wire position
        UpdateWire(StartPosition);
    }
    void UpdateWire(Vector3 newPosition)
    {
        // update position
        transform.position = newPosition;

        // update direction
        Vector3 direction = newPosition - StartPoint;
        transform.right = direction * transform.lossyScale.x;

        // update scale
        float dist = Vector2.Distance(StartPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}
