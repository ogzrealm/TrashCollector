using System.Collections;
using UnityEngine;

public class TrashHoleScript : MonoBehaviour
{
    private SpriteRenderer _trashholeSprite;
    
    void Start()
    {
        _trashholeSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,40 * Time.deltaTime);
    }

    public void HoleColorChange()
    {
        StartCoroutine(holeColoring());
    }

    private IEnumerator holeColoring()
    {
        var currentColor = _trashholeSprite.color;
        yield return new WaitForSeconds(0.1f);
        var newColor=_trashholeSprite.color=new Color32(227, 151, 227, 255);
        _trashholeSprite.color=newColor;
        yield return new WaitForSeconds(0.6f);
        _trashholeSprite.color = currentColor;

    }
}
