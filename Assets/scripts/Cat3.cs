using UnityEngine;

public class Cat3: MonoBehaviour
   {
       public float jumpForce = 5f; // Сила прыжка
       private Rigidbody rb; // Ссылка на компонент Rigidbody
       private bool isGrounded; // Проверка на земле

       void Start()
       {
           rb = GetComponent<Rigidbody>();
       }
   
       void Update()
       {
           // Проверяем, нажата ли пробел
           if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
           {
               Jump();
           }
       }

       void Jump()
       {
           rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Применяем силу вверх
           isGrounded = false; // Устанавливаем, что игрок не на земле
       }

       private void OnCollisionEnter(Collision other)
       {
           // Проверка, коснулся ли игрок земли
           if (other.gameObject.CompareTag("Ground"))
           {
               isGrounded = true; // Игрок снова на земле
           }
       }
   }