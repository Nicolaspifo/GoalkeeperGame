using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Giroscopio = UnityEngine.InputSystem.Gyroscope;
public class PlayerMove : MonoBehaviour
{
    public TMP_Text textGiroscopio;
    public TMP_Text textAcelerometro;
    
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

    private void Update()
    {   
        if (Accelerometer.current == null) return; // evita el crash si no hay sensor

        GameObject Player = GameObject.FindWithTag("Player");

        if (Accelerometer.current != null)
        {
            MovimientoAcelerometro(Player);
        }
        else
        {
            MovimientoGiroscopio(Player);
        }

        
    }

    private void MovimientoAcelerometro(GameObject Player)
    {
        Vector3 accel = Accelerometer.current.acceleration.ReadValue();
        textAcelerometro.text = $"Acelerómetro: {accel}";

        if (Player.transform.position.x <= 21 && Player.transform.position.x >= -21)
        {
            Player.transform.position = new Vector3(Player.transform.position.x + accel.x, Player.transform.position.y, Player.transform.position.z);
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

    private void MovimientoGiroscopio(GameObject Player)
    {
        Vector3 gyro = Giroscopio.current.angularVelocity.ReadValue();
        textGiroscopio.text = $"Giroscopio: {gyro}";

        if (Player.transform.position.x <= 21 && Player.transform.position.x >= -21)
        {
            Player.transform.position = new Vector3(Player.transform.position.x + gyro.x, Player.transform.position.y, Player.transform.position.z);
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