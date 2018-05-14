using UnityEngine.UI;
using UnityEngine;

public class move : MonoBehaviour {
	[Header("Статистика Игрока")]
	public float hp = 100;
	public int speed = 5;
	public Text GUI_hp;
	public Slider GUI_Slider;
	public Transform Camera;
	Rigidbody rb;
	Transform tf;
    Vector3 OriginGravity = new Vector3(0,-1000,0);
	float v,h;
	void Start () {
		tf = GetComponent<Transform> ();
        rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		GUI_Slider.value = hp;
		GUI_hp.text = "HP:"+hp;

		v = Input.GetAxis ("Vertical");
        h = Input.GetAxis ("Horizontal");

        rb.AddForce(OriginGravity);
            if (v > 0) {
                rb.velocity = Vector3.Cross(Camera.right * speed * v,new Vector3(0,1,0));
            } else if (v < 0){
                rb.velocity = Vector3.Cross(Camera.right * speed * v,new Vector3(0,1,0));
            }
            if (h > 0) {
                rb.velocity = Vector3.Cross(Camera.forward * speed * (-h),new Vector3(0,1,0));
            } else if (h < 0){
                rb.velocity = Vector3.Cross(Camera.forward * speed * (-h),new Vector3(0,1,0));
            }
	}
    void OnCollisionEnter(Collision arg){
        if(arg.gameObject.layer == 11){
            OriginGravity = new Vector3(0,0,0);
        }
    }
    void OnCollisionExit(Collision arg){
        if(arg.gameObject.layer == 11){
            OriginGravity = new Vector3(0,-1000,0);
        }
    }
}
