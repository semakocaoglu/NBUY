'use strict';
let sonuc;
let gorevListesi = [
    { 'id': 1, 'gorevAdi': 'Görev 1' },
    { 'id': 2, 'gorevAdi': 'Görev 2' },
    { 'id': 3, 'gorevAdi': 'Görev 3' },
    { 'id': 4, 'gorevAdi': 'Görev 4' },
    { 'id': 5, 'gorevAdi': 'Görev 5' },
];
let ul = document.getElementById('task-list');
for (const gorev of gorevListesi) {
    let li = `
        <li class="task list-group-item">
            <div class="form-check">
                <input type="checkbox" id="${gorev.id}" class="form-check-input">
                <label for="${gorev.id}" class="form-check-label">${gorev.gorevAdi}</label>
            </div>
        </li>
    `;
    ul.insertAdjacentHTML('beforeend',li);
}

// document.querySelector('#task-list').remove();
// document.querySelector('#task-list').parentElement.remove();
// document.querySelector('#task-list').children[0].remove();
// document.querySelector('#task-list').children[2].remove();

// document.querySelector('#task-list').removeAttribute('class');
// document.querySelector('#task-list').children[1].removeAttribute('class');
// sonuc = document.querySelector('#task-list').children[1].getAttribute('class');
// sonuc = document.querySelector('#task-list').children[1].setAttribute('class','bg-danger');
sonuc = document.querySelector('#task-list').children[1].classList;
document.querySelector('#task-list').children[1].classList.add('bg-danger');
sonuc = document.querySelector('#task-list').children[1].classList.contains('bg-danger');
sonuc = document.querySelector('#task-list').children[0].classList.contains('bg-danger');


console.log(sonuc);