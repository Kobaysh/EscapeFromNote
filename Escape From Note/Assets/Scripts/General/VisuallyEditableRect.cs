using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisuallyEditor
{
    public class VisuallyEditableRect : MonoBehaviour
    {
        [SerializeField]
        private Rect _rect = new Rect(Vector2.one * -0.5f, Vector2.one);
        public Rect Rect => _rect;
    }
}