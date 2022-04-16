using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRope : MonoBehaviour
{
    [SerializeField]
    [Tooltip("紐")]
    private GameObject rope;

    [SerializeField]
    [Tooltip("Rigidbody付与対象")]
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        CheckRopeExists();
    }

    public void CheckRopeExists()
    {
        // ロープが存在する場合
        if (rope)
        {
            // 何もしない
        }
        // ロープが存在しない場合
        else
        {
            // targetがゲームシーン上にある場合
            if(target)
            { 

                var component = target.GetComponent<Rigidbody>();

                // Rigidbodyが付与されていなかったら
                if (component == null)
                {
                    // 【target】にRigidBodyを付与
                    Rigidbody rigidbody = target.AddComponent<Rigidbody>();
                }
            }
        }
    }
}
