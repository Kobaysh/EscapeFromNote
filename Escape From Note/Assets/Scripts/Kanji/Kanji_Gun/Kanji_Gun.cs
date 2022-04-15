using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//継承クラス
[CreateAssetMenu(menuName="Assets/Kanji Scriptable/Kanji_Gun")]
public class Kanji_Gun : Kanji_Abstract
{
    private GameObject firingPoint;

    [SerializeField, Header("銃")]
    [Tooltip("弾")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 20f;

	/// 弾の発射
    private void LauncherShot()
    {
        
        GameObject player = GameObject.Find("Player");
        firingPoint = player;

        // 弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        bulletPosition.x += 1.0f;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = Instantiate(bullet, bulletPosition, bullet.transform.rotation);
        // 出現させたボールのforward(z軸方向)
        Vector3 direction = newBall.transform.right;
        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを1.5秒後に消す
        Destroy(newBall, 1.5f);
    }

    //アクション
    public override void KanjiAction()
    {
        Debug.Log("銃");

        // 弾を発射する
        LauncherShot();
       
    }
}