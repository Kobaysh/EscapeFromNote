using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VisuallyEditor
{
    [CustomEditor(typeof(VisuallyEditableRect))]
    public class VisuallyEditableRectEditor : Editor
    {

        /// <summary>
        /// 編集用のアンカー位置情報
        /// </summary>
        private struct Anchors
        {
            public Vector2 downLeft;
            public Vector2 upRight;
            public Vector2 upLeft;
            public Vector2 downRight;

            public Rect ToRect()
            {
                return new Rect(downLeft, upRight - downLeft);
            }
        }

        private VisuallyEditableRect _target;
        private Anchors _anchors;

        private void OnSceneGUI()
        {
            serializedObject.Update();

            Handles.color = Color.white;
            DrawLine(_anchors);
            Handles.color = Handles.zAxisColor;
            _anchors = MoveAnchors(_anchors);

            serializedObject.FindProperty("_rect").rectValue = _anchors.ToRect();
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// アンカー同士をつなぐ線を描画
        /// </summary>
        private void DrawLine(Anchors anchors)
        {
            Handles.DrawAAPolyLine(anchors.upLeft, anchors.upRight, anchors.downRight, anchors.downLeft, anchors.upLeft);
        }

        /// <summary>
        /// 全アンカーの移動ハンドル
        /// </summary>
        private Anchors MoveAnchors(Anchors anchors)
        {
            anchors.downLeft = AnchorHandle(anchors.downLeft);
            anchors.upLeft.x = anchors.downLeft.x;
            anchors.downRight.y = anchors.downLeft.y;

            anchors.upRight = AnchorHandle(anchors.upRight);
            anchors.upLeft.y = anchors.upRight.y;
            anchors.downRight.x = anchors.upRight.x;

            anchors.upLeft = AnchorHandle(anchors.upLeft);
            anchors.downLeft.x = anchors.upLeft.x;
            anchors.upRight.y = anchors.upLeft.y;

            anchors.downRight = AnchorHandle(anchors.downRight);
            anchors.upRight.x = anchors.downRight.x;
            anchors.downLeft.y = anchors.downRight.y;

            return anchors;
        }

        /// <summary>
        /// アンカーの移動ハンドル
        /// </summary>
        public Vector3 AnchorHandle(Vector3 position)
        {

            var snap = Vector3.one;
            snap.x = EditorPrefs.GetFloat("MoveSnapX", 1.0f);
            snap.y = EditorPrefs.GetFloat("MoveSnapY", 1.0f);
            snap.z = EditorPrefs.GetFloat("MoveSnapZ", 1.0f);

            // FreeMove
            var handleSize = HandleUtility.GetHandleSize(position) * 0.1f;
            Handles.CapFunction RectangleHandleCap2D = (id, pos, rot, size, eventType) => {
                Handles.CubeHandleCap(id, pos, rot, size, eventType);
            };

            var movePoint = Handles.FreeMoveHandle(position, Quaternion.identity, handleSize, snap, RectangleHandleCap2D);
            // XY平面上の近傍点を新しい位置とする
            position = movePoint - Vector3.forward * Vector3.Dot(movePoint - position, Vector3.forward);

            return position;
        }

        private void OnEnable()
        {
            _target = target as VisuallyEditableRect;
            _anchors.downLeft = _target.Rect.min;
            _anchors.upRight = _target.Rect.max;
        }
    }
}