//Alexander Calambas - 2190555
//Juan Manuel Santos - 2215928
//Juan David Rios - 2225674

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase RojoMoviento:
/// Controla el movimiento y las acciones del personaje "Rojo". Permite mover el personaje de lado a lado,
/// saltar, gestionar su orientación, y reproducir animaciones basadas en su estado actual.
/// </summary>
public class RojoMoviento : MonoBehaviour
{
    // Variables privadas y públicas
    private Rigidbody2D rigB2D; // Controlador del cuerpo rígido del personaje para aplicar física
    private float Horizontal; // Dirección horizontal del movimiento
    public float fuerza; // Fuerza aplicada para los saltos
    public float velocidadMovimiento; // Velocidad a la que se mueve el personaje
    private CircleCollider2D CirCo2D; // Collider del personaje para detectar el suelo
    public LayerMask capaSuelo; // Máscara para identificar el suelo
    public float saltosMaximos; // Máximo número de saltos permitidos
    private float saltosRestantes; // Saltos que quedan disponibles
    private bool mirandoDerecha = true; // Indica si el personaje está mirando a la derecha
    private Animator animator; // Referencia al componente Animator para manejar animaciones

    /// <summary>
    /// Método Start:
    /// Inicializa las variables principales del script, como el cuerpo rígido, el collider, los saltos restantes
    /// y el componente Animator para manejar las animaciones.
    /// </summary>
    void Start()
    {
        rigB2D = GetComponent<Rigidbody2D>();
        CirCo2D = GetComponent<CircleCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Método EstaEnElSuelo:
    /// Verifica si el personaje está en contacto con el suelo utilizando un BoxCast en el collider.
    /// Retorna un valor booleano que indica si el personaje está en el suelo o no.
    /// </summary>
    /// <returns>True si está en el suelo, False si no lo está.</returns>
    bool EstaEnElSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(CirCo2D.bounds.center, new Vector2(CirCo2D.bounds.size.x, CirCo2D.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    /// <summary>
    /// Método Update:
    /// Se llama una vez por frame. Maneja la lógica de los saltos y actualiza el estado de la animación
    /// del personaje, como el salto y su posición en el suelo.
    /// </summary>
    void Update()
    {
        // Restablecer el número de saltos si el personaje está en el suelo
        if (EstaEnElSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        // Saltar si se presiona la tecla de espacio y quedan saltos disponibles
        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes = saltosRestantes - 1;
            rigB2D.velocity = new Vector2(rigB2D.velocity.x, 0f); // Reinicia la velocidad vertical
            rigB2D.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse); // Añade fuerza para el salto
        }

        // Actualiza la animación de salto basado en si el personaje está en el suelo o no
        animator.SetBool("isJump", EstaEnElSuelo());
    }

    /// <summary>
    /// Método FixedUpdate:
    /// Se llama en intervalos fijos de tiempo. Maneja el movimiento horizontal del personaje y la reproducción
    /// de la animación de correr según la entrada del jugador.
    /// </summary>
    public void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); // Obtener la dirección de movimiento

        // Actualizar la animación de correr
        if (Horizontal != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Aplicar el movimiento horizontal al personaje
        rigB2D.velocity = new Vector2(Horizontal * velocidadMovimiento, rigB2D.velocity.y);

        // Gestionar la orientación del personaje
        GestionarOrientacion(Horizontal);
    }

    /// <summary>
    /// Método GestionarOrientacion:
    /// Controla la orientación del personaje dependiendo de la dirección del movimiento.
    /// Si el personaje está mirando en una dirección y se mueve en la opuesta, se invierte su escala horizontal.
    /// </summary>
    /// <param name="Horizontal">La dirección del movimiento horizontal (positiva o negativa).</param>
    void GestionarOrientacion(float Horizontal)
    {
        if ((mirandoDerecha == true && Horizontal < 0) || (mirandoDerecha == false && Horizontal > 0))
        {
            // Invertir la dirección del personaje
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
