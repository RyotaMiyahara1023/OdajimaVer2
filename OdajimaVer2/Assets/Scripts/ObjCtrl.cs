using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObjCtrl : MonoBehaviour
{
  public GameObject[] obj = new GameObject[2];
  int obj_num = 0;
  public GameObject Camera;
  //回転用
  Vector2 sPos;   //タッチした座標
  Quaternion sRot;//タッチしたときの回転
  float wid, hei, diag;  //スクリーンサイズ
  float tx, ty;    //変数

  //ピンチイン ピンチアウト用
  float vMin = 0.5f, vMax = 2.0f;  //倍率制限
  float sDist = 0.0f, nDist = 0.0f; //距離変数
  Vector3 initScale; //最初の大きさ
  float v = 1.0f; //現在倍率
  CameraGyro gy;
  private Quaternion rot;
  [SerializeField] WebCam webcam;
  [SerializeField] MemorialManager memorialmanager;
  bool a = false;

  void Start()
  {
    wid = Screen.width;
    hei = Screen.height;
    diag = Mathf.Sqrt(Mathf.Pow(wid, 2) + Mathf.Pow(hei, 2));
    initScale = obj[0].transform.localScale;
    gy = Camera.GetComponent<CameraGyro>();
    rot = obj[0].transform.rotation;
  }

  void Update()
  {
    if (!webcam.pause && !memorialmanager.HowToUse.activeSelf)
    {
      if (Input.touchCount == 1)
      {
        //回転
        Touch t1 = Input.GetTouch(0);
        if (t1.phase == TouchPhase.Began)
        {
          sPos = t1.position;
          sRot = obj[obj_num].transform.rotation;
        }
        else if (t1.phase == TouchPhase.Moved || t1.phase == TouchPhase.Stationary)
        {
          tx = (t1.position.x - sPos.x) / wid; //横移動量(-1<tx<1)
          ty = (t1.position.y - sPos.y) / hei; //縦移動量(-1<ty<1)
          obj[obj_num].transform.rotation = sRot;
          /*obj.transform.Rotate(new Vector3(90*ty, -90*tx, 0),Space.World);*/
          obj[obj_num].transform.Rotate(new Vector3(90 * ty, -90 * tx, 0f), Space.World);
        }
      }
      else if (Input.touchCount >= 2)
      {
        //ピンチイン ピンチアウト
        Touch t1 = Input.GetTouch(0);
        Touch t2 = Input.GetTouch(1);
        if (t2.phase == TouchPhase.Began)
        {
          sDist = Vector2.Distance(t1.position, t2.position);
        }
        else if ((t1.phase == TouchPhase.Moved || t1.phase == TouchPhase.Stationary) &&
                   (t2.phase == TouchPhase.Moved || t2.phase == TouchPhase.Stationary))
        {
          nDist = Vector2.Distance(t1.position, t2.position);
          v = v + (nDist - sDist) / diag;
          sDist = nDist;
          if (v > vMax) v = vMax;
          if (v < vMin) v = vMin;
          obj[obj_num].transform.localScale = initScale * v;
        }
      }
    }
  }

  public void Obj_set()
  {
    obj[obj_num].SetActive(false);
    var r = obj[obj_num].transform.localEulerAngles;

    if(obj_num == obj.Length - 1) obj_num = 0;
    else obj_num++;

    obj[obj_num].SetActive(true);

    obj[obj_num].transform.localEulerAngles = r;
  }

  public void BackToTitle()
  {
    SceneManager.LoadScene("Title");
  }
}