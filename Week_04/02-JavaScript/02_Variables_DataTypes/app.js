/*
    EcmaScript-ES
    Değişkenler tanımlanırken 3 farklı keyword kullanılabilir.
    1) var
    2) let
    3) const(sabit)

    - ES6 ile birlikte artık Modern JavaScript tabiri kullanılmaya başlanmıştır. Bu süreçte let ve const kullanın, var kullanmaktan kaçının.

    -JS'te değişken tanımlanırken tip belirtilmez.
    -Bu, değişkenlerin tipi olmadığı anlamına gelmez.
    -JS motoru bir değişkene değer atanması esnasında o değere göre tipi belirler. 
    -Eğer henüz bir değişkene değer atanmamışsa undefined olarak belirlenir.

*/

// let yas = 20;
// console.log(yas);

// let ad = 'Geç kalan Sema';
// let soyad = 'Geç kalan Harun';
// console.log(ad);
// console.log(soyad);
// console.log(ad,soyad);

// let firstName='Serhat';
// let lastName='Kaya';
// console.log(firstName + ' ' + lastName);

// let sayi1 = 15;
// let sayi2 = 25;
// let sayi3 = 35;

// let s1 = 15, s2 = 45, s3 = 55;

// let say1 = 25,
//     say2 = 55,
//     say3 = 48;

// let durum = true;

// sayi1=125;
// console.log(sayi1);

// let toplam=0;
// toplam = toplam + say1;

// const benimDogumYilim = 1975;
// console.log('Benim doğum yılım: ' + benimDogumYilim);

/*

    -Bildiğiniz değişken isimlendirme yöntemlerini burada da kullanabilirsiniz. Değişkenleri genellikle camelCase ile isimlendiririz.
    -Değişken isminde harf, rakam, $ ve _ olabilir.
    -Değişken ismi rakamla başlayamaz.
    -Reserved Keyword'ler değişken adı olarak kullanılamaz. 

    -Const sabit değerleri tutmak için kullanılır. Genellikler tamamen büyük harf ile isimlendirilir.
*/

// const PI_SAYISI = 3.14;
// const _PI_SAYISI = 3.14;

// const RENK_1 = 'Sarı';
// const RENK_2 = 'Lacivert';
// let renk_3 = 'Yeşil';

// console.log(RENK_1, renk_3, RENK_2);

//DATA TYPES

//1-NUMBER
// let sayi1 = 100;
// console.log(sayi1);
// console.log(typeof sayi1);
// console.log(typeof(sayi1));

// let sayi2= 17.5;
// console.log(sayi2);
// console.log(typeof sayi2);

// let sayi3 = 25/0;
// console.log(sayi3, typeof(sayi3));

// let sayi4 = 'Okul' / 25;
// console.log(sayi4, typeof(sayi4));

// let sayi5 = -99999999999999999999999999999999999999999999999999999999999999999456546546464654654654654654654654654654646546465465465465464n;
// console.log(sayi5, typeof(sayi5));

// let sayi6 = sayi5 * 9999999999999999999999999999999999999999999999999999999999999999n;
// console.log(sayi6, typeof(sayi6));

//STRING

/*

    String ifadeler üç farklı şekilde ifade edilebilir:
    1) Tek tırnak ile ('')
    2) Çift tırnak ile ("")
    3) Backticks (``)

   
*/

// let ad = '"Engin"';
// let soyad = '\'Niyazi\'';
// let adSoyad = ad + " " + soyad;
// console.log(adSoyad);

// let adres = 'Halitağa Mah.\n\tSütlü Nuriye Sok. Candaş Ap. No:21 \n\tBeşiktaş';
// console.log(adres)

// let adSoyad= 'Engin Niyazi Ergül';
// let yas = 47;
// let kanGrubu = '0Rh+';
// let kilo = 75;
// let cinsiyet = 'sanane';

// console.log('Sayın ' + adSoyad + ', ' + yas + ' yaşındasınız.\nKilo: ' + kilo + '\nKan Grubu: ' + kanGrubu + '\nCinsiyet: ' + cinsiyet + '\n\n\n');


// console.log(`Sayın ${adSoyad}, ${yas} yaşındasınız.
// Kilo: ${kilo}
// Kan Grubu: ${kanGrubu}
// Cinsiyet: ${cinsiyet}
// `);

//BOOLEAN
// let durum = true;
// console.log(durum, typeof(durum));
// let ad = 'Halil';
// console.log(ad, typeof(ad));

//null, undefined
// let yas;
// yas = null;
// yas = 12/0;
// console.log(yas, typeof(yas));


//JavaScriptte CHAR diye bir tip yoktur!

//CONVERT DATA TYPES
// let durum = false;
// console.log(durum, typeof durum);

// let metin = 'Durumunuz ' + durum + ' şeklindedir.';
// console.log(metin, typeof metin);

// let durumMetin = String(durum);
// console.log(durumMetin, typeof durumMetin);

// let sayi = 25;
// let metin2 = sayi + ' yaşındasınız.';
// console.log(metin2, typeof metin2);
// let sayiMetin = String(sayi);
// console.log(sayiMetin, typeof sayiMetin);

// let metinSayi = '455';
// console.log(metinSayi, typeof metinSayi);
// let metinSayiNumber = Number(metinSayi);
// console.log(metinSayiNumber, typeof metinSayiNumber);

// let sayiMetin = '    /    145        ';
// console.log(sayiMetin, typeof sayiMetin);
// let sayi= Number(sayiMetin);
// console.log(sayi, typeof sayi);
//number--> 2 üzeri 53-1
// let sayi=1254n;
// console.log(sayi, typeof sayi);


// console.log(Number(true));
// console.log(Number(false));

// console.log(Boolean(0));
// console.log(Boolean(1));
// console.log(Boolean('0'));

let a;
a = '' + 1 + 0; console.log(a, typeof a);
a = '' - 1 + 0; console.log(a, typeof a);
a = true + false; console.log(a, typeof a);
a = 6 / '3'; console.log(a, typeof a);
a = 4 + 5 + 'px'; console.log(a, typeof a);
a = '$' + 4 + 5; console.log(a, typeof a);
a = '4px' - 2; console.log(a, typeof a);
a = '     -9    ' + 5; console.log(a, typeof a);
a = null + 1; console.log(a, typeof a);
a = undefined + 1; console.log(a, typeof a); 