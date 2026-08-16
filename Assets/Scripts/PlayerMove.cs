using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Giroscopio = UnityEngine.InputSystem.Gyroscope;
public class PlayerMove : MonoBehaviour
{
    public TMP_Text textGiroscopio;
    public TMP_Text textAcelerometro;

    private GameObject Player;

    private float velocidad = 100f;



    Animator anim;
    
    private void OnEnable()
    {
        if (Giroscopio.current != null)
            InputSystem.EnableDevice(Giroscopio.current);
        else
            Debug.LogWarning("No se encontró Giroscopio en este dispositivo.");
        if (Accelerometer.current != null)
            InputSystem.EnableDevice(Accelerometer.current);
        else
            Debug.LogWarning("No se encontró Accelerometer en este dispositivo.");

        
    }

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {   
        if (Accelerometer.current == null) return; // evita el crash si no hay sensor

        

        if (Accelerometer.current != null)
        {
            MovimientoAcelerometro();
        }
        else
        {
            MovimientoGiroscopio();
        }

        
    }

    private void MovimientoAcelerometro()
    {
        Vector3 accel = Accelerometer.current.acceleration.ReadValue();
        textAcelerometro.text = $"Acelerómetro: {accel}";

        //Control de acelerometro para animacion
        if (accel.x >= -0.1f && accel.x <= 0.1f) anim.SetBool("semueve", false);
        else anim.SetBool("semueve", true);

        if (Player.transform.position.x <= 21 && Player.transform.position.x >= -21)
        {
            Player.transform.position = new Vector3(Player.transform.position.x + accel.x * velocidad * Time.deltaTime, 
                Player.transform.position.y, Player.transform.position.z);
        }
        else if (Player.transform.position.x > 21)
        {
            Player.transform.position = new Vector3(21, Player.transform.position.y, Player.transform.position.z);

        }
        else if (Player.transform.position.x < -21)
        {
            Player.transform.position = new Vector3(-21, Player.transform.position.y, Player.transform.position.z);

        }

        
    }

    private void MovimientoGiroscopio()
    {
        Vector3 gyro = Giroscopio.current.angularVelocity.ReadValue();
        textGiroscopio.text = $"Giroscopio: {gyro}";

        if (Player.transform.position.x <= 21 && Player.transform.position.x >= -21)
        {
            Player.transform.position = new Vector3(Player.transform.position.x + gyro.x * velocidad * Time.deltaTime, 
                Player.transform.position.y, Player.transform.position.z);
        }
        else if (Player.transform.position.x > 21)
        {
            Player.transform.position = new Vector3(21, Player.transform.position.y, Player.transform.position.z);

        }
        else if (Player.transform.position.x < -21)
        {
            Player.transform.position = new Vector3(-21, Player.transform.position.y, Player.transform.position.z);

        }
    }

    private void MovimientoAcelSaltar()
    {
        Vector3 accel = Accelerometer.current.acceleration.ReadValue();
        textAcelerometro.text = $"Acelerómetro: {accel}";
        //Control de acelerometro para animacion
        if (accel.x >= -0.1f && accel.x <= 0.1f) anim.SetBool("semueve", false);
        else anim.SetBool("semueve", true);
        if (accel.y >= 0.5f)
        {
            anim.SetBool("salta", true);
        }
        else
        {
            anim.SetBool("salta", false);
        }
        if (Player.transform.position.x <= 21 && Player.transform.position.x >= -21)
        {
            Player.transform.position = new Vector3(Player.transform.position.x + accel.x * velocidad * Time.deltaTime,
                Player.transform.position.y, Player.transform.position.z);
        }
        else if (Player.transform.position.x > 21)
        {
            Player.transform.position = new Vector3(21, Player.transform.position.y, Player.transform.position.z);
        }
        else if (Player.transform.position.x < -21)
        {
            Player.transform.position = new Vector3(-21, Player.transform.position.y, Player.transform.position.z);
        }
    }

}