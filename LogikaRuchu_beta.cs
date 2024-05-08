using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogikaRuchu_beta : MonoBehaviour
    {
        
        public float predkoscRuchu = 3.0f;
        Vector2 ruch = new Vector2();
        
        Rigidbody2D rb2D;
        private void Start()
        {
         
            rb2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            // Ta metoda na razie jest pusta.
        }
        void FixedUpdate()
        {
            ruch.x = Input.GetAxisRaw("Horizontal");
            ruch.y = Input.GetAxisRaw("Vertical");
            ruch.Normalize();
            rb2D.velocity = ruch * predkoscRuchu;
        }
    }
