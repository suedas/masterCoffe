using UnityEngine;
using DG.Tweening;
using System.Collections;

public class SwerveMovement : MonoBehaviour
{ //[SerializeField] private float swerveSpeed = .5f;
    //[SerializeField] private float maxSwerveAmount = 2;
    //[SerializeField] private float maxHorizontalDistance = 2;
    public Transform coffe;
    public Transform rightParent, leftParent;

    private float deltaPos;
    private float lastMousePosX;
    public Sequence seq;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition.x - lastMousePosX;
            lastMousePosX = Input.mousePosition.x;
            if (deltaPos < 0)
            {
                lastMousePosX = Input.mousePosition.x;
                seq = DOTween.Sequence();

                if (coffe.transform.CompareTag("sag"))
                {
                    coffe.transform.tag = "sol";
                    coffe.transform.DOKill();
                    seq.Kill();
                    coffe.SetParent(leftParent);
                    Vector3 left = new Vector3(0.02f, 1.03f, 0);
                    //coffe.transform.DOLocalJump(left, 12 - coffe.localPosition.y, 1, 2f);
                    //coffe.transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0, 350f + coffe.rotation.z)), 2f);
                    seq.Join(coffe.transform.DOLocalJump(left, 6 - coffe.localPosition.y, 1, 2f).
                    Join(coffe.transform.DOLocalRotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)).OnComplete(() =>
                    {
                        //coffe.transform.DOScale(new Vector3(coffe.transform.localScale.x * 1.2f, coffe.transform.localScale.y * 1.2f, coffe.transform.localScale.z), 0.1f).From();
                    }));
                    Debug.Log("sol");
                }
            }
            else if (deltaPos > 0)
            { // sað geçerken olduðunda 2 kere dnüyor 
                lastMousePosX = Input.mousePosition.x;
                seq = DOTween.Sequence();

                if (coffe.transform.CompareTag("sol"))
                {
                    coffe.transform.tag = "sag";
                    coffe.transform.DOKill();
                    seq.Kill();

                    coffe.SetParent(rightParent);
                    Vector3 right = new Vector3(0.02f, 1.03f, 0);
                    // coffe.transform.DOLocalJump(right, 12 - coffe.localPosition.y, 1, 2f);
                    //coffe.transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0, 350f + coffe.rotation.z)), 2f);
                    seq.Join(coffe.transform.DOLocalJump(right, 6 - coffe.localPosition.y, 1, 2f).
                     Join(coffe.transform.DOLocalRotate(new Vector3(0, 0, -360), 2f, RotateMode.FastBeyond360)).OnComplete(() =>
                     {
                         // coffe.transform.DOScale(new Vector3(coffe.transform.localScale.x * 1.2f, coffe.transform.localScale.y * 1.2f, coffe.transform.localScale.z), 0.1f).From();
                     }));

                    Debug.Log("sag");
                    //}


                }

            }
            else if (Input.GetMouseButtonUp(0))
            {
                deltaPos = 0;
            }


            //var swerve = Time.deltaTime * swerveSpeed * deltaPos;
            //swerve = Mathf.Clamp(swerve, -maxSwerveAmount, maxSwerveAmount);

            //var x = transform.position.x + swerve;
            //if (x < maxHorizontalDistance && x > -maxHorizontalDistance)
            //    transform.Translate(swerve, 0, 0);


        }
    }
}
