using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Explanation;
    public Text Explanation_subtitle;
    public GameObject Camera;
    public GameObject Chapter0_ika;
    public GameObject start_panel;
    public GameObject next_panel;
    public GameObject end_panel;
    public GameObject pause_panel;
    public GameObject[] Movie_3D = new GameObject[3];
    Animator[] animator = new Animator[3];
    [SerializeField] Data data;
    AudioSource audioSource;
    public Movie movie;
    public bool pause = false;
    bool start_moive = false;
    [SerializeField] string[][][] ex_text = new string[2][][];

    [SerializeField] private List<sound> list = new List<sound>();
    public GameObject[] Delete = new GameObject[5];
    float pos;

    [System.Serializable] class sound
    {
        public List<AudioClip> se = new List<AudioClip>();
    }

    [SerializeField] private List<odajima> narration = new List<odajima>();

    [System.Serializable] class odajima
    {
        public List<AudioClip> narr = new List<AudioClip>();
    }

    // Start is called before the first frame update
    public void Load_Data()
    {
        data = GameObject.Find("DataManager").GetComponent<Data>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = (float)data.volume/100;
        for(int i = 0; i < 3; i++) animator[i] = Movie_3D[i].GetComponent<Animator>();
        Movie_3D[data.chapter].SetActive(true);
        audioSource.pitch = Time.timeScale;

        ex_text[0] = new string[3][];

        ex_text[0][0] = new string[5];
        ex_text[0][0][0] = "この作業はこれからさばいていくイカを1度金属探知機に通すことで金属の混入を防ぐために行われます。";
        ex_text[0][0][1] = "まず金属探知機を起動して、イカを1匹ずつベルトコンベアの上にのせていきます。";
        ex_text[0][0][2] = "イカが重ならないように間隔をあけてのせていきます。";
        ex_text[0][0][3] = "金属が検知されなかったイカはそのまま流れていって次のマキリでさばかれる作業に移動します。";
        ex_text[0][0][4] = "金属が検知されたイカがいた場合は金属探知機の作動は一時停止されます。";

        ex_text[0][1] = new string[7];
        ex_text[0][1][0] = "小田島水産では、アイヌ民族が使っていた「マキリ」という短刀を使って、職人が一つひとつ手作業でイカを捌いています。";
        ex_text[0][1][1] = "まずは、イカの胴体を半分に切って開き、そこからゴロを取り出します。ゴロはイカの肝臓です。";
        ex_text[0][1][2] = "このゴロは、塩辛を木樽で漬け込むときに使うので丁寧に取り出します。";
        ex_text[0][1][3] = "ゴロに含まれる酵素が味に深みを加えてくれます。\nこのとき、イカの足が胴体からちぎれないように気をつけます。";
        ex_text[0][1][4] = "ゴロを取り出したら、次に背骨を慎重に引き抜きます。";
        ex_text[0][1][5] = "その後、足の付け根にある「目」と「トンビ」をマキリで取り外していきます。\n「トンビ」はイカのくちばしのことを指します。";
        ex_text[0][1][6] = "切り取った部位は、イカ墨パスタや軟骨だけの塩辛など、別の料理に活用されるほか、業者さんが回収して肥料として再利用されます。";

        ex_text[0][2] = new string[7];
        ex_text[0][2][0] = "小田島水産では秋田杉でできた木樽を用いて塩辛づくりをしています。";
        ex_text[0][2][1] = "なぜなら、木樽特有の表面の凹凸に住みつく発酵菌が塩辛の発酵には欠かせません。";
        ex_text[0][2][2] = "木樽に仕込んだ塩辛を1週間毎日5分程度樫の棒で突きながら、空気を含ませる攪拌作業を行います。";
        ex_text[0][2][3] = "この攪拌作業が発酵菌に酸素を行きわたらせ、塩辛の発酵を促します。";
        ex_text[0][2][4] = "木樽で自然発酵させることで美しい桜色の塩辛に仕上がります。";
        ex_text[0][2][5] = "木樽ならではのまろやかで深みのある味を是非ご賞味あれ。";
        ex_text[0][2][6] = "記念撮影のページがあるのでぜひそちらもご覧ください。";

        ex_text[1] = new string[3][];

        ex_text[1][0] = new string[5];
        ex_text[1][0][0] = "This process is performed to prevent metal contamination by passing the squid to be filleted through a metal detector once.";
        ex_text[1][0][1] = "First, the metal detector is activated and the squid are placed one by one on the conveyor belt.";
        ex_text[1][0][2] = "Squids are placed on the conveyor belt one by one.";
        ex_text[1][0][3] = "Squids that are not detected will be moved to the next operation, where they will be separated by the “Makiri”.";
        ex_text[1][0][4] = "If metal is detected on any squid, the metal detector will be temporarily stopped.";

        ex_text[1][1] = new string[7];
        ex_text[1][1][0] = "At Odajima Suisan, artisans process squid one by one by hand using “Makiri” daggers, which were used by the Ainu tribe.";
        ex_text[1][1][1] = "First, the body of the squid is cut in half and opened, from which the “Goro” is removed. Goro is the liver of the squid.";
        ex_text[1][1][2] = "The goro is carefully removed because it is used to marinate the salted fish in a wooden barrel.";
        ex_text[1][1][3] = "The enzymes contained in the goro add depth to the flavor.\nAt this time, be careful not to tear off the squid's legs from the body.";
        ex_text[1][1][4] = "After removing the goro, carefully pull out the backbone.";
        ex_text[1][1][5] = "Then, the eyes and “Tombi” at the base of the legs are removed with a Makiri.\n“Tombi” refers to the beak of the squid.";
        ex_text[1][1][6] = "The cut parts are used for other dishes such as squid ink pasta and salted squid bones only, and are also collected and reused as fertilizer by the vendor.";

        ex_text[1][2] = new string[7];
        ex_text[1][2][0] = "Odajima Suisan uses wooden barrels made of Akita cedar to make salted fish.";
        ex_text[1][2][1] = "This is because the fermentation bacteria that live on the uneven surface of the wooden barrels are indispensable for the fermentation of the salted fish.";
        ex_text[1][2][2] = "The salted fish in the wooden barrels is poked with an oak stick for about five minutes every day for a week to stir the fish and let the air in.";
        ex_text[1][2][3] = "This stirring process allows oxygen to flow to the fermenting bacteria and promotes the fermentation of the salted fish.";
        ex_text[1][2][4] = "The natural fermentation in the wooden barrels gives the salted fish a beautiful cherry color.";
        ex_text[1][2][5] = "Please enjoy the mellow and deep flavor that only wooden barrels can provide.";
        ex_text[1][2][6] = "Please take a look at the commemorative photo page.";
        RenderSettings.skybox = movie.back[data.chapter + 1];
        if(data.subtitle) Explanation.SetActive(true);
        movie.Set_Movie();
    }

    // Update is called once per frame
    void Update()
    {
        if(data.chapter == 0) Camera.transform.position = new Vector3(Chapter0_ika.transform.position.x, Chapter0_ika.transform.position.y + 1f, Chapter0_ika.transform.position.z);

        if(data.subtitle){
            //Explanation.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, Explanation.GetComponent<RectTransform>().sizeDelta.y);
            //Debug.Log("sizeDelta =" + Explanation.GetComponent<RectTransform>().sizeDelta);
        }
    }

    public void Test(){
        start_panel.SetActive(false);
        next_panel.SetActive(false);
        //movie.Play_Movie();
        start_moive = false;
        RenderSettings.skybox = movie.back[data.chapter + 1];
        StartCoroutine("Chapter_" + data.chapter);
        Delete[2].SetActive(false);
        Delete[3].SetActive(false);
        Delete[4].SetActive(false);
    }

    IEnumerator Chapter_0()
    {
        /*animator[0].SetFloat("Ika1", 1.0f);
        yield return new WaitForSeconds(144f/24f + 1f/24f);
        animator[0].SetFloat("Ika2", 1.0f);
        yield return new WaitForSeconds(72f/24f + 1f/24f);
        animator[0].SetFloat("Ika3", 1.0f);
        yield return new WaitForSeconds(72f/24f + 1f/24f);
        animator[0].SetFloat("DustBox", 1.0f);
        yield return new WaitForSeconds(360f/24f + 1f/24f);*/
        IEnumerator enumerator = Explanation_Set(data.lang, 0);
        yield return enumerator;
        RenderSettings.skybox.SetFloat("_Rotation", 0f);
        audioSource.PlayDelayed(0.0000001f);
        audioSource.PlayOneShot(narration[0].narr[0]);
        //Explanation_subtitle.text = ex_text[data.lang][0][0];
        yield return new WaitForSeconds(10f);
        audioSource.PlayOneShot(narration[0].narr[1]);
        Explanation_subtitle.text = ex_text[data.lang][0][1];
        yield return new WaitForSeconds(7f);
        RenderSettings.skybox = movie.back[0];
        RenderSettings.skybox.SetFloat("_Rotation", 0f);
        movie.Play_Movie();
        movie.audioSource.PlayDelayed(0.0000001f);
        movie.audioSource.clip = movie.movie_BGM[0];
        movie.audioSource.Play();
        start_moive = true;
        animator[0].SetFloat("Ika1", 0f);
        //animator[0].SetFloat("Ika2", 0.753f);
        animator[0].SetFloat("Ika2", 0.8f);
        animator[0].SetFloat("Ika3", 0f);
        //yield return new WaitForSeconds(24f/24f + 1f/24f);
        audioSource.PlayOneShot(list[0].se[0]);
        //audioSource.PlayOneShot(list[0].se[1]);
        yield return new WaitForSeconds(36f/24f);
        //animator[0].SetFloat("Ika2", 0.0f);
        audioSource.PlayOneShot(narration[0].narr[2]);
        Explanation_subtitle.text = ex_text[data.lang][0][2];
        animator[0].SetFloat("Hand", 1.0f); //36
        yield return new WaitForSeconds(70f/24f);
        animator[0].SetFloat("Ika2", 0.5f);
        yield return new WaitForSeconds(5f - 70f/24f);
        audioSource.PlayOneShot(narration[0].narr[3]);
        Explanation_subtitle.text = ex_text[data.lang][0][3];
        yield return new WaitForSeconds(60f/24f);
        Delete[0].SetActive(false);
        animator[0].SetFloat("Ika2", 1.2f);
        Delete[1].SetActive(false);
        yield return new WaitForSeconds(84f/24f + 2f -60f/24f);
        audioSource.PlayOneShot(list[0].se[2]); //288
        yield return new WaitForSeconds(24f/24f);
        audioSource.PlayOneShot(list[0].se[3]); //315
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(narration[0].narr[4]);
        Explanation_subtitle.text = ex_text[data.lang][0][4];
        yield return new WaitForSeconds(189f/24f);
        animator[0].SetFloat("Ika2", 1.0f);
        Delete[2].SetActive(true);
        Delete[3].SetActive(true);
        Delete[4].SetActive(true); //504
        //yield return new WaitForSeconds(336f/24f - 2f);
        yield return new WaitForSeconds(147/24f);
        audioSource.PlayOneShot(list[0].se[4]);
        animator[0].SetFloat("DustBox", 1.0f); //651
        yield return new WaitForSeconds(240f/24f);
        audioSource.PlayOneShot(list[0].se[5]); //891
        yield return new WaitForSeconds(120f/24f);
        audioSource.PlayOneShot(list[0].se[6]); //1011
        yield return new WaitForSeconds(69f/24f);
        movie.audioSource.Stop();
        next_panel.SetActive(true);
    }

    IEnumerator Chapter_1()
    {
        /*animator[1].SetFloat("right_hand", 1.0f);
        yield return new WaitForSeconds(78f/24f + 1f/24f);
        animator[1].SetFloat("Makiri", 1.0f); //78
        yield return new WaitForSeconds(33f/24f + 1f/24f);
        animator[1].SetFloat("left_hand", 1.0f); //111
        yield return new WaitForSeconds(140f/24f + 1f/24f);
        animator[1].SetFloat("Open", 1.0f);
        audioSource.PlayOneShot(list[1].se[0]); //251
        yield return new WaitForSeconds(75f/24f + 1f/24f);
        animator[1].SetFloat("Kou", 1.0f); //326
        yield return new WaitForSeconds(95f/24f + 1f/24f);
        animator[1].SetFloat("Goro", 1.0f); //421
        yield return new WaitForSeconds(790f/24f + 1f/24f);
        animator[1].SetFloat("Right_eye", 1.0f);  //1211
        yield return new WaitForSeconds(69f/24f + 1f/24f);
        animator[1].SetFloat("Left_eye", 1.0f); //1280
        yield return new WaitForSeconds(161f/24f + 1f/24f);
        animator[1].SetFloat("Tonbi", 1.0f);*/  //1441
        IEnumerator enumerator = Explanation_Set(data.lang, 1);
        yield return enumerator;
        Movie_3D[1].transform.eulerAngles = new Vector3(0f, Camera.transform.localEulerAngles.y, 0f);
        Movie_3D[1].transform.position = new Vector3(-3*Mathf.Sin(Camera.transform.eulerAngles.y * Mathf.Deg2Rad),-4f, -3*Mathf.Cos(Camera.transform.eulerAngles.y * Mathf.Deg2Rad));
        movie.Chapter_1_Set();
        Camera.transform.position = new Vector3(0f, 0f, 0f);
        audioSource.PlayDelayed(0.0000001f);
        audioSource.PlayOneShot(narration[1].narr[0]);
        //Explanation_subtitle.text = ex_text[data.lang][1][0];
        yield return new WaitForSeconds(11f);
        RenderSettings.skybox = movie.back[0];
        RenderSettings.skybox.SetFloat("_Rotation", -(Movie_3D[1].transform.localEulerAngles.y + 180f));
        movie.Play_Movie();
        movie.audioSource.PlayDelayed(0.0000001f);
        movie.audioSource.clip = movie.movie_BGM[1];
        movie.audioSource.Play();
        start_moive = true;
        animator[1].SetFloat("right_hand", 1.0f);
        yield return new WaitForSeconds(78f/24f);
        animator[1].SetFloat("Makiri", 1.0f); //78
        yield return new WaitForSeconds(3f/24f);
        audioSource.PlayOneShot(list[1].se[0]); //81
        yield return new WaitForSeconds(30f/24f);
        audioSource.PlayOneShot(narration[1].narr[1]);
        Explanation_subtitle.text = ex_text[data.lang][1][1];
        animator[1].SetFloat("left_hand", 1.0f); //111
        yield return new WaitForSeconds(140f/24f);
        animator[1].SetFloat("Open", 1.0f);
        audioSource.PlayOneShot(list[1].se[1]); //251
        yield return new WaitForSeconds(75f/24f);
        animator[1].SetFloat("Kou", 1.0f); //326
        yield return new WaitForSeconds(25f/24f);
        audioSource.PlayOneShot(narration[1].narr[2]);
        Explanation_subtitle.text = ex_text[data.lang][1][2];
        yield return new WaitForSeconds(70f/24f);
        animator[1].SetFloat("Goro", 1.0f); //421
        yield return new WaitForSeconds(9f/24f);
        audioSource.PlayOneShot(list[1].se[2]); //430
        yield return new WaitForSeconds(89f/24f);
        audioSource.PlayOneShot(narration[1].narr[3]);
        Explanation_subtitle.text = ex_text[data.lang][1][3];
        yield return new WaitForSeconds(67f/24f);
        audioSource.PlayOneShot(list[1].se[3]); //586
        yield return new WaitForSeconds(95f/24f);
        audioSource.PlayOneShot(list[1].se[4]); //681
        yield return new WaitForSeconds(78f/24f);
        audioSource.PlayOneShot(narration[1].narr[4]);
        Explanation_subtitle.text = ex_text[data.lang][1][4];
        yield return new WaitForSeconds(42f/24f);
        audioSource.PlayOneShot(list[1].se[5]); //801
        yield return new WaitForSeconds(69f/24f);
        audioSource.PlayOneShot(list[1].se[6]); //870
        yield return new WaitForSeconds(130f/24f);
        audioSource.PlayOneShot(list[1].se[7]); //1000
        yield return new WaitForSeconds(90f/24f);
        audioSource.PlayOneShot(narration[1].narr[5]);
        Explanation_subtitle.text = ex_text[data.lang][1][5];
        yield return new WaitForSeconds(90f/24f);
        audioSource.PlayOneShot(list[1].se[8]); //1180
        //yield return new WaitForSeconds(31f/24f);
        //yield return new WaitForSeconds(18f/24f);
        yield return new WaitForSeconds(24f/24f);
        animator[1].SetFloat("Right_eye", 1.0f); //1211
        yield return new WaitForSeconds(10f/24f);
        audioSource.PlayOneShot(list[1].se[9]); //1221
        yield return new WaitForSeconds(13f/24f);
        audioSource.PlayOneShot(narration[1].narr[6]);
        yield return new WaitForSeconds(26f/24f);
        audioSource.PlayOneShot(list[1].se[10]); //1260
        yield return new WaitForSeconds(11f/24f);
        audioSource.PlayOneShot(list[1].se[11]); //1271
        yield return new WaitForSeconds(9f/24f);
        animator[1].SetFloat("Left_eye", 1.0f);  //1280
        yield return new WaitForSeconds(7f/24f);
        audioSource.PlayOneShot(list[1].se[12]); //1287
        yield return new WaitForSeconds(33f/24f);
        audioSource.PlayOneShot(list[1].se[13]); //1320
        yield return new WaitForSeconds(40f/24f);
        audioSource.PlayOneShot(list[1].se[14]); //1360
        //yield return new WaitForSeconds(81f/24f);
        yield return new WaitForSeconds(81f/24f);
        animator[1].SetFloat("Tonbi", 1.0f); //1441
        yield return new WaitForSeconds(39f/24f);
        audioSource.PlayOneShot(list[1].se[15]); //1480
        yield return new WaitForSeconds(131f/24f);
        audioSource.PlayOneShot(narration[1].narr[7]);
        Explanation_subtitle.text = ex_text[data.lang][1][6];
        audioSource.PlayOneShot(list[1].se[16]); //1611
        yield return new WaitForSeconds(41f/24f);
        audioSource.PlayOneShot(list[1].se[17]); //1652
        yield return new WaitForSeconds(20f/24f);
        audioSource.PlayOneShot(list[1].se[18]); //1672
        yield return new WaitForSeconds(49f/24f);
        audioSource.PlayOneShot(list[1].se[19]); //1721
        yield return new WaitForSeconds(20f/24f);
        audioSource.PlayOneShot(list[1].se[20]); //1741
        yield return new WaitForSeconds(155f/24f);
        movie.audioSource.Stop();
        next_panel.SetActive(true);//1896
    }

    IEnumerator Chapter_2()
    {
        IEnumerator enumerator = Explanation_Set(data.lang, 2);
        yield return enumerator;
        RenderSettings.skybox.SetFloat("_Rotation", 0f);
        Camera.transform.position = new Vector3(0f, 0f, 0f);
        RenderSettings.skybox = movie.back[0];
        RenderSettings.skybox.SetFloat("_Rotation", 0f);
        movie.Play_Movie();
        movie.audioSource.PlayDelayed(0.0000001f);
        movie.audioSource.clip = movie.movie_BGM[2];
        movie.audioSource.Play();
        start_moive = true;
        animator[2].SetFloat("Taru", 1.0f);
        audioSource.PlayDelayed(0.0000001f);
        audioSource.PlayOneShot(narration[2].narr[0]);
        //Explanation_subtitle.text = ex_text[data.lang][2][0];
        yield return new WaitForSeconds(8f);
        Explanation_subtitle.text = ex_text[data.lang][2][1];
        yield return new WaitForSeconds(9f);
        audioSource.PlayOneShot(narration[2].narr[1]);
        Explanation_subtitle.text = ex_text[data.lang][2][2];
        yield return new WaitForSeconds(12f);
        audioSource.Stop();
        audioSource.PlayOneShot(narration[2].narr[2]);
        Explanation_subtitle.text = ex_text[data.lang][2][3];
        yield return new WaitForSeconds(9f);
        audioSource.PlayOneShot(narration[2].narr[3]);
        Explanation_subtitle.text = ex_text[data.lang][2][4];
        yield return new WaitForSeconds(7f);
        audioSource.Stop();
        audioSource.PlayOneShot(narration[2].narr[4]);
        Explanation_subtitle.text = ex_text[data.lang][2][5];
        yield return new WaitForSeconds(7f);
        audioSource.PlayOneShot(narration[2].narr[5]);
        Explanation_subtitle.text = ex_text[data.lang][2][6];
        yield return new WaitForSeconds(10f);
        //yield return new WaitForSeconds(60f);
        movie.audioSource.Stop();
        end_panel.SetActive(true);
    }

    public void BackToTitle(){
        SceneManager.LoadScene("Title");
    }

    public void Next(){
        Movie_3D[data.chapter].SetActive(false);
        data.chapter++;
        movie.Change_Movie();
        /*if(data.chapter == 1){
            //Movie_3D[1].transform.Rotate(new Vector3(0f, Camera.transform.localEulerAngles.y, 0f));
            Movie_3D[1].transform.eulerAngles = new Vector3(0f, Camera.transform.localEulerAngles.y, 0f);
            Movie_3D[1].transform.position = new Vector3(-3*Mathf.Sin(Camera.transform.eulerAngles.y * Mathf.Deg2Rad),-4f, -3*Mathf.Cos(Camera.transform.eulerAngles.y * Mathf.Deg2Rad));
        }*/
        //Movie_3D[data.chapter].SetActive(true);
        //Test();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        audioSource.pitch = Time.timeScale;
        movie.audioSource.UnPause();
        if(start_moive) movie.Play_Movie();
        pause_panel.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        audioSource.pitch = Time.timeScale;
        movie.audioSource.Pause();
        if(start_moive) movie.Pause_Movie();
        pause_panel.SetActive(true);
    }

    IEnumerator Explanation_Set(int lang, int num)
    {
        if(data.subtitle) {
            Explanation.SetActive(true);
            Explanation.GetComponent<VerticalLayoutGroup>().childControlHeight = true;
            Explanation.GetComponent<ContentSizeFitter>().enabled = true;
            var len = ex_text[lang][num].Length;
            Explanation.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
            Explanation_subtitle.text = null;
            var pos = 0f;
            for(int i = 0; i < len; i++) {
                IEnumerator enumerator = Set(lang, num, i);
                yield return enumerator;
                if(Explanation.GetComponent<RectTransform>().sizeDelta.y >= pos) pos = Explanation.GetComponent<RectTransform>().sizeDelta.y;
                Debug.Log(pos + " , " + Explanation.GetComponent<RectTransform>().sizeDelta.y + " , " + ex_text[lang][num][i]);
                //yield return new WaitForSeconds(2f);
            }
            Explanation_subtitle.text = ex_text[lang][num][0];
            Explanation.GetComponent<VerticalLayoutGroup>().childControlHeight = false;
            Explanation.GetComponent<ContentSizeFitter>().enabled = false;
            Vector2 sd = Explanation.GetComponent<RectTransform>().sizeDelta;
            Vector2 sdt = Explanation.GetComponent<RectTransform>().sizeDelta;
            //Debug.Log(pos + " , " + sd);
            sd.y = pos;
            sdt.y = pos;
            Explanation.GetComponent<RectTransform>().sizeDelta = sd;
            Explanation_subtitle.GetComponent<RectTransform>().sizeDelta = sdt;
            //Debug.Log(pos + " , " + sd);
            Explanation.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, pos);
        }
        yield return null;
    }

    IEnumerator Set(int lang, int num, int i)
    {
        Explanation_subtitle.text = ex_text[lang][num][i];
        yield return null;
    }
}
