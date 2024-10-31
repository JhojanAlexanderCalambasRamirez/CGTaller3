//Alexander Calambas - 2190555
//Juan Manuel Santos - 2215928
//Juan David Rios - 2225674

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;  // Singleton

    public TextMeshProUGUI scoreText;   // Referencia al texto de puntaje
    public TextMeshProUGUI itemsText;   // Referencia al texto de objetos

    public int score { get; private set; } = 0;  // Puntaje del jugador
    public int items { get; private set; } = 0;  // Cantidad de �tems

    void Awake()
    {
        // Implementar Singleton para asegurarse de que solo haya un GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Hacer que el GameManager persista entre escenas
        }
        else
        {
            Destroy(gameObject);  // Destruir duplicados
        }
    }

    // M�todo para agregar puntos
    public void AddPoints(int points)
    {
        score += points;
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score;
        }
        else
        {
            Debug.LogError("scoreText no est� asignado.");
        }
    }

    // M�todo para agregar �tems
    public void AddItem(int itemCount)
    {
        items += itemCount;
        if (itemsText != null)
        {
            itemsText.text = "Objetos: " + items;
        }
        else
        {
            Debug.LogError("itemsText no est� asignado.");
        }
    }

    // M�todo para guardar el progreso en PlayerPrefs
    public void SaveProgress()
    {
        // Guardar el puntaje total acumulado
        PlayerPrefs.SetInt("totalPoints", score);  // Guardar el puntaje actual
        PlayerPrefs.SetInt("totalItems", items);   // Guardar el total de �tems actuales
        PlayerPrefs.Save();

        // Para depurar: ver el guardado de datos
        Debug.Log("Progreso guardado: Puntos Totales = " + PlayerPrefs.GetInt("totalPoints", 0));
        Debug.Log("Progreso guardado: �tems Totales = " + PlayerPrefs.GetInt("totalItems", 0));
    }

    // M�todo para cargar el progreso en Escena2
    public void LoadProgress()
    {
        score = PlayerPrefs.GetInt("totalPoints", 0);  // Cargar los puntos guardados
        items = PlayerPrefs.GetInt("totalItems", 0);   // Cargar los �tems guardados

        // Actualizar los textos en pantalla
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score;
        }
        if (itemsText != null)
        {
            itemsText.text = "Objetos: " + items;
        }

        // Para depurar: ver los datos cargados
        Debug.Log("Progreso cargado: Puntos = " + score);
        Debug.Log("Progreso cargado: �tems = " + items);
    }

    // Ejemplo de cambio de escena que llama a SaveProgress
    public void CambiarEscena(string escenaNombre)
    {
        SaveProgress();  // Guardar el progreso antes de cambiar de escena
        SceneManager.LoadScene(escenaNombre);  // Cambiar de escena
    }

    // M�todo que se ejecuta al cargar una nueva escena
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // M�todo que se llama cuando se carga una nueva escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si estamos en la escena 2, cargar los datos guardados
        if (scene.name == "Escena2")
        {
            LoadProgress();
        }
    }
}
