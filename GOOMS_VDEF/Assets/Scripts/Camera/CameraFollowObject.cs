using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] GameObject _PlayerRef;

    float _flipYRotationTime = 0.5f;
    bool _isFacingRight;

    private void Awake()
    {
        _isFacingRight = _PlayerRef.GetComponent<Player_Movement>().isFacingRight;
    }

    private void Update()
    {
        transform.position = _PlayerRef.transform.position;
        
    }

    public void CallTurn()
    {
        StartCoroutine(FlipYLerp());
    }

    IEnumerator FlipYLerp()
    {
        float startRotation = transform.localEulerAngles.y;
        float endRotationAmount = DetermineEndRotation ();
        float yRotation = 0f;

        float elapsedTime = 0f;

        while (elapsedTime < _flipYRotationTime)
        {
            elapsedTime += Time.deltaTime;

            //lerp rotation
            yRotation = Mathf.Lerp(startRotation, endRotationAmount, (elapsedTime / _flipYRotationTime) );
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

            yield return null;
        }
    }

    float DetermineEndRotation()
    {
        _isFacingRight = !_isFacingRight;

        return _isFacingRight ? 0f : 180f;
    }

    
}
