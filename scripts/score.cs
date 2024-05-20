using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _text.text="Score: "+totalscore.total_hourglass_score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hourglass"))
        {
            totalscore.total_timer = totalscore.total_timer + 3;
            _audio.Play();
            Destroy(other.gameObject);
            totalscore.total_hourglass_score++;
            _text.text = "Score: " + totalscore.total_hourglass_score.ToString();
        }
        
    }
}
