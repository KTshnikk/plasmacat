using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    public Transform targetObject; // Объект, который будет двигаться
    public float radius; // Радиус окружности
    public float speed; // Скорость движения
    public bool clockwise = true; // Направление движения

    [Header("Начальная позиция")]
    public float initialAngle = 0f; // Начальный угол в градусах

    private float currentAngle; // Текущий угол в радианах
    public float initialY; // Начальная позиция по оси Y

    void Start()
    {
        // Перевод начального угла из градусов в радианы
        currentAngle = initialAngle * Mathf.Deg2Rad;

        // Сохраняем начальную позицию по оси Y
        if (targetObject != null)
        {
            initialY = targetObject.position.y;
            UpdateTargetPosition();
        }
    }

    void Update()
    {
        if (targetObject == null)
            return;

        // Расчёт смещения угла в зависимости от скорости и направления
        float angleDelta = speed * Time.deltaTime * (clockwise ? -1 : 1);

        // Обновляем текущий угол
        currentAngle += angleDelta;

        // Перемещаем объект на окружности
        UpdateTargetPosition();
    }

    // Метод для обновления позиции объекта
    private void UpdateTargetPosition()
    {
        float x = Mathf.Cos(currentAngle) * radius;
        float y = Mathf.Sin(currentAngle) * radius + initialY;

        targetObject.position = new Vector3(x, y, targetObject.position.z);
    }

    // Вызывается из редактора для обновления параметров в реальном времени
    private void OnValidate()
    {
        if (targetObject != null)
        {
            UpdateTargetPosition();
        }
    }
}