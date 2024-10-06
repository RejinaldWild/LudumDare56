using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame() // Метод вызывается при нажатии кнопки
    {
        
        Application.Quit(); // Закрытие игры при сборке


#if UNITY_EDITOR //для консоли
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}