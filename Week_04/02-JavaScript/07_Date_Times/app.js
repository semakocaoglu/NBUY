let simdi = new Date();
sonuc = simdi;
sonuc = simdi.getDate();
sonuc = simdi.getDay();
sonuc = simdi.getFullYear();
sonuc = simdi.getHours();
sonuc = simdi.getTime();


simdi.setFullYear(2015);
simdi.setMonth(0);
sonuc=simdi;

let suAn = new Date();
sonuc = suAn;
let kacYilSonra=5;
sonuc= new Date(suAn.setFullYear(suAn.getFullYear()+kacYilSonra));


simdi = new Date();
sonuc = simdi;

let dogumTarihi= new Date(1975, 6, 16);
sonuc = simdi.getFullYear()-dogumTarihi.getFullYear();

let milisecond = simdi - dogumTarihi;
let second = milisecond /1000;
let minute = second / 60;
let hour = minute / 60;
let day = hour / 24;

sonuc = parseInt(day);
console.log(dogumTarihi);
console.log(sonuc);