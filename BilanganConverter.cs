using System;
using System.Collections.Generic;

namespace BilanganConverter
{
	class MainClass
	{
		
		public static void KalkulasiBasisLain(string c, int d, int e){ // c = nilaiutama, d = basisUtama, e = basisKonversi
			int result = 0;
			char[] a = c.ToCharArray();
			for (int i = 0; i < a.Length; i++) {
				int temp = 0;
				if (d == 16) {
					switch (a [i]) {
					case 'A':
						temp = 10; 
						break;
					case 'B':
						temp = 11; 
						break;
					case 'C':
						temp = 12; 
						break;
					case 'D':
						temp = 13; 
						break;
					case 'E':
						temp = 14; 
						break;
					case 'F':
						temp = 15; 
						break;
					default:
						temp = (int)Char.GetNumericValue (a [i]);
						break;
					}
				} else {
					temp = (int)Char.GetNumericValue (a [i]);
				}
				result += temp * (int)Math.Pow (d, (a.Length - 1) - i);
			}
			KalkulasiBasisDesimal (result, e);
		}

		public static void KalkulasiBasisDesimal(int c, int d){
			int a, b = 0;
			a = c;
			List<string> listNum = new List<string> (); 
			while (a > 0){
				a = Math.DivRem(a, d, out b);
				if (d == 16) {
					switch (b) {
					case 10:
						listNum.Add ("A");
						break;
					case 11:
						listNum.Add ("B");
						break;
					case 12:
						listNum.Add ("C");
						break;
					case 13:
						listNum.Add ("D");
						break;
					case 14:
						listNum.Add ("E");
						break;
					case 15:
						listNum.Add ("F");
						break;
					default:
						listNum.Add (b.ToString());
						break;
					}
				} else {
					listNum.Add (b.ToString ());
				}
			}
			Console.Write ("\nHasil Konversi: ");
			for(int i = (listNum.Count - 1); i >= 0; i--){
				Console.Write (listNum [i]);
			}
			Console.WriteLine("\n");
			Utama ();
		}

		static void Utama(){
			int basisUtama, basisKonversi;
			string nilaiUtama;
			Console.Write ("Masukkan Nilai Utama: ");
			nilaiUtama = Console.ReadLine ();
			Console.Write ("\nMasukkan Basis Utama: ");
			basisUtama = int.Parse(Console.ReadLine ());
			Console.Write ("\nMasukkan Basis Konversi: ");
			basisKonversi = int.Parse(Console.ReadLine ());
			if (basisUtama == 10) {
				KalkulasiBasisDesimal (int.Parse(nilaiUtama), basisKonversi);
			} else {
				KalkulasiBasisLain (nilaiUtama, basisUtama, basisKonversi);
			}
		}

		public static void Main (string[] args)
		{
			Utama ();
		}
	}
}
