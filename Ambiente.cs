using System;

namespace UnitTestProject3
{
    public class Ambiente
    {

        list<string> DispositivosAndroid = new List<string>();
        list<string> DispositivosIOS = new List<string>();
        public string ApkProduccion;
        public string ApkPre;

        public Ambiente()
        {
            ApkProduccion = "";
            ApkPre = "bs://f406cf05e3b731ce0fce429a6c4777237eaa6946";

            DispositivosAndroid.add("Samsung Galaxy S20");
            DispositivosAndroid.add("Google Pixel 5");
            DispositivosAndroid.add("OnePlus 8");
            DispositivosAndroid.add("Xiaomi Redmi Note 8");
            DispositivosAndroid.add("Motorola Moto G7 Play");
            DispositivosAndroid.add("Y50");
        }
    }
}
