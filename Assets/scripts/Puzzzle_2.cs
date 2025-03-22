using UnityEngine;
using TMPro; // Подключение библиотеки TextMeshPro
using UnityEngine.UI;

public class Puzzzle : MonoBehaviour
{
    // Ссылки на UI элементы
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public Button checkButton;
    public TextMeshProUGUI resultText;
    public GameObject panel; // Ссылка на панель на Canvas
    public BoxCollider boxCollider; // Ссылка на BoxCollider
            // Ссылки на TextMeshProUGUI для отображения двоичных значений
    public TextMeshPro binaryText1;
    public TextMeshPro binaryText2;
    public TextMeshPro binaryText3;

    // Переменные для случайных чисел и их двоичных значений
    private int numb1, numb2, numb3;
    private string dvoy1, dvoy2, dvoy3;

    void Start()
    {

        // Изначально панель отключена
       panel.SetActive(false);
        
        // Генерация случайных чисел
        numb1 = Random.Range(0, 10);
        numb2 = Random.Range(0, 10);
        numb3 = Random.Range(0, 10);

        // Перевод чисел в двоичный код
        dvoy1 = System.Convert.ToString(numb1, 2).PadLeft(4, '0');
        dvoy2 = System.Convert.ToString(numb2, 2).PadLeft(4, '0');
        dvoy3 = System.Convert.ToString(numb3, 2).PadLeft(4, '0');

        // Вывод в консоль для отладки
        Debug.Log($"Сгенерированы числа: {numb1} ({dvoy1}), {numb2} ({dvoy2}), {numb3} ({dvoy3})");

        // Привязка значений к TextMeshProUGUI для отображения
        binaryText1.text = dvoy1;
        binaryText2.text = dvoy2;
        binaryText3.text = dvoy3;
        // Подписываемся на событие нажатия кнопки
        checkButton.onClick.AddListener(CheckAnswers);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with " + other.gameObject.name);
        if (other.CompareTag("Player")) // Проверяем, что объект - игрок
        {
            Debug.Log("Триггер запустился");
            panel.SetActive(true); // Активируем панель
        }
    }

    void CheckAnswers()
    {
        // Проверяем введенные значения
        int input1 = int.TryParse(inputField1.text, out input1) ? input1 : -1;
        int input2 = int.TryParse(inputField2.text, out input2) ? input2 : -1;
        int input3 = int.TryParse(inputField3.text, out input3) ? input3 : -1;

        if (input1 == numb1 && input2 == numb2 && input3 == numb3)
        {
            resultText.text = "Поздравляем! Вы выиграли!";
            panel.SetActive(false); // Отключаем панель
            boxCollider.enabled = false; // Отключаем BoxCollider
        }
        else
        {
            resultText.text = "Неверно! Попробуйте ещё раз.";
        }
    }
}
