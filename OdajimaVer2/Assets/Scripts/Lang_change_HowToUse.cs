using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lang_change_HowToUse : MonoBehaviour
{
    Text text;
    public Data data;
    [SerializeField] string[] _text = new string[2];
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        data = GameObject.Find("DataManager").GetComponent<Data>();
        _text[0] = "1. スマホを傾けると前面の映像が表示されます。\n\n2.オブジェクトは指でスライドすると回転、2本の指で縮小、拡大するとオブジェクトの大きさが変わります。\n\n3.良い位置を見つけたらポーズボタンを押し撮影！\n\n4.画面内のボタンなどが消えるので、写真が気に入ったらスクリーンショットで保存してください！\n\n5.画面をタップするとリスタートボタンが表示され、押すとまた撮影できるようになります(もう一度画面をタップすると画面内の表示が消えます)。";
        _text[1] = "1. Tilt the phone to view the front image.\n\n2. Objects can be slid with a finger to rotate, and two fingers to shrink or enlarge to change the size of the object.\n\n3.When you find a good position, press the pause button to shoot!\n\n4.The buttons and other objects in the screen will disappear, so if you like the picture, please save it as a screenshot!\n\n5.Tap the screen to display the restart button and press it to shoot again (tap the screen again and the display in the screen will disappear).";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = _text[data.lang];
    }
}
