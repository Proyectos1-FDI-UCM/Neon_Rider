using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Componente pensado para ser añadido al jugador para gestionar
/// sus power-up's.
/// </summary>
/// Cada power-up es implementado con un componente distinto.
/// Un power-up estará habilitado si su componente está activado.
/// Por lo tanto todos los componentes que implementan power-up's
/// estarán deshabilitados desde el principio.
/// Este componente (en el jugador) añade un método ActivatePowerUp(string)
/// que recibe el nombre del power-up a activar (debe coincidir con
/// el nombre del componente) y lo activa. Si había un power-up previo
/// activo, lo desactiva.
public class PowerUpManager : MonoBehaviour
{

    MonoBehaviour currentPowerUp;
    string lastPowerUpName;
    float timeDuration = -1;
    [SerializeField] float duration = 5f;
    PowerUpRed red;
    PowerUpBlue blue;
    PowerUpGreen green;
    PowerUpPurple purple;
    PowerUpYellow yellow;

    public Image image;
    [SerializeField] Sprite redIndicator = null;
    [SerializeField] Sprite blueIndicator = null;
    [SerializeField] Sprite greenIndicator = null;
    [SerializeField] Sprite purpleIndicator = null;
    [SerializeField] Sprite yellowIndicator = null;

    ActivatePowerUpPurple activPowPurple;

    float width, originalWidth, time;
    bool activo = false;

    void Awake()
    {
        width = image.rectTransform.sizeDelta.x;
        originalWidth = width;
        // Cogemos los scripts de los Powerups
        red = GetComponent<PowerUpRed>();
        blue = GetComponent<PowerUpBlue>();
        green = GetComponent<PowerUpGreen>();
        purple = GetComponent<PowerUpPurple>();
        yellow = GetComponent<PowerUpYellow>();
        activPowPurple = GetComponent<ActivatePowerUpPurple>();
    }

    void Update()
    {
        if (red.enabled && !activo)
        {
            width = originalWidth;
            image.sprite = redIndicator;
            image.enabled = true;            
            activo = true;
            time = Time.time + duration;
        }
        else if (blue.enabled && !activo)
        {
            width = originalWidth;
            image.sprite = blueIndicator;
            image.enabled = true;
            activo = true;
            //time = Time.time + duration;
        }
        else if (green.enabled && !activo)
        {
            width = originalWidth;
            image.sprite = greenIndicator;
            image.enabled = true;
            activo = true;
            time = Time.time + duration;
        }
        else if (yellow.enabled && !activo)
        {
            width = originalWidth;
            image.sprite = yellowIndicator;
            image.enabled = true;           
            activo = true;
            time = Time.time + duration;
            Debug.Log("hola");
        }
        else if (purple.enabled && !activo)
        {
            width = originalWidth;
            image.sprite = purpleIndicator;
            image.enabled = true;
            activo = true;
            time = Time.time + duration;
        }
        //si el tamaño de la barra es 0 desactiva la imagen de la barra y pone cont a 0 
        if (width <= 0)
        {
            activo = false;
            image.enabled = false;
            if (red.enabled)
            {
                DeactivatePowerUp("PowerUpRed");
            }
            else if (blue.enabled)
            {
                DeactivatePowerUp("PowerUpBlue");
            }
            else if (green.enabled)
            {
                DeactivatePowerUp("PowerUpGreen");
            }
            else if (purple.enabled)
            {
                DeactivatePowerUp("PowerUpPurple");
                activPowPurple.enabled = true;
            }
            else if (yellow.enabled)
            {
                DeactivatePowerUp("PowerUpYellow");
            }
        }
        // si el tamaño no es 0 disminuñe el tamaño de la barra a la velocidad correspondiente de cada power up
        else
        {
            image.rectTransform.sizeDelta = new Vector2(width, image.rectTransform.sizeDelta.y);
            if (currentPowerUp == null)
            {
                width = 0;
            }
            else
            {
                if (blue.enabled)
                {
                    width = (originalWidth * ((time - Time.time) / (duration / 3)));
                    Debug.Log("Me cago en tus muertos");
                }
                else
                    width = originalWidth * ((time - Time.time) / duration);
            }               
        }
        //estos 4 ifs dependiendo del power up ponen un sprite distinto  a la barra, activan la imagen y ponen su tamaño al máximo.
        //el contador evita que entre más de una vez seguidas al mismo if, porque entondes la barra estaria todo el rato a tope.        
    }

    public void ActivatePowerUp(string powerUpName)
    {

        // Localiza el componente powerUpName asociado 
        MonoBehaviour powerUp = GetComponent(powerUpName) as MonoBehaviour;

        if (powerUp == null)
        {
            Debug.Log("Componente power-up " + powerUpName + " no encontrado. Se ignora.");

        }
        else
        {
            // Si no está activo
            if (powerUp != currentPowerUp)
            {
                // Desactiva el power-up activo y su indicador
                if (currentPowerUp != null)
                {
                    Debug.Log("Desactivo");
                    currentPowerUp.enabled = false;
                    image.enabled = false;
                    activo = false;
                }

                // Activa el power-up indicado
                powerUp.enabled = true;
                Debug.Log("Componente power-up " + powerUpName + " activado.");

                currentPowerUp = powerUp;
                //lastPowerUpName = powerUpName;

                // Activa el indicador del Powerup
                if(image != null)
                    image.enabled = true;

                // Añade a timeDuratión la duración del Powerup
                if (powerUpName == "PowerUpBlue")
                {
                    time = duration / 3 + Time.time;
                    Debug.Log("Azuuuuuuuuuul1");
                }
                else
                    time = duration + Time.time;
            }
            else
            {
                if (powerUpName=="PowerUpBlue")
                {
                    time = duration/3 + Time.time;
                    Debug.Log("Azuuuuuuuuuul2");
                }                    
                else 
                    time = duration + Time.time;
            }                
        }
    }

    void DeactivatePowerUp(string powerUpName)
    {

        // Localiza el componente powerUpName asociado 
        MonoBehaviour powerUp = GetComponent(powerUpName) as MonoBehaviour;

        if (powerUp == null)
        {
            Debug.Log("Componente power-up " + powerUpName + " no encontrado. Se ignora.");
        }
        else
        {
            if (currentPowerUp != null)     // Desactiva el power-up activo
            {
                currentPowerUp.enabled = false;              
            }
            activo = false;
            currentPowerUp = null;
            Debug.Log("Componente power-up " + powerUpName + " Desactivado.");
        }
    }

    //lo llama desdel powerup manager para apagar lo PU activos.
    public void Reset()
    {
        timeDuration = Time.time;
    }
}