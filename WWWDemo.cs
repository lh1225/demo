using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class WWWDemo : MonoBehaviour {

	public GameObject cube;
	public GameObject sphere;

	//新修改地方
	void Start () {
//		StartCoroutine ("downloadByFile");
//		StartCoroutine ("downFormNet");
		StartCoroutine ("TestPost");
	}
	
	IEnumerator downloadByFile(){
		using (WWW texture = new WWW (
			"file:///Users/mac/Downloads/1.jpeg")) {
			yield return texture;
			cube.GetComponent<Renderer> ().material.mainTexture =
				texture.texture;
		}
	}
	IEnumerator downFormNet(){
		WWW data = new WWW ("https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1507886732258&di=feffb9ae4ff6d200180dd9d776216cb3&imgtype=0&src=http%3A%2F%2Fpic27.nipic.com%2F20130310%2F2256974_155217830000_2.jpg");
		yield return data;
		sphere.GetComponent<Renderer> ().material.mainTexture = data.texture;
		data.Dispose ();
	}

	IEnumerator TestPost(){
		string m_info = null;
		Dictionary<string ,string > hash = new Dictionary<string,string> ();
		hash.Add ("Content-Type", "application/json");
		string data = "{'email':'1234@qq.com','password':'123456','phoneIdentity':'" +
			"32324aasd2312313'}";
		byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes (data);
		WWW www = new WWW ("http://123.56.50.222:8050/userLogin", bs, hash);
		yield return www;
		if (www.error != null) {
//			m_info = www.error;
			yield return null;
		}
		m_info = www.text;
		print (m_info);
	}

	string GetUrl(string mainUrl,Dictionary<string,string>dic){
		string s;
		s = mainUrl + "?" + "username=" +dic.Keys+ "&" +"passward="+ dic.Values;

		return s;

	}
}
