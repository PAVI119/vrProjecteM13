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
    private SphereCollider sphereCollider;

    // Inicialización
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Mejor para objetos de alta velocidad.
        rb.useGravity = true;
        rb.mass = 0.62f; // Masa aproximada de una pelota de baloncesto
        rb.drag = 0.1f; // Drag bajo para simular el aire
        rb.angularDrag = 0.05f;
        // Aplicar una pequeña fuerza inicial si es necesario para simular un lanzamiento o un bote inicial
        
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
        rb.velocity = throwForce;
        rb.AddForce(throwForce, ForceMode.Impulse);
        // Aquí puedes usar rb.velocity para mantener la velocidad del controlador al soltar
    }
}
