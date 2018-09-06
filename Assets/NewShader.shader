public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //計算用スコア
    private int score = 0;

    //スコアを表示するテキスト
    private Text scoreText;

    // Use this for initialization
    void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        SetScore();
    }
    
    // Update is called once per frame
    void Update () {
        //ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ){
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string Tag = collision.gameObject.tag;

        if(Tag == "SmallStarTag"){
            score += 10;
        }else if(Tag == "LargeStarTag"){
            score += 20;
        }else if(Tag == "SmallCloudTag"){
            score += 15;
        }else if(Tag == "LargeCloudTag"){
            score += 30;
        }

        SetScore();
    }

    void SetScore(){
        scoreText.text = string.Format("SCORE:{0}", score);
    }
}
