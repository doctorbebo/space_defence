using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationController : MonoBehaviour
{
    private bool ShouldRotateLeft => (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) && !isFlipping;
    private bool ShouldRotateRight => (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) && !isFlipping;

    private bool ShouldFlipRight => Keyboard.current.eKey.wasPressedThisFrame && !isFlipping;
    private bool ShouldFlipLeft => Keyboard.current.qKey.wasPressedThisFrame && !isFlipping;

    public float rotationSpeed = 100f;
    public float flipSpeed = 150f;

    private bool isFlipping;
    private Quaternion flipDestination;

    private void Update()
    {
        if (ShouldRotateLeft)
        {
            Rotate(Vector3.up);
        }

        if (ShouldRotateRight)
        {
            Rotate(Vector3.down);
        }

        if (ShouldFlipLeft)
        {
            StartCoroutine(Flip(Vector3.forward));
        }

        if (ShouldFlipRight)
        {
            StartCoroutine(Flip(Vector3.back));
        }
    }

    private void Rotate(Vector3 direction)
    {
        transform.Rotate(direction * rotationSpeed * Time.deltaTime);
    }

    private IEnumerator Flip(Vector3 direction)
    {
        isFlipping = true;
        flipDestination = Quaternion.Euler(transform.rotation.eulerAngles + direction * 180f);
        
        // Rotate slightly in the desired direction so that the RotateTowards() will pick the correct direction. 
        transform.Rotate(direction * Time.deltaTime * 0.01f);
        
        while (Quaternion.Angle(flipDestination, transform.rotation) > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, flipDestination, flipSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = flipDestination;
        isFlipping = false;
    }
}
