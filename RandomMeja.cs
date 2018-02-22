using System;
using System.Collections.Generic;

namespace RandomMeja
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<string> nama = new List<string> ();
			nama.Add ("Amar");
			nama.Add ("Khavita");
			nama.Add ("Lola");
			nama.Add ("Batara");
			nama.Add ("Zefanya");
			nama.Add ("Bidadari");
			nama.Add ("Tasya");
			nama.Add ("Farras");
			nama.Add ("Daffa");
			nama.Add ("Alfonso");
			nama.Add ("Rindu");
			nama.Add ("Yose");
			nama.Add ("Nicholas");
			nama.Add ("Dela");
			nama.Add ("Nasywa");
			nama.Add ("Ronaldo");
			nama.Add ("Rafi");
			nama.Add ("Kynta");
			nama.Add ("Qori");
			nama.Add ("Anna");
			nama.Add ("Aqil");
			nama.Add ("Winda");
			nama.Add ("Ardhini");
			nama.Add ("Christy");
			nama.Add ("Tamir Pradityo");
			nama.Add ("Haris");
			nama.Add ("Rizky Anwar");
			nama.Add ("Mikhael");
			nama.Add ("Ilona");
			nama.Add ("Lufthanza");
			nama.Add ("Josep");
			nama.Add ("Michelle Winnie");
			nama.Add ("Omar");
			nama.Add ("Rizki Ramadhani");
			nama.Add ("Elson");
			nama.Add ("Hanzel");
			for (int i = 1; i <= 36; i++) {
				int idx = new Random (Guid.NewGuid().GetHashCode()).Next (0, nama.Count);
				Console.Write (i.ToString ("00") + " - " + nama [idx] + "\n");
				nama.RemoveAt (idx);
			}
		}
	}
}
