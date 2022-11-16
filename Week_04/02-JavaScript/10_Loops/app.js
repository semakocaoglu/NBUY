//while
// let i = 0;
// while (i < 10) {
//     i++;
//     console.log(i + '.JavaScript');
// }

//do while
// let i = 0;
// do {
//     i++;
//     console.log(i + '.JS');
// } while (i < 10);

// for (let i = 0; i < 10; i++) {
//     console.log(i + 1 + '.Java Script');
// }

//1-10 arasındaki sayıları toplayıp konsola yazdırın.
// let toplam = 0;
// let i = 1;
// while (i <= 10) {
//     toplam += i;
//     i++;
// }
// console.log('While ile: ' + toplam);

// let toplam2 = 0;
// for (let i = 1; i <= 10; i++) {
//     toplam2 += i;
// }
// console.log('For ile: ' + toplam2);

//Kullanıcının gireceği 3 sayıyı toplatan kodları for kullanarak yazınız.

// let toplam = 0;
// let girilenSayi;
// for (let i = 1; i <= 3; i++) {
//     girilenSayi = Number(prompt(i + '.sayı: '));
//     toplam += girilenSayi;
// }
// console.log('Toplam: ' + toplam);
//Kullanıcı 0 girene kadar girilen sayıları toplayıp sonucu konsola yazan kodu yazınız.

// let toplam = 0;
// let girilenSayi;
// let i = 1;
// do {
//     girilenSayi = Number(prompt(i + '.sayı: '));
//     toplam += girilenSayi;
//     i++;
// } while (girilenSayi != 0);
// console.log('Toplam: ' + toplam);

//Son örnekteki girilen sayıları da sonuçta yazdıralım.
// 1.Sayı: 20
// 2.Sayı: 10
// 3.Sayı: 30
// Toplam: 60
//NOT: Girilen sayıları bir diziye aktararak kullanın!
// let toplam = 0;
// let girilenSayilar = [];
// let i = 0;
// do {
//     girilenSayilar[i] = Number(prompt(i + 1 + '.sayı: '));
//     toplam += girilenSayilar[i];
//     i++;
// } while (girilenSayilar[i - 1] != 0);
// girilenSayilar.pop();
// for (let i = 0; i < girilenSayilar.length; i++) {
//     console.log(i + 1 + '.Sayı:\t' + girilenSayilar[i]);
// }
// console.log('Toplam: ' + toplam);



//Kullanıcının istediği kadar sayı girmesini sağlayın.
//Sayı girişi bitişi için 0'a basılması gereksin.
//0'a basılıp sayı girişi bittiğinde kullanıcıya şu soruyu sorun: Tek mi çift mi?
//Kullanıcı tek derse: tek sayıları ve toplamlarını
//çift derse çift sayıları ve toplamlarını yazdırın.

let sayilar = [];
let i = 0;
do {
    sayilar[i] = Number(prompt(i + 1 + '.sayı: '));
    i++;
} while (sayilar[i - 1] != 0);
sayilar.pop();
let sonucDizi = [];
let toplam = 0;
let tur;
let cevap = prompt('Tek mi çift mi?');
console.log('Cevap: ' + cevap);
if (cevap.toLocaleLowerCase() == 'tek') {
    tur = 'Tek';
    for (let i = 0; i < sayilar.length; i++) {
        if (sayilar[i] % 2 === 1) {
            sonucDizi.push(sayilar[i]);
            toplam += sayilar[i];
        }
    }
}
else if (cevap.toLocaleLowerCase() == 'çift') {
    tur = 'Çift';
    for (let i = 0; i < sayilar.length; i++) {
        if (sayilar[i] % 2 === 0) {
            sonucDizi.push(sayilar[i]);
            toplam += sayilar[i];
        }
    }
} else {
    console.log('Lütfen "Tek" ya da "Çift" yaz!');
}
console.log(sayilar);
console.log(tur + ' Sayılar: ' + sonucDizi);
console.log(tur + ' Sayıların Toplamı: ' + toplam);