using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SwerveMovement : MonoBehaviour
{ //[SerializeField] private float swerveSpeed = .5f;
    //[SerializeField] private float maxSwerveAmount = 2;
    //[SerializeField] private float maxHorizontalDistance = 2;
    //public Transform coffe;
    public Transform rightParent, leftParent;


    private float deltaPos;
    private float lastMousePosX;
    public Sequence seq;
    public List<GameObject> Coffes = new List<GameObject>();
    public bool hareket;
    public Button PlayButton;
    
    #region Singleton
    public static SwerveMovement instance;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    #endregion

    private void FixedUpdate()
    {
        if (hareket==true)
        {
            Movement();
        }
       
    }
    private void Start()
    {
        hareket = false;
    }

    void Movement ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {

            deltaPos = Input.mousePosition.x - lastMousePosX;
            if (deltaPos < 0)
            {
                lastMousePosX = Input.mousePosition.x;
                seq = DOTween.Sequence();
                if (Coffes.Count > 0)
                {
                    for (int i = 0; i < Coffes.Count; i++)
                    {
                        if (Coffes[i].CompareTag("sag"))
                        {
                            Coffes[i].tag = "sol";
                            Coffes[i].transform.DOKill();
                            seq.Kill();
                            Coffes[i].transform.SetParent(leftParent);
                            Vector3 left = new Vector3(0.02f, 1.03f, 0);
                            //coffe.transform.DOLocalJump(left, 12 - coffe.localPosition.y, 1, 2f);
                            //coffe.transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0, 350f + coffe.rotation.z)), 2f);
                            seq.Join(Coffes[i].transform.DOLocalJump(left, 6 - Coffes[i].transform.localPosition.y, 1, 2f).
                            Join(Coffes[i].transform.DOLocalRotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)).OnComplete(() =>
                            {
                                    //coffe.transform.DOScale(new Vector3(coffe.transform.localScale.x * 1.2f, coffe.transform.localScale.y * 1.2f, coffe.transform.localScale.z), 0.1f).From();
                                }));
                            //Debug.Log("sol");
                        }
                    }


                }
                //if (coffe.transform.CompareTag("sag"))
                //{                   
                //    coffe.transform.tag = "sol";
                //    coffe.transform.DOKill();
                //    seq.Kill();
                //    coffe.transform.SetParent(leftParent);
                //    Vector3 left = new Vector3(0.02f, 1.03f, 0);
                //    //coffe.transform.DOLocalJump(left, 12 - coffe.localPosition.y, 1, 2f);
                //    //coffe.transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0, 350f + coffe.rotation.z)), 2f);
                //    seq.Join(coffe.transform.DOLocalJump(left, 6 - coffe.transform.localPosition.y, 1, 2f).
                //    Join(coffe.transform.DOLocalRotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)).OnComplete(() =>
                //    {
                //        //coffe.transform.DOScale(new Vector3(coffe.transform.localScale.x * 1.2f, coffe.transform.localScale.y * 1.2f, coffe.transform.localScale.z), 0.1f).From();
                //    }));
                //    Debug.Log("sol");
                //}
            }
            else if (deltaPos > 0)
            { // sað geçerken olduðunda 2 kere dnüyor 
                lastMousePosX = Input.mousePosition.x;
                seq = DOTween.Sequence();

                if (Coffes.Count > 0)
                {
                    for (int i = 0; i < Coffes.Count; i++)
                    {
                        if (Coffes[i].CompareTag("sol"))
                        {
                            Coffes[i].tag = "sag";
                            Coffes[i].transform.DOKill();
                            seq.Kill();
                            Coffes[i].transform.SetParent(rightParent);
                            Vector3 right = new Vector3(0.02f, 1.03f, 0);
                            //coffe.transform.DOLocalJump(left, 12 - coffe.localPosition.y, 1, 2f);
                            //coffe.transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0, 350f + coffe.rotation.z)), 2f);
                            seq.Join(Coffes[i].transform.DOLocalJump(right, 6 - Coffes[i].transform.localPosition.y, 1, 2f).
                            Join(Coffes[i].transform.DOLocalRotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)).OnComplete(() =>
                            {
                                    //coffe.transform.DOScale(new Vector3(coffe.transform.localScale.x * 1.2f, coffe.transform.localScale.y * 1.2f, coffe.transform.localScale.z), 0.1f).From();
                                }));
                            //Debug.Log("sol");
                        }
                    }

                    //    if (coffe.transform.CompareTag("sol"))
                    //{
                    //    coffe.transform.tag = "sag";
                    //    coffe.transform.DOKill();
                    //    seq.Kill();

                    //    coffe.transform.SetParent(rightParent);
                    //    Vector3 right = new Vector3(0.02f, 1.03f, 0);
                    //    // coffe.transform.DOLocalJump(right, 12 - coffe.localPosition.y, 1, 2f);
                    //    //coffe.transform.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0, 350f + coffe.rotation.z)), 2f);
                    //    seq.Join(coffe.transform.DOLocalJump(right, 6 - coffe.transform.localPosition.y, 1, 2f).
                    //     Join(coffe.transform.DOLocalRotate(new Vector3(0, 0, -360), 2f, RotateMode.FastBeyond360)).OnComplete(() =>
                    //     {
                    //         // coffe.transform.DOScale(new Vector3(coffe.transform.localScale.x * 1.2f, coffe.transform.localScale.y * 1.2f, coffe.transform.localScale.z), 0.1f).From();
                    //     }));

                    //    Debug.Log("sag");
                    //    //}


                    //}

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
    public void ClickPlayBtn()
    {
        hareket = true;
        PlayButton.gameObject.SetActive(false);
        Debug.Log("butona basýldý ");
    }
}
