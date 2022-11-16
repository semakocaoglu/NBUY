let sonuc;
//getElementById
sonuc = document.getElementById('title');
sonuc = document.getElementById('title').id;
sonuc = document.getElementById('title').className;
sonuc = document.getElementById('title').classList;

document.getElementById('title').style.fontSize='50px';
document.getElementById('title').style.color='red';
// document.getElementById('title').style.display='none';

//querySelector
sonuc = document.querySelector('#title');
sonuc = document.querySelector('div');
sonuc = document.querySelector('.h1');

sonuc = document.querySelector('li');
sonuc = document.querySelector('li:first-child');
sonuc = document.querySelector('li:last-child');
sonuc = document.querySelector('li:nth-child(3)').innerText;


console.log(sonuc);