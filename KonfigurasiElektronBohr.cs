using System;
using System.Collections.Generic;

namespace KonfigurasiElektronBohr
{
	class MainClass
	{
		public static void Calculate(){
			int maxKulit;
			bool end = false;
			List<int> kulitAtom = new List<int>();
			while (!end) {
				Console.Write ("Nomor Atom\t\t: ");
				int nomorAtom = 0;
				try {
					nomorAtom = int.Parse(Console.ReadLine ());
				} catch (FormatException){
					Console.Write("\nInput bukan merupakan angka!");
					Console.Write ("\n\n=================\n\n");
					Calculate ();
					return;
				} catch (OverflowException) {
					Console.Write("\nInput terlalu besar, coba angka yang lebih kecil");
					Console.Write ("\n\n=================\n\n");
					Calculate ();
					return;
				}
				if (nomorAtom == 0) {
					end = true;
					Console.Write ("\nSee you next time!\n");
					return;
				}
				kulitAtom.Clear();
				int sisaAtom = nomorAtom;
				for(int i = 1; sisaAtom > 0; i++){
					maxKulit = 2 * i * i;
					if(sisaAtom < maxKulit){
						if(sisaAtom > 8){
							for(int j = kulitAtom.Count-1; sisaAtom > 0; j--){
								if(sisaAtom <= 8){
									kulitAtom.Add(sisaAtom);
									sisaAtom = 0;
								} else if(sisaAtom >= kulitAtom[j]){
									sisaAtom -= kulitAtom[j];
									kulitAtom.Add(kulitAtom[j]);
									i = kulitAtom.Count - 1;
								}
							}
						} else {
							kulitAtom.Add(sisaAtom);
							sisaAtom = 0;
						}
					} else {
						sisaAtom -= maxKulit;
						kulitAtom.Add(maxKulit);
					}
				}
				Console.Write ("\nKonfigurasi Elektron\t: ");
				for(int i = 0; i < kulitAtom.Count; i++){
					Console.Write(kulitAtom[i] + (i != (kulitAtom.Count - 1)?", ":"") + " ");
				}
				Console.Write ("\n\n=================\n\n");
			}
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Konfigurasi Elektron Bohr\nMade by Amar Fadil (C) 2017\n\nMasukkan angka 0 untuk keluar aplikasi\n\n===================================\n");
			Calculate ();
		}
	}
}
