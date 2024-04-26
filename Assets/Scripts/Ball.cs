using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;
    private Transform controllerTransform; // Se guarda la referencia al transform del controlador

    // Inicialización
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Mejor para objetos de alta velocidad.
    }

    void Update()
    {
        // Si la pelota está siendo sostenida, se actualiza su posición para que siga al controlador
        if (isHeld && controllerTransform != null)
        {
            transform.position = controllerTransform.position;
        }
    }

    public void GrabBall(Transform controller)
    {
        // Llamar cuando el objeto es agarrado por el controlador derecho.
        isHeld = true;
        rb.isKinematic = true;
        controllerTransform = controller; // Guarda la referencia al controlador
        transform.SetParent(controller);
        transform.localPosition = Vector3.zero;
    }

    public void ReleaseBall(Vector3 throwForce)
    {
        // Llamar cuando el objeto es soltado por el controlador derecho.
        transform.SetParent(null);
        isHeld = false;
        rb.isKinematic = false;
        rb.velocity = throwForce; // Aquí puedes usar rb.velocity para mantener la velocidad del controlador al soltar
    }
}
