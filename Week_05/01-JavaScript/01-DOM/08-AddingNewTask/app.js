'use strict';
let btnAdd = document.getElementById('btnAddNewTask');
let txtTaskName = document.getElementById('txtTaskName');
btnAdd.addEventListener('click', newTask);
txtTaskName.addEventListener('keypress', function(event){
    if (event.key=='Enter') {
        event.preventDefault();
        btnAdd.click();
    }
});

let gorevListesi = [
    { 'id': 1, 'gorevAdi': 'Görev 1' },
    { 'id': 2, 'gorevAdi': 'Görev 2' },
    { 'id': 3, 'gorevAdi': 'Görev 3' },
    { 'id': 4, 'gorevAdi': 'Görev 4' },
    { 'id': 5, 'gorevAdi': 'Görev 5' },
];

function displayTasks() {
    let ul = document.getElementById('task-list');
    ul.innerHTML='';
    for (const gorev of gorevListesi) {
        let li = `
        <li class="task list-group-item">
            <div class="form-check">
                <input type="checkbox" id="${gorev.id}" class="form-check-input">
                <label for="${gorev.id}" class="form-check-label">${gorev.gorevAdi}</label>
            </div>
        </li>
    `;
        ul.insertAdjacentHTML('beforeend', li);
    }
}

function newTask(event){
    event.preventDefault();
    if (isFull(txtTaskName.value)) {
        gorevListesi.push(
            {
                'id': gorevListesi.length + 1,
                'gorevAdi': ilkHarfiBuyut(txtTaskName.value) //ÖDEV: her kelimenin ilk harfini büyütecek functionı yazınız.
            }
        );
        displayTasks();
    }else{
        alert('Lütfen boş bırakmayınız!');
    }
    txtTaskName.value='';
    txtTaskName.focus();
};

function isFull(value){
    if (value.trim()=='') {
        return false;
    }
    return true;
};

function ilkHarfiBuyut(value){
    let ilkHarf = value[0].toUpperCase();
    let geriKalan = value.slice(1);
    return ilkHarf + geriKalan;
}

displayTasks();