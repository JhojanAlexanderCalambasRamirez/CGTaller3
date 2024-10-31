using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Importar TextMeshPro
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectName : MonoBehaviour
{
    public TMP_InputField inputText;  // Cambiado a TMP_InputField
    public TMP_Text textoNombre;  // Cambiado a TMP_Text
    public Image confirmacion;
    public GameObject botonAceptar;
    public GameObject botonJugar;  // A�adir el bot�n de "Jugar"

    private void Awake()
    {
        // Inicializar el campo de texto vac�o al inicio
        inputText.text = "";
        confirmacion.color = Color.red;
        botonAceptar.SetActive(false);

        // Deshabilitar el bot�n "Jugar" al inicio
        botonJugar.SetActive(false);

        // Si existe un nombre en PlayerPrefs, se guarda pero no se muestra en el campo
        if (PlayerPrefs.HasKey("nombre1"))  // Usamos "nombre1"
        {
            string nombreGuardado = PlayerPrefs.GetString("nombre1");
            textoNombre.text = nombreGuardado;
        }
        else
        {
            textoNombre.text = "";  // Asegurarse de que est� vac�o
        }
    }

    void Update()
    {
        // Validar la longitud del nombre mientras el usuario escribe
        if (inputText.text.Length < 5)
        {
            confirmacion.color = Color.red;
            botonAceptar.SetActive(false);
        }
        else
        {
            confirmacion.color = Color.green;
            botonAceptar.SetActive(true);
        }
    }

    // M�todo para aceptar el nombre
    public void aceptar()
    {
        string nombreIngresado = inputText.text;

        // Guardar el nombre ingresado en PlayerPrefs
        PlayerPrefs.SetString("nombre1", nombreIngresado);  // Guardamos con la clave "nombre1"

        // Mostrar el nombre aceptado en textoNombre
        textoNombre.text = nombreIngresado;

        // Habilitar el bot�n de "Jugar" al aceptar
        botonJugar.SetActive(true);
    }

    // M�todo para ir a la escena de juego
    public void jugar()
    {
        // Cambiar de escena a la de juego
        SceneManager.LoadScene("SampleScene");
    }
}
